﻿using UnityEngine;
using System.Collections;

public class GameplayScript : MonoBehaviour {

	// cubes for the background
	public GameObject backgroundCube;
	private GameObject[,] backgroundCubes = new GameObject[7,11];

	// indicator arrows for when dropping cube goes above the top of the screen
	public GameObject indicatorArrow;
	private GameObject indicatorParent;
	private bool indicatorActive;

	private VariableControl variables;



	//------------------------------------- Helper functions --------------------------------------



	// Use this for initialization
	void Start () {
		// load the variables
        variables = GameObject.Find("VariableControl").GetComponent<VariableControl>();

        // this will be loaded with a level
        variables.totalStarCubes = 2;

		// instantiate all the background cubes
		for (int x = 0; x < 7; x++) {
			for (int y = 0; y < 11; y++) {
				backgroundCubes[x,y] = (GameObject)Instantiate(backgroundCube, new Vector3((x - 3.0f) * 2.0f, (y - 4.0f) * 2.0f, 10.0f), Quaternion.identity);
				backgroundCubes[x,y].GetComponent<BackgroundCubeMove>().timeAdjustment = y + 0.5f;
				backgroundCubes[x,y].GetComponent<BackgroundCubeMove>().zAdjustment = 0.0f;
			}
		}

		// indicator for when the falling cube is above the top of the screen
		// its parent that is
		indicatorParent = new GameObject();
		Vector3 indicatorParentPos = new Vector3(0.0f, 0.0f, 0.0f);
		indicatorParent.transform.position = indicatorParentPos;		

		indicatorArrow = (GameObject)Instantiate (indicatorArrow, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
		indicatorArrow.transform.parent = indicatorParent.transform;
		indicatorArrow.SetActive(false);
		indicatorActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		// get the indicator arrows on the screen
		// need them to be in the right place: based on the x value of the dropping cube
		if (GameObject.Find ("Dropping Box").transform.position.y > 8.0f) {
			if (!indicatorActive) {
				indicatorArrow.SetActive(true);
			}
			float dropX = GameObject.Find ("Dropping Box").transform.position.x;
			indicatorParent.transform.position = new Vector3 (dropX, 6.8f, 0.0f);
		} else {
			indicatorParent.transform.position = new Vector3 (0.0f, 00.0f, 0.0f);
			indicatorArrow.SetActive(false);
			indicatorActive = false;
		}
	}

}
