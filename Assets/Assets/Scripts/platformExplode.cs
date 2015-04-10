using UnityEngine;
using System.Collections;

public class platformExplode : MonoBehaviour 
{
	Animator anim;
	public bool playerOn;
	public float delay = 2.0f;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		bool playerOn = false;
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		playerOn = true;
		anim.SetBool("PlayerOn", playerOn);
		StartCoroutine(DestroyPlatform());
	}

	IEnumerator DestroyPlatform()
	{
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
		GameObject textObject = (GameObject)Instantiate(Resources.Load("explode"),gameObject.transform.position, Quaternion.identity); 
	}

}
