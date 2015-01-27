using UnityEngine;
using System.Collections;

public class GameplayScript : MonoBehaviour {

	// cubes for the background
	public GameObject backgroundCube;
	private GameObject[,] backgroundCubes = new GameObject[7,11];

	private VariableControl variables;

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
	}
	
	// Update is called once per frame
	void Update () {

	}
}
