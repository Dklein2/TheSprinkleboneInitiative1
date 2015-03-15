using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour 
{
	public float maxSpeed = 10.0f;
	public float jumpHeight = 5.00f;
	bool facingRight = true;
	bool jumpsLeft = true;
	Animator anim;


	// Use this for initialization
	void Start () 
	{
		//anim = GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float move = Input.GetAxis("Horizontal");
		//anim.SetFloat("Speed",Mathf.Abs (move));
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0 && !facingRight)
		{
			FlipFacing();
		}
		else if (move < 0 && facingRight)
		{
			FlipFacing();
		}

		if (Input.GetKeyUp(KeyCode.Space)==true && jumpsLeft ==true)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			jumpsLeft = false;
		}
	}

	void FlipFacing()
	{
		facingRight = !facingRight;
		Vector3 charScale = transform.localScale;
		charScale.x *= -1;
		transform.localScale = charScale;

	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (jumpsLeft ==false && col.gameObject.tag == "Ground")
		{
			jumpsLeft = true;
		}

		if (col.gameObject.tag == "Elevator")
		{
			jumpsLeft = true;
			anim = col.gameObject.GetComponent<Animator>();
			anim.SetBool("playerCol",true);
		}
		else
		{

			anim = GameObject.FindGameObjectWithTag("Elevator").GetComponent<Animator>();
			anim.SetBool("playerCol", false);
		}
	}

}
