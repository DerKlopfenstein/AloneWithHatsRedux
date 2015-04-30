using UnityEngine;
using System.Collections;

//UPDATED

public class Appear : MonoBehaviour 
{
	public float minimum = 0.0f;        //starting value
	public float maximum = 1f;          //final value
	public float duration = 5.0f;       //duration of fade in (seconds)
    public SpriteRenderer sprite;

	private float startTime;


	void Start() 
    {
		startTime = Time.time;
	}

	void Update() 
    {
		float t = (Time.time - startTime) / duration;
        sprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));    //gradually interpolate the sprite alpha color from minimum to maximum, 
                                                                                        //speeding up from beginning and slowing towards the end
        if (sprite.color.a <= 0.2f)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;                   //turn inactive if faded enough
        }
	}
}
