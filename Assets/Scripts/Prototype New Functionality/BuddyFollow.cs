using UnityEngine;
using System.Collections;

public class BuddyFollow: MonoBehaviour 
{	
	bool facingRight = true;
	public float reaction = 1f;
	float jumpValue = 5.0f;
	bool grounded1 = false;
	bool grounded2 = false;
	float groundRadius = 0.2f;
	float jumpTimer = 0.0f;
	bool floating = false;
	float underwaterJump = 1f;
	Animator anim;

	Transform target;
	public float xhowcloseshouldtheybe = 2f;
	public float yhowcloseshouldtheybe = 5f;
	
	public float maxSpeed = 10f;
	public Transform groundCheck1;
	public Transform groundCheck2;
	public LayerMask whatIsGround;
	
	
	
	
	void Awake() 
	{
		
	}
	
	// Use this for initialization
	void Start () 
	{
		target = GameObject.Find("Player").transform;
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded1 = Physics2D.OverlapCircle(groundCheck1.position, groundRadius, whatIsGround, -20, 0);
		
		grounded2 = Physics2D.OverlapCircle(groundCheck2.position, groundRadius, whatIsGround, -20, 0);

		float xdistancefrom = target.position.x - transform.position.x;
		
		float move = 0f;
		if (xdistancefrom < 0)
			for (float i = 0f; i >= -1f; i-=.01f)
				move = i;
		else if (xdistancefrom > 0)
			for (float i = 0f; i <= 1f; i+=.01f)
				move = i;
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		
		
		if(move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
		
		if (grounded1 || grounded2)
		{
			jumpTimer = 0.0f;
		}
		else
		{
			jumpTimer += Time.deltaTime;
		}

		if (xdistancefrom < 0)
			for (float i = 0f; i >= -1f; i-=.01f)
				move = i;
		else if (xdistancefrom > 0)
			for (float i = 0f; i <= 1f; i+=.01f)
				move = i;
		
		if(Mathf.Abs (xdistancefrom) > xhowcloseshouldtheybe)
			//StartCoroutine(Chase ());
			rigidbody2D.velocity = Vector2.Lerp(rigidbody2D.velocity, new Vector2(move * maxSpeed, rigidbody2D.velocity.y), Time.deltaTime);
		else if (Mathf.Abs (xdistancefrom) < xhowcloseshouldtheybe)
			rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);

		Physics2D.IgnoreLayerCollision(8, 8);
		
	}
	
	void Update() 
	{
		bool above = Mathf.Abs(target.position.y - transform.position.y) > yhowcloseshouldtheybe;
		
		if((grounded1 || grounded2) && above)
		{
			rigidbody2D.AddForce (Vector2.up * (jumpValue/2),ForceMode2D.Impulse);
		}
		
	}

	void OnTriggerStay2D(Collider2D other) 
	{
		if (other.tag == "AntiGravity") 
		{
			
			rigidbody2D.gravityScale = .1f;
			floating = true;
			
			if(Input.GetButtonDown ("Jump")) 
			{
				rigidbody2D.AddForce(Vector2.up * underwaterJump, ForceMode2D.Impulse);
			}
			
		}
	}
	
	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "AntiGravity") 
		{
			
			rigidbody2D.gravityScale = 1f;
			floating = false;
			
		}
		
	}

	
	public IEnumerator Chase() {
		
		float xdistancefrom = target.position.x - transform.position.x;
		
		
		float move = 0f;
		
		if (xdistancefrom < 0)
			for (float i = 0f; i >= -1f; i-=.01f)
				move = i;
		else if (xdistancefrom > 0)
			for (float i = 0f; i <= 1f; i+=.01f)
				move = i;
		
		yield return new WaitForSeconds(0.5f);
		
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		
	}

	
	void Flip() 
	{
		facingRight = !facingRight;
		transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
	}
	
}









