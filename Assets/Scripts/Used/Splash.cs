using UnityEngine;
using System.Collections;

//UPDATED

public class Splash : MonoBehaviour 
{

	AudioSource enterSound;
	AudioSource exitSound;

	public AudioSource underwatermusic;
	public AudioSource normalmusic;

	// Use this for initialization
	void Start () 
    {
        foreach (AudioSource source in GetComponents<AudioSource>())
        {
            if (source.clip.name == "watersplash")
            {
                enterSound = source;
            }

            if (source.clip.name == "comingoutofwater")
            {
                exitSound = source;
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{

		if (other.tag == "Player") 
        {
			enterSound.Play();                  //on enter, mute normal music and unute underwater music
			normalmusic.mute = true;
			underwatermusic.mute = false;
		}


	}

	void OnTriggerExit2D(Collider2D other) 
	{

		if (other.tag == "Player") 
        {
            exitSound.Play();                  //on exit, mute underwater music and unute normal music
			underwatermusic.mute = true;
			normalmusic.mute=false;
		}

	}

}
