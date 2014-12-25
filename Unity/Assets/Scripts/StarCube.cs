using UnityEngine;
using System.Collections;

public class StarCube : MonoBehaviour {

	public float rotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float rotateAmount = rotateSpeed * Time.deltaTime;

		transform.Rotate(new Vector3(rotateAmount, -rotateAmount, rotateAmount * 0.5f));
	}

	// this star was hit by the falling cube
	void OnTriggerEnter() {
		
	}
}
