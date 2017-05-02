using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperSpawner : MonoBehaviour 
{
	public GameObject[] chompers;
	public Vector2 spawnAreaValues;
	public float spawnWaitTime;
	public float spawnMostWaitTime;
	public float spawnLeastWaitTime;
	public int startWaitTime;

	int chomperType;

	void Start () 
	{
		StartCoroutine (SpawnTimer ());
	}
	

	void Update () 
	{
		spawnWaitTime = Random.Range (spawnLeastWaitTime, spawnMostWaitTime);
		//makes the spawn timer random if you want to do it.
	}

	IEnumerator SpawnTimer ()
	{
		yield return new WaitForSeconds (startWaitTime);
			//Sets up how many seconds before chomper first spawns
			while (true)
			{
				chomperType = Random.Range (0, 4);
				//chooses between the 4 different chompers at random.

				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnAreaValues.x, spawnAreaValues.x), Random.Range (-spawnAreaValues.y, spawnAreaValues.y));
				//Sets up the area of the spawning

				Instantiate (chompers[chomperType], spawnPosition + transform.TransformPoint (0,0,0), gameObject.transform.rotation);
				//Spawns chompers

				yield return new WaitForSeconds (spawnWaitTime);
				//Sets how long before next chomper spawns
			}
	}
}
