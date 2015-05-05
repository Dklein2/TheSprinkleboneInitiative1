using UnityEngine;
using System.Collections;

public class exteriorTransparency : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		Color color = GetComponent<Renderer> ().material.color;
		color.a = 0.0f;
		GetComponent<Renderer> ().material.color = color;
	}

	void OnTriggerExit2D(Collider2D other) 
	{

		StartCoroutine(ParseTime(0.0001f));
		

	}

	IEnumerator ParseTime(float waitTime){


		Color color = GetComponent<Renderer> ().material.color;
		while (color.a <1.0f)
		{
			yield return new WaitForSeconds(waitTime);
			color.a += 0.05f;
			GetComponent<Renderer> ().material.color = color;
		}
	}
}
