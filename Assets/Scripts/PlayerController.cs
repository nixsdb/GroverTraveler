using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 4.0f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
	}

	// Update is called once per frame
	void Update() {
		Debug.Log("current pos " + transform.position);
		MovePlayer();
	}

	void MovePlayer() {
		float moveX = 0f;
		float moveY = 0f;
		
		// get direction based on input
		if(Input.GetKey(KeyCode.RightArrow)) {
			moveX = 1f;
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			moveX = -1f;
		}
		if(Input.GetKey(KeyCode.UpArrow)) {
			moveY = 1f;
		}
		if(Input.GetKey(KeyCode.DownArrow)) {
			moveY = -1f;
		}
		
		// create vector
		Vector2 movement = new Vector2(moveX, moveY);
		
		// move character
		transform.Translate(movement * speed * Time.deltaTime);
	}
}
