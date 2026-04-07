using UnityEngine;

public class CutsceneTrigger : MonoBehaviour {
    public enum TriggerMethod { WalkOver, InteractWithKey }
    
    // headers make this SO much easier in editor please dont forget this future shane
    // https://docs.unity3d.com/ScriptReference/HeaderAttribute.html
    [Header("General")]
    public TriggerMethod howToTrigger = TriggerMethod.WalkOver;
    public KeyCode interactKey = KeyCode.Z; //TODO: || KeyCode.Return; cannot use OR its a bool, "Cannot apply operator '||' to operands of type 'KeyCode' and 'KeyCode'"
    
    [Header("What to play")]
    public SimpleCutscene cutsceneToPlay;

    // "Initializing field by default value is redundant"
    private bool hasTriggered = false; 
    private bool isPlayerInRange = false;

    void Update() {
        if (howToTrigger == TriggerMethod.InteractWithKey && !hasTriggered && isPlayerInRange) {
            if (Input.GetKeyDown(interactKey)) {
                StartCutscene();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !hasTriggered) {
            isPlayerInRange = true;
            if (howToTrigger == TriggerMethod.WalkOver) {
                StartCutscene();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isPlayerInRange = false;
        }
    }

    private void StartCutscene() {
        hasTriggered = true; //make sure it only fires once
        if (cutsceneToPlay != null) {
            cutsceneToPlay.Play();
        } else {
            Debug.LogWarning("No cutscene attached to the trigger, is this intentional? ");
        }
    }
}