using UnityEngine;
using System.Collections;

//UPDATED

public class SwordController : MonoBehaviour 
{
    bool swinging = false;
    bool reachedApex = false;
    float elapsTime = 0.0f;
    float curr, apex;
    Transform t;

	// Use this for initialization
	void Start () 
    {
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (swinging && elapsTime < 1 && !reachedApex)                                  //Swing for 1 second, or until reaching apex point
        {
            elapsTime += (Time.deltaTime * 4);      //4*deltaTime added
            
        }
        else if(swinging)                                                               //Retract same distance
        {
            reachedApex = true;
            elapsTime -= (Time.deltaTime * 4);      //4*deltaTime subtracted
        }

        if (reachedApex && elapsTime <= 0)                                              //Stop swinging, fix position
        {
            swinging = false;
            reachedApex = false;
            t.localPosition = new Vector3(curr, t.localPosition.y, t.localPosition.z);
        }

        if (swinging)                                                                   //Lerp by time between curr and apex
        {
            t.localPosition = new Vector3(Mathf.Lerp(curr, apex, elapsTime), t.localPosition.y, t.localPosition.z);
        }
	}

    void SwingSword()
    {
        if (!swinging)
        {
            swinging = true;
            elapsTime = 0.0f;
            curr = t.localPosition.x;
            apex = t.localPosition.x + 0.2f;
        }
    }
}
