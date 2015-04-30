using UnityEngine;
using System.Collections;

//UPDATED

public class BoulderController : MonoBehaviour 
{
    float startSpeed = 2.0f;
    float increaseSpeed = 3.5f;
    float currSpeed = 1.0f;
    bool flat = true;
    bool stopped = false;
    bool landed = false;
    bool becomeDumb = false;
    Animator anim;
	AudioSource rollsound;
	AudioSource stopsound;
    

    public GameObject hallTrigger;
    public GameObject stopTrigger;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Boulder"), LayerMask.NameToLayer("Masks"));

        foreach(AudioSource source in GetComponents<AudioSource>())
        {
            if (source.clip.name == "boulderroll")
            {
                rollsound = source;
            }

            if(source.clip.name == "boulderclank")
            {
                stopsound = source;
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!landed)                                                    //If not ready to roll
        {
            rigidbody2D.velocity = new Vector2(0.0f, rigidbody2D.velocity.y);
        }

        else if(!stopped && landed)                                     //If boulder hits the ground
        {
            if ((flat && currSpeed < startSpeed) || (!flat && currSpeed < increaseSpeed))
            {
                currSpeed += 0.1f;
            }

            rigidbody2D.velocity = new Vector2(currSpeed, rigidbody2D.velocity.y);
        }

        else if (stopped && !becomeDumb)                                               //If boulder hits end trigger
        {
            rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
            anim.SetBool("Stopped", true);
            becomeDumb = true;
        }

        else if(becomeDumb)
        {
 
        }
	}

    void OnCollisionEnter2D(Collision2D other)                          //If boulder collides with anything
    {
        landed = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == hallTrigger.GetComponent<BoxCollider2D>())         //Slope trigger
        {
            flat = false;
        }

        if (other == stopTrigger.GetComponent<BoxCollider2D>())         //Stop trigger
        {
            stopped = true;
			rollsound.mute = true;
			stopsound.Play();
        }
    }

    public bool IsStopped()
    {
        return stopped;
    }
}
