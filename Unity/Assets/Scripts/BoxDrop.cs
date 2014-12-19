using UnityEngine;
using System.Collections;

public class BoxDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10.0f) {
			// reset physics stuff
			gameObject.rigidbody.velocity = Vector3.zero;
			gameObject.rigidbody.angularVelocity = Vector3.zero;

			// reset psotion and rotation
			transform.rotation = Quaternion.identity;
			transform.position = new Vector3(0.0f, 10.0f, 0.0f);
		}
	}
}
