using UnityEngine;
using System.Collections;

public class StarCube : MonoBehaviour {

	public float rotateSpeed;

	private VariableControl variables;

	private bool starDone;

	// Use this for initialization
	void Start () {
		// load the variables
        variables = GameObject.Find("VariableControl").GetComponent<VariableControl>();
	
        starDone = false;
	}
	
	// Update is called once per frame
	void Update () {
		float rotateAmount = rotateSpeed * Time.deltaTime;

		transform.Rotate(new Vector3(rotateAmount, -rotateAmount, rotateAmount * 0.5f));
	}

	// this star was hit by the falling cube
	void OnTriggerEnter() {

		if (!starDone) {
			// play the blow up animation
			gameObject.GetComponent<Animator>().enabled = true;

			variables.totalStarCubes--;
			variables.score += 10;
			
			GameObject.Find ("Score Number").GetComponent<TextMesh>().text = variables.score.ToString();

			starDone = true;
		}
	}
}
