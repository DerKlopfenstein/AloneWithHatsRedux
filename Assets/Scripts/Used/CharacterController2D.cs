using UnityEngine;
using System.Collections;

public class CharacterController2D: MonoBehaviour 
{
	bool facingRight = true;
	
	float jumpValue = 5.0f;
	float increaseRate = 5.0f;
	bool grounded1 = false;
	bool grounded2 = false;
	float groundRadius = 0.2f;
    float jumpTimer = 0.0f;
	bool floating = false;
	float underwaterJump = 1f;
    GameObject mask2, maskTower1, mask4, maskHall, mask5, maskTower2, mask6, mask7, maskTread, maskFinal;
    GameObject crate, crate2;
    Animator anim;
    bool winner = false, crate2ready = false;
    bool rms1 = false, rms2 = false, rms3 = false, rms4 = false, rms5 = false, rms6 = false, rms7 = false, rms8 = false;
    float winTime;

    public float maxSpeed = 10f;
    public Transform groundCheck1;
    public Transform groundCheck2;
    public LayerMask whatIsGround;
    public GameObject triggerRm1, triggerRm3, triggerWater1, triggerBoulder, triggerHall, triggerRm5, triggerTower2, triggerRm7, triggerTreadmill, triggerRm8, hatTrigger, winTrigger;
    public GameObject boulder, hat;
	public AudioSource jumpsound;
	public AudioSource swimsound;
	public AudioSource swordsound;
	public AudioSource roomopen;
	public AudioSource winsound;



	void Awake() 
    {

	}
	
	// Use this for initialization
	void Start () 
    {
        crate = GameObject.Find("Crate");
        crate2 = GameObject.Find("Crate2");
        mask2 = GameObject.Find("MaskRoomTwo");
        maskTower1 = GameObject.Find("MaskTowerOne");
        mask4 = GameObject.Find("MaskRoomFour");
        maskHall = GameObject.Find("MaskHall");
        mask5 = GameObject.Find("MaskRoomFive");
        maskTower2 = GameObject.Find("MaskTowerTwo");
        mask6 = GameObject.Find("MaskRoomSix");
        mask7 = GameObject.Find("MaskRoomSeven");
        maskTread = GameObject.Find("MaskTreadmill");
        maskFinal = GameObject.Find("MaskFinal");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
		grounded1 = Physics2D.OverlapCircle(groundCheck1.position, groundRadius, whatIsGround, -20, 0);
		
		grounded2 = Physics2D.OverlapCircle(groundCheck2.position, groundRadius, whatIsGround, -20, 0);
        //PROBLEM WITH MAKING WALLS IN THE BACKGROUND: TOPS OF WALLS WON'T REGISTER AS JUMPABLE
        //SOLUTION: CREATE PLATFORMS AT Z=0 FOR EVERY SURFACE THE PLAYER WILL LAND ON
		

		float move = Input.GetAxis("Horizontal");
        if (Mathf.Abs(move) > 0)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
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
		
	}
	
	void Update() 
    {
		Jump();

        if (Input.GetKeyDown(KeyCode.P))
        {
            SwordController sword = GetComponentInChildren<SwordController>();
            sword.SendMessage("SwingSword");
			swordsound.Play();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hat.transform.parent == this)
            {
                hat.SendMessage("Escape");
            }
        }
        if (winner)
        {
            winTime += Time.deltaTime;
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == boulder && !(boulder.GetComponent<BoulderController>().IsStopped()))
        {
            transform.position = new Vector2(3.7f, -2.6f);
        }

        if (other.gameObject == hat)
        {
            hat.SendMessage("Return");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other == triggerRm3.GetComponent<BoxCollider2D>())
        {
            maskTower1.GetComponent<Appear>().enabled = true;
			if (rms2 == false) 
			{
				roomopen.pitch = Random.Range(.3f, 3f);
				roomopen.Play ();
				rms2 = true;
			}
        }

        if (other == triggerWater1.GetComponent<BoxCollider2D>())
        {
            mask4.GetComponent<Appear>().enabled = true;
			if (rms3 == false) 
			{
				roomopen.pitch = Random.Range(.3f, 3f);
				roomopen.Play ();
				rms3 = true;
			}
        }

        if (other == triggerBoulder.GetComponent<BoxCollider2D>())
        {
            maskHall.GetComponent<Appear>().enabled = true;
            boulder.SetActive(true);
			if (rms4 == false) 
			{
				roomopen.pitch = Random.Range(.3f, 3f);
				roomopen.Play ();
				rms4 = true;
			}
        }

