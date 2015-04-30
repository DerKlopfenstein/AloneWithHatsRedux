using UnityEngine;
using System.Collections;

//UPDATED

public class switchhat : MonoBehaviour 
{

	public Sprite tophat;
	public Sprite strawhat;
	public Sprite minimi;
	public Sprite mushroom;
	public Sprite fedora;
	public Sprite crown;
	public Sprite propeller;
	public Sprite sombrero;
	public Sprite fez;
	public Sprite pilotHat;
	public Sprite pinkFloppyHat;

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

		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update()
    {

	}

	void OnEnable() {
		
		GameControl.topHatKey += topHatsprite;
		GameControl.propHatKey += propHatsprite;
		GameControl.minimiKey += minimisprite;
		GameControl.crownKey += crownsprite;
		GameControl.mushroomKey += mushroomsprite;
		GameControl.fedoraKey += fedorasprite;
		GameControl.strawHatKey += strawHatsprite;
		GameControl.fezKey += fezsprite;
		GameControl.sombreroKey += sombrerosprite;
		GameControl.pinkFloppyHatKey += pinkFloppyHatsprite;
		GameControl.pilotHatKey += pilotHatsprite;
		
	}
	
	void OnDisable() {
		
		GameControl.topHatKey -= topHatsprite;
		GameControl.propHatKey -= propHatsprite;
		GameControl.minimiKey -= minimisprite;
		GameControl.crownKey -= crownsprite;
		GameControl.mushroomKey -= mushroomsprite;
		GameControl.fedoraKey -= fedorasprite;
		GameControl.strawHatKey -= strawHatsprite;
		GameControl.fezKey -= fezsprite;
		GameControl.sombreroKey -= sombrerosprite;
		GameControl.pinkFloppyHatKey -= pinkFloppyHatsprite;
		GameControl.pilotHatKey -= pilotHatsprite;
		
	}
	
	void topHatsprite() {
		sprite.sprite = tophat;
	}
	
	void propHatsprite() {
		sprite.sprite = propeller;
	}
	
	void crownsprite() {
		sprite.sprite = crown;
	}
	
	void minimisprite() {
		sprite.sprite = minimi;
	}
	
	void pilotHatsprite() {
		sprite.sprite = pilotHat;
	}
	
	void mushroomsprite() {
		sprite.sprite = mushroom;
	}
	
	void fedorasprite() {
		sprite.sprite = fedora;
	}
	
	void strawHatsprite() {
		sprite.sprite = strawhat;
	}
	
	void fezsprite() {
		sprite.sprite = fez;
	}
	
	void sombrerosprite() {
		sprite.sprite = sombrero;
	}
	
	void pinkFloppyHatsprite() {
		sprite.sprite = pinkFloppyHat;
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
