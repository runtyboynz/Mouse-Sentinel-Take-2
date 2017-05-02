using UnityEngine;
using System.Collections;

public class EffectsExplosionZombieAnimator : MonoBehaviour {

	private Animator anim;

	//private float shuffle;
	//private float running;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void OnMouseDown ()
	{
		int n = Random.Range (0, 2);//Chooses a random number between 0,1, or 2. Then plays that animation.

		if (n == 0) 
		{
			anim.Play ("Zomb1FaceExplosion1", -1, 0f);
			this.gameObject.transform.parent.GetComponent<ZombieController> ().zombieStop = true;
		} 
		if (n == 1) 
		{
			anim.Play ("Zomb1FaceExplosion2", -1, 0f);
			this.gameObject.transform.parent.GetComponent<ZombieController> ().zombieStop = true;
		}
			
		if (this.gameObject.transform.parent.GetChild (0) != null) 
		{
			if (this.gameObject.transform.parent.GetChild (0).GetComponent<Zomb1Animator> ().bodyDying == false) 
			{
				this.gameObject.transform.parent.GetChild (0).GetComponent<Zomb1Animator> ().DeathAnimationsFallDown ();
			}
		}
	}

	public void DestroyZombieHead() {

	//	Destroy(this.gameObject);
	//	Destroy(this.gameObject.transform.parent.gameObject);

	}
		//anim.SetFloat ("inputH", inputH);
		//anim.SetFloat ("inputV", inputV);
}
