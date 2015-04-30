using UnityEngine;
using System.Collections;

//UPDATED

public class CrateController : MonoBehaviour 
{
    float groundRadius = 0.2f;              //radius of collision circle with crateRepeller
    bool crateStuck, activated = false;     //true when crate hits crateRepeller
    LayerMask box;                          //layer mask for collision detection (only things in this layer collide with repeller

    public Transform crateRepeller;         
    public GameObject boxTrigger, mask3;    //trigger to open the next room, mask of the next room
	public AudioSource roomopensound;
	bool roomplayed = false;


	// Use this for initialization
	void Start () 
    {
        int boxNum = gameObject.layer;
        box = 1 << boxNum;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("MaskRoomTwo").GetComponent<BoxCollider2D>().enabled == false && !activated)
        {
            Activate();
            activated = true;
        }

        crateStuck = Physics2D.OverlapCircle(crateRepeller.position, groundRadius, box.value);        //Null (false) if nothing in the layer is within groundRadius of crateRepeller

        if (crateStuck)
        {
            rigidbody2D.AddForce(new Vector2(3.0f, 0.0f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == boxTrigger.GetComponent<BoxCollider2D>())
        {
            mask3.GetComponent<Appear>().enabled = true;        //if the box hits the trigger, open the room
			if (!roomplayed)
			{
				roomopensound.pitch = Random.Range(.3f, 3f);
				roomopensound.Play();
				roomplayed = true;
			}
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
