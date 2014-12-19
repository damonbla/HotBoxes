using UnityEngine;
using System.Collections;

public class BoxDrop : MonoBehaviour {

	public Color boxColor;
	public float colorChangeAmount;

	// Use this for initialization
	void Start () {
		boxColor = new Color(1.0f, 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		// move it back up above the screen if it falls below the screen
		if (transform.position.y < -10.0f) {
			// reset physics stuff
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;

			// reset psotion and rotation
			transform.rotation = Quaternion.identity;
			transform.position = new Vector3(0.0f, 10.0f, 0.0f);

			renderer.material.color = new Color(1.0f, 1.0f, 1.0f);
		}		
	}

	// if the box is resting on the player's cube, start making it more red
	void OnCollisionStay() {
		// lose some green and blue, making the box redder
		boxColor.g -= colorChangeAmount;
		boxColor.b -= colorChangeAmount;

		renderer.material.color = boxColor;
	}

	void OnCollisionExit() {
		// lose some green and blue, making the box redder
		boxColor.g += colorChangeAmount;
		boxColor.b += colorChangeAmount;

		renderer.material.color = boxColor;		
	}
}
