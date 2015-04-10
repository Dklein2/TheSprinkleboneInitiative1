using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class deathScript : MonoBehaviour {

	private int lives;
	private int spawnPoint;
	private GameObject checkPoint;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player")
		{
			lives = spawnPoint = PlatformerCharacter2D.main.lives;
			spawnPoint = PlatformerCharacter2D.main.currentCheckpoint;

			if (lives>0)
			{
				if (spawnPoint == 0)
				{
					lives--;
					checkPoint = GameObject.Find("CheckPoint");
					Debug.Log("Player is dead, Respawning at checkpoint");
					PlatformerCharacter2D.main.lives = lives;
					other.transform.position = checkPoint.transform.position; 
					Debug.Log("lives = " + lives);
				}
				else
				{
					lives--;
					checkPoint = GameObject.Find("CheckPoint " + spawnPoint);
					Debug.Log("Player is dead, Respawning at checkpoint " + spawnPoint );
					PlatformerCharacter2D.main.lives = lives;
					other.transform.position = checkPoint.transform.position; 
					Debug.Log("lives = " + lives);
				}
			}

			else
			{
				Application.LoadLevel(0);
			}



		}
	}
	
}
