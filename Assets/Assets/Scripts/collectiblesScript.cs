using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class collectiblesScript : MonoBehaviour 
{
	public enum collectibleType { Key_Fragments, Coins, Scematics, Lives}; 
	public collectibleType col;


	void Start ()
	{

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player")
		{

			if (col == collectibleType.Key_Fragments)
			{
				PlatformerCharacter2D.main.keyAmount +=1;
			}
			else if (col == collectibleType.Coins)
			{
				PlatformerCharacter2D.main.coins +=1;
			}
			else if (col == collectibleType.Scematics)
			{
				PlatformerCharacter2D.main.scematics +=1;
			}
			else if (col == collectibleType.Lives)
			{
				PlatformerCharacter2D.main.lives +=1;
			}
			Destroy(gameObject);
			
		}
	}

}
