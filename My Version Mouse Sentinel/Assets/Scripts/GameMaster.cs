using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	Transform planeObject;
	ImageChanger imageChangerScript;
	PlaneWindowResizer PlaneWindowResizer;

	public int ZOMBIE_SPEED;

	public float planeWidth;
	public float planeHeight;

	// Use this for initialization
	void Start () {
	
		planeObject = GameObject.Find ("Plane").transform;

		imageChangerScript = planeObject.GetComponent<ImageChanger> ();

		PlaneWindowResizer = planeObject.GetComponent<PlaneWindowResizer> ();

		planeWidth = PlaneWindowResizer.GetWidth ();
		planeHeight = PlaneWindowResizer.GetHeight ();

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("space")) {
			print ("GAME HAS STARTED!!");

			imageChangerScript.ScreenPrint ();

		}
	}
}
