using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Animator playerAnimator;
	[SerializeField]
	float speed = 10;
	Vector2 inputPlayer;
	bool isFacingRight;
	Rigidbody2D playerRigidbody;
	public bool levelUp;
	public bool enterIgloo;
	public bool snowed;
	[HideInInspector]
	public bool pleaseSpawn;
	[HideInInspector]
	public bool wellDone;
	[HideInInspector]
	public bool coin;
	[HideInInspector]
	public bool crystal;
	public bool exitIgloo;
	[HideInInspector]
	public bool extraLife;

	void Start()
    {
		playerAnimator = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody2D>();
		isFacingRight = true;
		levelUp = false;
		enterIgloo = false;
		snowed = false;
		pleaseSpawn = false;
		wellDone = false;
		coin = false;
		crystal = false;
		exitIgloo = false;
		extraLife = false;
	}

    void Update()
    {
		inputPlayer = new Vector2(Input.GetAxis("Horizontal"), 0);
		Move();
		Flip();
		Animate();
    }

	public void Move()
	{
		transform.Translate(inputPlayer * speed * Time.deltaTime);
		if (Input.GetKeyDown("space"))
		{
			
			playerRigidbody.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
		}
	}

	public void Flip()
	{
		if(inputPlayer.x > 0 && !isFacingRight || inputPlayer.x < 0 && isFacingRight)
		{
			isFacingRight = !isFacingRight;
			Vector3 mirror = transform.localScale;
			mirror.x *= -1;
			transform.localScale = mirror;

		}

	}

	public void Animate()
	{
		playerAnimator.SetFloat("speed", inputPlayer.x);
		if (Input.GetKeyDown("space"))
		{
			playerAnimator.SetTrigger("jump");
		}
		if (Input.GetKeyDown("s"))
		{
			playerAnimator.SetTrigger("slide");
		}
		if(snowed == true)
		{
			playerAnimator.SetTrigger("dead");
		}
	}

	private void OnTriggerEnter2D(Collider2D othercollider)
	{
		if(othercollider.tag == "Crystal")
		{
			crystal = true;
			Destroy(othercollider.gameObject);
		}
		if(othercollider.tag == "Finish")
		{
			levelUp = true;
		}
		if(othercollider.tag == "Igloo")
		{
			enterIgloo = true;
		}
		if(othercollider.tag == "SnowMan")
		{
			snowed = true;
		}
		if (othercollider.tag == "GameFinish")
		{
			wellDone = true;
		}
		if (othercollider.tag == "Coin")
		{
			coin = true;
			Destroy(othercollider.gameObject);
		}
		if (othercollider.tag == "ExitIgloo")
		{
			exitIgloo = true;
		}
		if (othercollider.tag == "ExtraLife")
		{
			extraLife = true;
			Destroy(othercollider.gameObject);
		}
	}
}
