using UnityEngine;
using System.Collections;

public class timedDestroy : MonoBehaviour 
{
	public int timer = 4;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(RestorePlatform());
	}
		


	IEnumerator RestorePlatform()
	{
		yield return new WaitForSeconds(timer);
		Destroy(gameObject);
		}

}
