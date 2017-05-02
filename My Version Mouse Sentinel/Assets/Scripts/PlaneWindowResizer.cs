using UnityEngine;
using System.Collections;

public class PlaneWindowResizer : MonoBehaviour {

	private float height;
	private float width;

	// Use this for initialization
	void Start () {
		
		SetSize ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void SetSize() {
		
		height = (float)Camera.main.orthographicSize * 2.0f;

		width = height * Screen.width / Screen.height;

		this.transform.localScale = new Vector3(width/10, 1.0f, height/10);
	}

	public float GetWidth(){

		return width;
	}

	public float GetHeight(){

		return height;
	}
}
