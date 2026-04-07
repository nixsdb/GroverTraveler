using UnityEngine;
using System.Collections;
using TMPro;

[System.Serializable]
public class CutsceneStep {
    [TextArea(2, 3)] 
    public string dialogueText;
    public float waitTime = 2f;
    public bool moveCharacterHere = false;
}

public class SimpleCutscene : MonoBehaviour {
    [Header("UI elements")]
    public GameObject textBoxPanel;
    public TextMeshProUGUI dialogueText;

    [Header("Sequence")]
    public CutsceneStep[] sceneSteps; 

    [Header("Movement")]
    public GameObject otherSprite;
    public Transform targetPosition;
    public float moveSpeed = 2f;

    [Header("Player control")]
    public MonoBehaviour playerMovementScript; 

    void Start() {
        if (textBoxPanel != null) {
            textBoxPanel.SetActive(false);
        }
    }

    public void Play() {
        //to whoever is reading this i have fallen in love with coroutines and im never using Update() again
        StartCoroutine(CutsceneSequence());
    }

    // https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=net-10.0
    private IEnumerator CutsceneSequence() {
        // lock player during cutscene
        if (playerMovementScript != null) {
            playerMovementScript.enabled = false; 
        }

        textBoxPanel.SetActive(true);
        
        foreach (var currentStep in sceneSteps) { //thanks jetbrains
            dialogueText.text = currentStep.dialogueText;
            
            if (currentStep.moveCharacterHere && otherSprite != null && targetPosition != null) {
                while (Vector3.Distance(otherSprite.transform.position, targetPosition.position) > 0.05f) {
                    otherSprite.transform.position = Vector3.MoveTowards(
                        otherSprite.transform.position, 
                        targetPosition.position, 
                        moveSpeed * Time.deltaTime
                    );
                    yield return null; //iterator needs yield return instead of return in C#
                }
                otherSprite.transform.position = targetPosition.position;
            }
            
            yield return new WaitForSeconds(currentStep.waitTime);
        }
        
        textBoxPanel.SetActive(false);
        
        if (playerMovementScript != null) {
            playerMovementScript.enabled = true; 
        }
    }
}
