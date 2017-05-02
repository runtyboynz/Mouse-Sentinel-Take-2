using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBody : MonoBehaviour {

	private Animator anim;

	public GameObject zombieHead;

	public GameObject floor;

	public ParticleSystem particle;

	void Start () 
	{
		anim = GetComponent<Animator> ();

		anim.SetBool("ZombieShuffle", true);

	} 

	void Update () {

	}

	// Update is called once per frame
	void OnMouseDown () {

		AnimationsBodyExplode ();
	}


	public void AnimationsBodyExplode() {

		floor.GetComponent<BoxCollider2D> ().enabled = true;

		int n = Random.Range (0, 3);//Chooses a random number between 0,1, or 2. Then plays that animation.

		switch (n) {
		case 0:
			anim.SetBool ("BodyDeath01", true);
			break;
		case 1:
			anim.SetBool ("BodyDeath02", true);
			break;
		case 2:
			anim.SetBool ("BodyDeath03", true);
			break;
		}

		transform.parent.GetComponent<ZombieController> ().zombieStop = true;
		if (zombieHead) {
			zombieHead.GetComponent<CircleCollider2D> ().enabled = true;
			zombieHead.GetComponent<Rigidbody2D> ().gravityScale = 1;
		}
		particle.gameObject.SetActive (true);
	}


	public void AnimationsBodyFallDown() {

		floor.GetComponent<BoxCollider2D> ().enabled = true;

		int n = Random.Range (0, 2);//Chooses a random number between 0,1, or 2. Then plays that animation.

		switch (n) {
		case 0:
			anim.SetBool ("FallDeath01", true);
			break;
		case 1:
			anim.SetBool ("FallDeath02", true);
			break;
		}

		transform.parent.GetComponent<ZombieController> ().zombieStop = true;
		if (zombieHead) {
			zombieHead.GetComponent<CircleCollider2D> ().enabled = true;
			zombieHead.GetComponent<Rigidbody2D> ().gravityScale = 1;
		}
		//particle.gameObject.SetActive (true);
	}


	public void DestroyZombie() {
		
		Destroy(this.gameObject);
	}
}
