using UnityEngine;
using System.Collections;

public class BoxDrop : MonoBehaviour {

	public Color boxColor;
	public float colorChangeAmount;
	private bool onPlayer;

	// keep track of the Y position for the push up (to remove the sticky joint)
	private float lastY;
	private float nowY;

	// Use this for initialization
	void Start () {
		// color set in UI
		renderer.material.color = boxColor;

		onPlayer = false;

		nowY = 0.0f;
		lastY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		// move it back up above the screen if it falls below the screen
		if (transform.position.y < -10.0f) {
			// reset physics stuff
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;

			// reset position and rotation
			transform.rotation = Quaternion.identity;
			transform.position = new Vector3(0.0f, 12.0f, 0.0f);

			renderer.material.color = new Color(1.0f, 1.0f, 1.0f);
		}


		if (onPlayer) {
			// lose some green and blue, making the box redder
			if (boxColor.g > 0.0) {
				boxColor.g -= colorChangeAmount;
			}
			if (boxColor.b > 0.0) {
				boxColor.b -= colorChangeAmount;
			}
			renderer.material.color = boxColor;

			// check the upwards velocity, and if it's enough, let the falling cube go
			nowY = transform.position.y;
			if (nowY - lastY > 0.07f) {
				Destroy(gameObject.GetComponent<FixedJoint>());
			}

			// reset lastY
			lastY = nowY;

		} else {
			// gain some green and blue, making the box less red
			if (boxColor.g < 1.0) {
				boxColor.g += colorChangeAmount;
			}
			if (boxColor.b < 1.0) {
				boxColor.b += colorChangeAmount;
			}
			renderer.material.color = boxColor;
		}
	}

	// if the box is resting on the player's cube, start making it more red
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Player Cube") {
			onPlayer = true;

			// need the box to "stick" to the player cube on contact
			FixedJoint joint = gameObject.AddComponent<FixedJoint>();
			joint.connectedBody = collision.rigidbody;
		}
	}

	/*
	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.name == "Player Cube") {
			onPlayer = false;
			Debug.Log("UNCollided");
		}
	}
	*/
}
