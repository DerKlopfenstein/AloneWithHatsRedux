using UnityEngine;
using System.Collections;

//UPDATED

public class WindSoundTrigger : MonoBehaviour 
{
	private AudioSource wind;

	// Use this for initialization
	void Start () 
    {
		wind = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			wind.Play();
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			wind.Pause();
		}
	}

}
