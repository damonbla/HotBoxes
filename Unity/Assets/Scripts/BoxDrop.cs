using UnityEngine;
using System.Collections;

public class BoxDrop : MonoBehaviour {

	public Color boxColor;
	public float colorChangeAmount;
	private bool onPlayer;

	// keep track of the Y position for the push up (to remove the sticky joint)
	//private float lastY;
	//private float nowY;
	
	// explosion particles
	//public ParticleSystem explosion;
	
	// reset the dropping cube
	void resetCube() {
		// reset physics stuff
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		
		// reset position and rotation
		transform.rotation = Quaternion.identity;
		transform.position = new Vector3(0.0f, 12.0f, 0.0f);
		
		//GetComponent<Renderer>().material.color = Color.white;
		boxColor = Color.white;
	}
	
	
	// Use this for initialization
	void Start () {
		// color set in UI
		GetComponent<Renderer>().material.color = boxColor;

		onPlayer = false;

		//nowY = 0.0f;
		//lastY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		// move it back up above the screen if it falls below the screen
		if (transform.position.y < -10.0f) {
			resetCube();
		}


		if (onPlayer) {
			// lose some green and blue, making the box redder
			if (boxColor.g > 0.0f) {
				boxColor.g -= colorChangeAmount;
			}
			if (boxColor.b > 0.0f) {
				boxColor.b -= colorChangeAmount;
			}
			GetComponent<Renderer>().material.color = boxColor;


			// if it's totally red, BOOM
			if (boxColor.g <= 0.0f && boxColor.b <= 0.0f) {
				ParticleHelper.Instance.explode (gameObject.transform.position);
				resetCube();
			}


			// check the upwards velocity, and if it's enough, let the falling cube go
			/*
			nowY = transform.position.y;
			if (nowY - lastY > 0.07f) {
				Destroy(gameObject.GetComponent<FixedJoint>());
				onPlayer = false;
			}

			// reset lastY
			lastY = nowY;
			*/

		} else {
			// gain some green and blue, making the box less red
			if (boxColor.g < 1.0) {
				boxColor.g += colorChangeAmount;
			}
			if (boxColor.b < 1.0) {
				boxColor.b += colorChangeAmount;
			}
			GetComponent<Renderer>().material.color = boxColor;
		}
	}

	// if the box is resting on the player's cube, start making it more red
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Player Cube") {
			onPlayer = true;

			// need the box to "stick" to the player cube on contact
			//FixedJoint joint = gameObject.AddComponent<FixedJoint>();
			//joint.connectedBody = collision.rigidbody;
		}
	}

	
	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.name == "Player Cube") {
			onPlayer = false;
		}
	}

}
