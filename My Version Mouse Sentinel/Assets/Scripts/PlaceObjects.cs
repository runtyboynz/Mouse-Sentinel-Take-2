using UnityEngine;
using System.Collections;

public class PlaceObjects : MonoBehaviour {

	// Game Models //
	public GameObject CPU;
	public GameObject ZOMBIE;

	private GameObject spawnPointsObject;
	private Transform spawnPointCont;
	private Transform spawnPnt;
	public int zombieCount;

	private float height;
	private float width;

	// Use this for initialization
	void Start () {
	
		SetSize ();

		SetSpawnPoints ();

		PlaceCPU ();

		PlaceZombies ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetSize() {

		height = (float)Camera.main.orthographicSize * 2.0f;

		width = height * Screen.width / Screen.height;

		this.transform.localScale = new Vector3(width/10, 1.0f, height/10);

	}

	void SetSpawnPoints() {
		
		spawnPointsObject = GameObject.Find ("SpawnPoints").gameObject;

		// Left side //
		spawnPointCont = spawnPointsObject.gameObject.transform.GetChild(0);
		spawnPointCont.position = new Vector3(width/2, 0, 0);

		// Right side //
		spawnPointCont = spawnPointsObject.gameObject.transform.GetChild(1);
		spawnPointCont.position = new Vector3(-width/2, 0, 0);

		// Top //
		spawnPointCont = spawnPointsObject.gameObject.transform.GetChild(2);
		spawnPointCont.position = new Vector3(0, height/2, 0);

		// Bottom //
		spawnPointCont = spawnPointsObject.gameObject.transform.GetChild(3);
		spawnPointCont.position = new Vector3(0, -height/2, 0);

	}

	void PlaceCPU() {
		
		GameObject cpu = Instantiate (CPU);
		cpu.transform.SetParent(this.transform);

	}

	void PlaceZombies() {

		spawnPointsObject = GameObject.Find ("SpawnPoints").gameObject;

		float heightDist = (height / 2);
		float widthDist = (width / 2);
		// 0 - left, 1 - right, 2 - top, 3 - bottom //
		int randomSide = 0;
		// between (-heightDist, heightDist) or (-widthDist, widthDist) //
		// depending on side of screen spawned from //
		float randomSpot = 0;
		Vector3 spawnSpot;

		// Place enemies randomly around screen //
		// 0 - left, 1 - right, 2 - top, 3 - bottom // 
		for (int i = 0; i < zombieCount; i++) {

			randomSide = Random.Range (0, 4);

			spawnPointCont = spawnPointsObject.gameObject.transform.GetChild(randomSide);

			if (randomSide == 0 || randomSide == 1) {
				randomSpot = Random.Range (-heightDist, heightDist);
				spawnSpot = new Vector3(spawnPointCont.gameObject.transform.position.x, randomSpot, spawnPointCont.gameObject.transform.position.z);
			} else {
				randomSpot = Random.Range (-widthDist, widthDist);
				spawnSpot = new Vector3(randomSpot, spawnPointCont.gameObject.transform.position.y, spawnPointCont.gameObject.transform.position.z);
			}
				
			GameObject zombie = Instantiate (ZOMBIE);
			zombie.transform.SetParent (this.transform);
			zombie.transform.position = spawnSpot;

			// Flip zombie gamobject 180 if over half way of screen //
			if (zombie.transform.position.x <= 0) {
				zombie.transform.Rotate (Vector3.up, 180);
				// move head forawrd //
				Transform head = zombie.gameObject.transform.GetChild (0).transform;
				Vector3 vect = new Vector3 (head.position.x, head.position.y, head.position.z + 2f); // <<<<<<< not working
				head.transform.position = vect;

			}
		}

	}
}
