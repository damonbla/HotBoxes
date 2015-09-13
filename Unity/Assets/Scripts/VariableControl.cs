using UnityEngine;
using System.Collections;

public class VariableControl : MonoBehaviour {

	public int score;
	public int level;
	public int totalStarCubes;

	// are we playing on the phone or in Unity?
	public bool onPhone;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
