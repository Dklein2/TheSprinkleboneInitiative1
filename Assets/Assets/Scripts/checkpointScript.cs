using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class checkpointScript : MonoBehaviour {

	public int checkpointNumber;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player")
		{
			PlatformerCharacter2D.main.currentCheckpoint = checkpointNumber;
			Debug.Log("Checkpoint");
		}
	}
}
