using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	Vector3 vel = new Vector3();
	public float speed = 10;
	public float jumpforce = 20;

	private Vector3 originalScale;

	private static int STATE_IDLE = 0;
	private static int STATE_WALK = 1;
	private static int STATE_JUMP = 2;

	private int state = STATE_IDLE;

	Rigidbody2D body;
	Animator animator;
	GameObject sprite;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		sprite = transform.FindChild("Sprite").gameObject;
		animator = sprite.GetComponent<Animator>();

		originalScale = sprite.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			vel.x = 1;
			sprite.transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			vel.x = -1;
			sprite.transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
		}

		if (Input.GetKeyUp(KeyCode.RightArrow) || (Input.GetKeyUp(KeyCode.LeftArrow)))
		{
			vel.x = 0;
		}

		body.velocity = new Vector2(vel.x * speed, body.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			body.velocity = new Vector2(body.velocity.x, body.velocity.y + jumpforce);
			state = STATE_JUMP;
			animator.SetTrigger("jump");
		}
		else if(state != STATE_JUMP)
		{
			noJump();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.tag == "UpperJaw")
		{
			// play sound?
			Application.LoadLevel("dentist");
		}

		if (state == STATE_JUMP)
		{
			state = STATE_WALK;
			animator.SetTrigger("run");
		}
	}

	void noJump()
	{
		if (state != STATE_WALK && body.velocity.magnitude > 0)
		{
			state = STATE_WALK;
			animator.SetTrigger("run");
		}
		else if (state != STATE_IDLE && body.velocity.magnitude == 0)
		{
			state = STATE_IDLE;
			animator.SetTrigger("idle");
		}
		
	}
}
