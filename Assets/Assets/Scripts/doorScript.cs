using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class doorScript : MonoBehaviour {


	public int keyAmount = 0;
	private Animator anim;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player")
		{
			if (keyAmount <= PlatformerCharacter2D.main.keyAmount)
			{
				Destroy(gameObject);
			}
		}
	}
}
