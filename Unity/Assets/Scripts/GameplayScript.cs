using UnityEngine;
using System.Collections;

public class GameplayScript : MonoBehaviour {

	// cubes for the background
	public GameObject backgroundCube;
	private GameObject[,] backgroundCubes = new GameObject[7,10];

	// Use this for initialization
	void Start () {
		// instantiate all the background cubes
		for (int x = 0; x < 7; x++) {
			for (int y = 0; y < 10; y++) {
				backgroundCubes[x,y] = (GameObject)Instantiate(backgroundCube, new Vector3((x - 3.0f) * 2.0f, (y - 4.0f) * 2.0f, 10.0f), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
