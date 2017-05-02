using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageChanger : MonoBehaviour 
{

	// reference to texture(SCREENSHOT) in Resources folder //
	private WWW pullImage;

	// Blank texture to load imported screenshot on //
	public Texture2D blankTexture;

	// The Renderer(Mesh) texture slot in the plane to insert new screenshot // 
	public Renderer rend;




	void Start() 
	{
		// Get Canvas texture slot //
		rend = GetComponent<Renderer>();

		// This is a method call //
		// Call our amazing method!! (see below) //
		//ScreenPrint();
	} 




	// This is our function/method //
	public void ScreenPrint() 
	{
		// Retrieve our screenshot from resources folder //
		pullImage = new WWW("file://" + Application.dataPath + "/Resources/Screensave.png");

		// Load texture(screenshot) into Canvas texture slot //
		pullImage.LoadImageIntoTexture(blankTexture);

		// Make Canvas slot change to new texture //
		rend.material.mainTexture = (Texture)blankTexture;
	}
}