        if (other == triggerHall.GetComponent<BoxCollider2D>())
        {
            mask5.GetComponent<Appear>().enabled = true;
			if (rms5 == false) 
			{
				roomopen.pitch = Random.Range(.3f, 3f);
				roomopen.Play ();
				rms5 = true;
			}
        }

        if (other == triggerRm5.GetComponent<BoxCollider2D>())
        {
            maskTower2.GetComponent<Appear>().enabled = true;
			if (rms6 == false) 
			{
				roomopen.pitch = Random.Range(.3f, 3f);
				roomopen.Play ();
				rms6 = true;
			}
        }

        if (other == triggerTower2.GetComponent<BoxCollider2D>() && !mask7.GetComponent<Appear>().enabled)
        {
            mask6.GetComponent<Appear>().enabled = true;
            transform.Find("PointyBit").gameObject.GetComponent<BoxCollider2D>().enabled = true;
			if (rms7 == false) 
			{
				roomopen.pitch = Random.Range(.3f, 3f);
				roomopen.Play ();
				rms7 = true;
			}
        }

        if (other == triggerRm7.GetComponent<BoxCollider2D>() && (grounded1 || grounded2))
        {
            maskTread.SendMessage("AddTransparency", 0.35f);
            
        }

        if (other == triggerRm8.GetComponent<BoxCollider2D>())
        {
            maskFinal.GetComponent<Appear>().enabled = true;
			if (rms8 == false) 
			{
				roomopen.pitch = Random.Range(.3f, 3f);
				roomopen.Play ();
				rms8 = true;
			}
        }

        if (other == hatTrigger.GetComponent<BoxCollider2D>() && hat.transform.position.x > transform.position.x - 0.15)
        {
            hat.SendMessage("Escape");
        }

        if (other == winTrigger.GetComponent<BoxCollider2D>() && !winner)
        {
			winsound.Play();
            Application.LoadLevel("Credits");

        }
    }

	void OnTriggerStay2D(Collider2D other) 
    {
		if (other.tag == "AntiGravity") 
        {
			
			rigidbody2D.gravityScale = .1f;
			floating = true;

            if (Input.GetKeyDown(KeyCode.J)) 
            {
				rigidbody2D.AddForce(Vector2.up * underwaterJump, ForceMode2D.Impulse);
				swimsound.Play();
			}
			
		}

        if(other == triggerTreadmill.GetComponent<BoxCollider2D>())
        {
            rigidbody2D.AddForce(Vector2.right * 130, ForceMode2D.Force);
        }
		
		
	}
	
	void OnTriggerExit2D(Collider2D other) 
    {
        if (other == triggerRm1.GetComponent<BoxCollider2D>() && !crate.GetComponent<BoxCollider2D>().enabled
                && mask2.GetComponent<BoxCollider2D>().enabled == false)
        {
            crate.GetComponent<BoxCollider2D>().enabled = true;
            crate.transform.position = new Vector2(crate.transform.position.x, -2.3f);
        }

        if (other == triggerTower2.GetComponent<BoxCollider2D>() && crate2.GetComponent<BoxCollider2D>().enabled == false)
        {
            crate2ready = true;
        }

		if (other.tag == "AntiGravity") 
        {
			
			rigidbody2D.gravityScale = 1f;
			floating = false;
			
		}

        if (other == winTrigger.GetComponent<BoxCollider2D>() && !winner)
        {
            winner = true;
        }
        
		
		
	}

    void CompleteObjective()
    {
        mask7.GetComponent<Appear>().enabled = true;
        transform.Find("PointyBit").GetComponent<BoxCollider2D>().enabled = false;
    }

	
	void Jump()
	{
        
        if ((grounded1 || grounded2) && Input.GetButtonDown("Jump") && !floating)
        {
			rigidbody2D.AddForce(Vector2.up * jumpValue,ForceMode2D.Impulse);
            jumpsound.Play();

            if (rms1 == false)
            {
                mask2.GetComponent<Appear>().enabled = true;
                roomopen.pitch = Random.Range(.3f, 3f);
                roomopen.Play();
                rms1 = true;
            }
		}

        if (Input.GetButton("Jump") && (jumpTimer < 0.3 && rigidbody2D.velocity.y > 0) && !floating)
        {
		    rigidbody2D.AddForce(Vector2.up * increaseRate,ForceMode2D.Force);
		}
		
	}
	
	void Flip() 
    {
		facingRight = !facingRight;
		transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
	}
	
}