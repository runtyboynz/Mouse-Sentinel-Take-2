using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHead : MonoBehaviour {


	private Animator anim;

	public ParticleSystem particle;

	public GameObject floor;

	public GameObject zombieBody;


	//private float shuffle;
	//private float running;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void OnMouseDown ()
	{
		AnimationsHeadExplode ();
	}


	public void AnimationsHeadExplode() {

		floor.GetComponent<BoxCollider2D> ().enabled = true;
		
		int n = Random.Range (0, 2);//Chooses a random number between 0,1, or 2. Then plays that animation.

		switch (n) {
		case 0:
			anim.SetBool("HeadDeath01", true);
			break;
		case 1:
			anim.SetBool("HeadDeath02", true);
			break;
		}

		transform.parent.GetComponent<ZombieController> ().zombieStop = true;
		if (zombieBody) {
			zombieBody.GetComponent<ZombieBody> ().AnimationsBodyFallDown ();
		}
		particle.gameObject.SetActive (true);

	}


	public void DestroyZombieHead() {

		Destroy(this.gameObject.transform.parent.gameObject);
		Destroy(this.gameObject);
	}
}
