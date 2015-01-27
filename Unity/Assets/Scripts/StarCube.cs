﻿using UnityEngine;
using System.Collections;

public class StarCube : MonoBehaviour {

	public float rotateSpeed;

	private VariableControl variables;

	// Use this for initialization
	void Start () {
		// load the variables
        variables = GameObject.Find("VariableControl").GetComponent<VariableControl>();
	}
	
	// Update is called once per frame
	void Update () {
		float rotateAmount = rotateSpeed * Time.deltaTime;

		transform.Rotate(new Vector3(rotateAmount, -rotateAmount, rotateAmount * 0.5f));
	}

	// this star was hit by the falling cube
	void OnTriggerEnter() {
		// for now make it disappear
		//gameObject.SetActive(false);

		// play the blow up animation
		gameObject.GetComponent<Animator>().enabled = true;

		variables.totalStarCubes--;

		Debug.Log("total star cubes = " + variables.totalStarCubes);
	}
}
