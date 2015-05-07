using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class fallingObjectController : MonoBehaviour {

	public float speed;
	public Transform target;


	private int lives;
	private int spawnPoint;
	private GameObject checkPoint;
	public GameObject player ;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("PlayerCharacter");
		speed = Random.Range(8,18);
	}
	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;
		if (target != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		 
		if (other.gameObject.tag == "Target")
		{
			Debug.Log ("hit target");
			Destroy(other.gameObject);
			Destroy(gameObject.transform.parent.gameObject);
			int randomXpos = Random.Range(-10,11);
			Debug.Log(randomXpos);
			Vector3 playerPos = PlatformerCharacter2D.main.groundedPos;
			Vector3 spawnPos = new Vector3(randomXpos,0,0);
			spawnPos = (playerPos + spawnPos);
			GameObject newMeteor = (GameObject)Instantiate(Resources.Load("groundedCheck"),spawnPos, Quaternion.identity);
		}
		else if (other.gameObject.tag == "Player")
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
		else{
			Debug.Log ("unknown");
		}
			GameObject textObject = (GameObject)Instantiate(Resources.Load("meteorExplode"),gameObject.transform.position, Quaternion.identity);
		
	}
}
