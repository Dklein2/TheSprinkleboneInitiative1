using UnityEngine;
using System.Collections;

public class pipToggle : MonoBehaviour {

	public Camera cam;
	public bool cameraOn;
	public bool cameraOff;
	public bool Container;

	// Use this for initialization
	void Start () {
		cam.enabled =false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (cameraOn ==true || Container == true)
			{
				cam.enabled =true;
				//cam.SetActive(true);
				Debug.Log ("cam on");
			}
			if (cameraOff ==true)
			{
				cam.enabled = false;
				//cam.SetActive(false);
				Debug.Log ("cam off");
			}
			
			
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (Container ==true)
			{
				Debug.Log ("cam off");
				cam.enabled= false;
				//cam.SetActive(false);
			}
			
			
		}
	}
}
