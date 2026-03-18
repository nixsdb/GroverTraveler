using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    public string sceneToLoad;
    public string transitionID;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) { //jetbrains says "Explicit string comparison is inefficient, use CompareTag
            PlayerPrefs.SetString("LastExitID", transitionID);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
