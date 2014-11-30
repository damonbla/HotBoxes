using UnityEngine;
using System.Collections;

public class MovePlayerCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			// a finger is on the screen
			Vector2 touchMovement = Input.GetTouch(0).deltaPosition;

			Vector3 currentPosition = this.transform.position;
			float newX = currentPosition.x + touchMovement.x;
			float newY = currentPosition.y + touchMovement.y;
			float newZ = currentPosition.z;

			this.transform.Translate(newX, newY, newZ);
		}


		// for testing since it's easier than putting it on the phone
		if (Input.GetMouseButtonDown(0) {
			// a finger is on the screen
			//Vector2 touchMovement = Input.GetTouch(0).deltaPosition;
			Vector2 touchMovement = Input.GetAxis ("Vertical");

			Vector3 currentPosition = this.transform.position;
			float newX = currentPosition.x + touchMovement.x;
			float newY = currentPosition.y + touchMovement.y;
			float newZ = currentPosition.z;
			
			this.transform.Translate(newX, newY, newZ);
		}
	}
}
