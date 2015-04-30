using UnityEngine;
using System.Collections;

//UPDATED

public class SwitchWeap : MonoBehaviour 
{
    public Sprite fish, spear, sword, bow, axe;
	public AudioClip fishsound, swordsound, spearsound, bowsound, axesound;

	private AudioSource audioSource;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () 
    {
        sprite = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.Q))
        {
            sprite.sprite = fish;
			audioSource.clip = fishsound;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            sprite.sprite = spear;
			audioSource.clip = spearsound;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            sprite.sprite = sword;
			audioSource.clip = swordsound;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            sprite.sprite = axe;
			audioSource.clip = axesound;
        }
	}
}
