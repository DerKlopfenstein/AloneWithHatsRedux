using UnityEngine;
using System.Collections;

//UPDATED

public class TitleScreen : MonoBehaviour 
{


	public AudioSource startsound;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.anyKey)
        {
			startsound.enabled = true;
            Application.LoadLevel("Main");
        }
	}
}
