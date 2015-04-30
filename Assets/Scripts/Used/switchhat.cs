using UnityEngine;
using System.Collections;

//UPDATED

public class switchhat : MonoBehaviour 
{

    public Sprite tophat;
	public Sprite strawhat;
	public Sprite minimi;
	public Sprite fungi;
	public Sprite fedora;
	public Sprite crown;
	public Sprite propeller;

    GameObject player;
	AudioSource hatfallsoff;
	AudioSource gethatback;
	
	private SpriteRenderer sprite;

	
	
	// Use this for initialization
	void Start ()
    {
        player = transform.parent.gameObject;
		
		foreach(AudioSource source in GetComponents<AudioSource>())
        {
            if (source.clip.name == "gethatback")
            {
                gethatback = source;
            }

            if(source.clip.name == "hatblowsoff 1")
            {
                hatfallsoff = source;
            }
        }
	}
	
	// Update is called once per frame
	void Update()
    {
		sprite = GetComponent<SpriteRenderer>();


		if (Input.GetKeyDown(KeyCode.T)) 
        {
			sprite.sprite = tophat;
		} 

        else if (Input.GetKeyDown(KeyCode.C)) 
        {
			sprite.sprite = strawhat;
		} 

        else if (Input.GetKeyDown (KeyCode.F)) 
        {
			sprite.sprite = fedora;
		} 

        else if (Input.GetKeyDown (KeyCode.Y)) 
        {
			sprite.sprite = minimi;
		} 

        else if (Input.GetKeyDown (KeyCode.M)) 
        {
			sprite.sprite = fungi;
		} 

        else if (Input.GetKeyDown (KeyCode.K)) 
        {
			sprite.sprite = crown;
		} 

        else if (Input.GetKeyDown(KeyCode.B)) 
        {
			sprite.sprite = propeller;
		}
	}

    void Escape()
    {
        if (transform.parent != null)
        {
            Vector2 initialPos = transform.parent.position;
            transform.parent = null;                                        //de-parent

            GetComponent<BoxCollider2D>().enabled = true;                   
            gameObject.AddComponent<Rigidbody2D>();                         //add physics components

            transform.position = initialPos + new Vector2(1.0f, 0.0f);
            rigidbody2D.AddForce(Vector2.right * 130, ForceMode2D.Force);   //place behind player and add backward force

			hatfallsoff.Play();
        }
        
    }

    void Return()
    {
        transform.parent = player.transform;                                //re-parent

        GetComponent<BoxCollider2D>().enabled = false;                      
        Object.Destroy(GetComponent<Rigidbody2D>());                        //remove physics components

        transform.localPosition = new Vector2(0.0f, 0.16f);
        transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);               //place back in correct position, scale, rotation

		gethatback.Play();
    }
}
