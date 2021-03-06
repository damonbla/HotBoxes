﻿using UnityEngine;
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

	// keep a local time for animation purposes
	//private float timeHere;

	// the variables
	private VariableControl variables;

	// Use this for initialization
	void Start () {
		newX = 0.0f;
		newY = 0.0f;
		newZ = 0.0f;

		currentPosition = new Vector3 (0.0f, 0.0f, 0.0f);

		mouseDown = false;

		//timeHere = Time.time;

		// load the variables
        variables = GameObject.Find("VariableControl").GetComponent<VariableControl>();
	}
	
	// Update is called once per frame
	void Update () {
		// when the animation for bringing the player cube up from the bottom is done,
		// disable the animator (otherwise you can't move the cube)
		//if (Time.time - timeHere > 1.0f) {
		//	gameObject.GetComponent<Animator>().enabled = false;
		//}

		if (variables.onPhone) {
			if (Input.touchCount > 0) {
				// a finger is on the screen
				Vector2 touchMovement = Input.GetTouch(0).deltaPosition;

				currentPosition = this.transform.position;
				newX = currentPosition.x + (touchMovement.x * 0.07f);
				newY = currentPosition.y + (touchMovement.y * 0.07f);
				newZ = currentPosition.z;
				
				// don't go off the sides of the screen or above the bar
				if (newX > -3.9f && newX < 3.9f && newY < -2.3f) {
					this.transform.position = new Vector3(newX, newY, newZ);
				}
			}
		}

		// for testing since it's quicker than putting it on the phone
		if (!variables.onPhone) {
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
				
				// don't go off the sides of the screen or above the bar
				if (newX > -3.9f && newX < 3.9f && newY < -2.3f) {
					transform.position = new Vector3(newX, newY, newZ);
				}
			}
		}
	}
}
