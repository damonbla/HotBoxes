﻿using UnityEngine;
using System.Collections;

public class ParticleHelper : MonoBehaviour {
	
	public static ParticleHelper Instance;
	
	public ParticleSystem explosion;
	
	// Use this for initialization
	void Start () {
		// Register the singleton
		if (Instance != null)
		{
			//			Debug.LogError("Multiple instances of ParticleHelper!");
		}
		
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void explode(Vector3 position)
	{
		instantiate (explosion, position);
	}
	
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
		
		// Make sure it will be destroyed
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
		);
		
		return newParticleSystem;
	}
}