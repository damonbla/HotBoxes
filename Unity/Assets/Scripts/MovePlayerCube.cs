using UnityEngine;
using System.Collections;

public class MovePlayerCube : MonoBehaviour {

	// new position x, y, and z for player cube
	private float newX;
	private float newY;
	private float newZ;
	
	// keeping track of the current position of the player cube
	private Vector3 currentPosition;

	// is the mouse button down?
	private bool mouseDown;

	// Use this for initialization
	void Start () {
		newX = 0.0f;
		newY = 0.0f;
		newZ = 0.0f;

		currentPosition = new Vector3 (0.0f, 0.0f, 0.0f);

		mouseDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			// a finger is on the screen
			Vector2 touchMovement = Input.GetTouch(0).deltaPosition;
			//Vector3 touchPos = new Vector3(touchMovement.x, touchMovement.y, Camera.main.nearClipPlane);
			//Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);

			currentPosition = this.transform.position;
			newX = currentPosition.x + (touchMovement.x * 0.011f);
			newY = currentPosition.y + (touchMovement.y * 0.011f);
			newZ = currentPosition.z;
			
			if (newX > -3.9f && newX < 3.9f) {
				this.transform.position = new Vector3(newX, newY, newZ);
			}

			//Vector3 touchPos = new Vector3(touchMovement.x, touchMovement.y, Camera.main.nearClipPlane);
			//Vector3 worldPos = Camera.main.ScreenToWorldPoint(touchPos);
			//transform.position = new Vector3(worldPos.x, worldPos.y + 1.0f, 0.0f);
		}



		// for testing since it's easier than putting it on the phone
		if (Input.GetMouseButtonDown(0)) {
			mouseDown = true;
		}

		if (Input.GetMouseButtonUp (0)) {
			mouseDown = false;
		}

		if (mouseDown) {
			float xMovement = Input.GetAxis ("Mouse X");
			float yMovement = Input.GetAxis ("Mouse Y");

			currentPosition = this.transform.position;
			newX = currentPosition.x + xMovement;
			newY = currentPosition.y + yMovement;
			newZ = currentPosition.z;
			
			if (newX > -3.9f && newX < 3.9f) {
				transform.position = new Vector3(newX, newY, newZ);
			}
		}
	}
}
