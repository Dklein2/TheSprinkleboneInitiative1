using UnityEngine;
using System.Collections;

public class respawnPlatform : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(RestorePlatform());
	}
		


	IEnumerator RestorePlatform()
	{
		yield return new WaitForSeconds(4);
		Destroy(gameObject);
		GameObject newPlatform = (GameObject)Instantiate(Resources.Load("explodingPlatform"),gameObject.transform.position, Quaternion.identity); 
	}

}
