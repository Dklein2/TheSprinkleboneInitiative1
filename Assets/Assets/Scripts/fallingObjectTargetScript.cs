using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class fallingObjectTargetScript : MonoBehaviour {

	// Use this for initialization
	public float solidDistance;
	public Transform other;
	public static int groundCheck;
	void Start () {
		groundCheck = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Color color = GetComponent<Renderer> ().material.color;

		float dist = Vector3.Distance(transform.position, other.position);
		if (dist < solidDistance) dist = solidDistance;
		color.a = solidDistance / dist;
		GetComponent<Renderer> ().material.color = color;
		StartCoroutine(grounded());
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "outsideGround")
		{

			groundCheck = 1;
			Debug.Log("I am ground"+ groundCheck);
		}
	}

	IEnumerator grounded()
	{
		yield return new WaitForSeconds(2f);
		if (groundCheck ==0)
		{
			//Broken
			Debug.Log("i am not ground" +groundCheck);
			int randomXpos = Random.Range(-10,11);
			Debug.Log(randomXpos);
			Vector3 playerPos = PlatformerCharacter2D.main.groundedPos;
			Vector3 spawnPos = new Vector3(randomXpos,0,0);
			spawnPos = (playerPos + spawnPos);
			GameObject newMeteor = (GameObject)Instantiate(Resources.Load("meteorStrike"),spawnPos, Quaternion.identity); 
			
			Destroy(transform.parent.gameObject);
		}
	}

}


/*
Color color = GetComponent<Renderer> ().material.color;
while (color.a <1.0f)
{
	yield return new WaitForSeconds(waitTime);
	color.a += 0.05f;
	GetComponent<Renderer> ().material.color = color;
}
*/