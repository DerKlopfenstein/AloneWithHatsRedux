using UnityEngine;
using System.Collections;

//UPDATED

public class TargetController : MonoBehaviour 
{
    bool activated = false;
    public GameObject weapon;
	public AudioSource breakingsound;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (GameObject.Find("MaskRoomSix").GetComponent<BoxCollider2D>().enabled == false && !activated)
        {
            Activate();
            activated = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon")
        {
			breakingsound.Play ();
            other.transform.parent.gameObject.SendMessage("CompleteObjective");
            gameObject.SetActive(false);
        }
    }

    void Activate()
    {
        GetComponent<SpriteRenderer>().enabled = true;          //Make visible
        GetComponent<BoxCollider2D>().enabled = true;           //Add physics components
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().gravityScale = 0.5f;        //Set gravity
    }
}
