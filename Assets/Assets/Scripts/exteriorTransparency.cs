using UnityEngine;
using System.Collections;

public class exteriorTransparency : MonoBehaviour {
	public GameObject playerCam ;
	public bool zoomIn;
	public float inPosition;
	public bool zoomOut;
	public float outPosition;
	public bool tempZoom;
	//public bool scriptOverride;
	//private bool isOverriden;
	//public GameObject objectToOverride;
	//public exteriorTransparency referenceScript;

	// Use this for initialization
	void Start () {
		//referenceScript = objectToOverride.GetComponent<exteriorTransparency>();
		playerCam = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player")
		{
			Color color = GetComponent<Renderer> ().material.color;
			color.a = 0.0f;
			GetComponent<Renderer> ().material.color = color;


			
			StartCoroutine(cameraZoomInOut(0.0001f));
			
		
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{

		//if(scriptOverride ==true)
		//{
			//referenceScript.isOverriden = false;
		//}
		StartCoroutine(fadeIn(0.0001f));
		if (tempZoom ==true)
		{
			StartCoroutine(cameraZoomInOutReversed(0.0001f));
		}
		

	}

	IEnumerator fadeIn(float waitTime){
		
		
		Color color = GetComponent<Renderer> ().material.color;
		while (color.a <1.0f)
		{
			yield return new WaitForSeconds(waitTime);
			color.a += 0.05f;
			GetComponent<Renderer> ().material.color = color;
		}
	}
	IEnumerator cameraZoomInOut(float waitTime){
		
		if (zoomOut ==true)
		{
			//if(scriptOverride ==true)
			//{
			//	referenceScript.isOverriden = true;
			//}
			float zoomvalue = playerCam.transform.position.z;
			while (playerCam.transform.position.z > outPosition)
			{
				Vector3 tempVar = playerCam.transform.position;
				yield return new WaitForSeconds(waitTime);
				zoomvalue -= 0.10f;
				playerCam.transform.position =new Vector3(playerCam.transform.position.x,playerCam.transform.position.y,zoomvalue);
				

			}
		}
		if (zoomIn ==true)
		{
			//if(scriptOverride ==true)
			//{
				//referenceScript.isOverriden = true;
			//}
			float zoomvalue = playerCam.transform.position.z;
			while (playerCam.transform.position.z < inPosition)
			{
				Vector3 tempVar = playerCam.transform.position;
				yield return new WaitForSeconds(waitTime);
				zoomvalue+= 0.10f;
				playerCam.transform.position =new Vector3(playerCam.transform.position.x,playerCam.transform.position.y,zoomvalue);

			}
		}
	}



	IEnumerator cameraZoomInOutReversed(float waitTime){
		
		if (zoomOut ==false)
		{
			//if(scriptOverride ==true)
			//{
			//	referenceScript.isOverriden = true;
			//}
			float zoomvalue = playerCam.transform.position.z;
			while (playerCam.transform.position.z > outPosition)
			{
				Vector3 tempVar = playerCam.transform.position;
				yield return new WaitForSeconds(waitTime);
				zoomvalue -= 0.10f;
				playerCam.transform.position =new Vector3(playerCam.transform.position.x,playerCam.transform.position.y,zoomvalue);
				
				
			}
		}
		if (zoomIn ==false)
		{
			//if(scriptOverride ==true)
			//{
			//referenceScript.isOverriden = true;
			//}
			float zoomvalue = playerCam.transform.position.z;
			while (playerCam.transform.position.z < inPosition)
			{
				Vector3 tempVar = playerCam.transform.position;
				yield return new WaitForSeconds(waitTime);
				zoomvalue+= 0.10f;
				playerCam.transform.position =new Vector3(playerCam.transform.position.x,playerCam.transform.position.y,zoomvalue);
				
			}
		}
	}
}
