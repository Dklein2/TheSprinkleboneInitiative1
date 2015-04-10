using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class doublejump : MonoBehaviour {

	private PlatformerCharacter2D player;

	void OnTriggerEnter2D(Collider2D other) 
	{
	

		PlatformerCharacter2D.main.doublejump = true;

	}
}
