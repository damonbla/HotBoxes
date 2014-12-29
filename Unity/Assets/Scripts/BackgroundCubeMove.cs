using UnityEngine;
using System.Collections;

public class BackgroundCubeMove : MonoBehaviour {

	private float startZ;
	private float timeAdjustment;

	// Use this for initialization
	void Start () {
		startZ = Random.Range(-10, 10) * 0.05f;
		timeAdjustment = Random.Range(-10, 10) * 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y, 5.0f - startZ * Mathf.Sin(Time.time + timeAdjustment));
	}
}
