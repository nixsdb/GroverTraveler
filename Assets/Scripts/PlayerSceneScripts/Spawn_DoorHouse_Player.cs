using UnityEngine;

public class Spawn_DoorHouse_Player : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (PlayerPrefs.HasKey("LastExitID")) {
            string lastID = PlayerPrefs.GetString("LastExitID");
            GameObject spawnPoint = GameObject.Find("Spawn_" + lastID);
            if (spawnPoint != null) {
                transform.position = spawnPoint.transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update() {
    }
}
