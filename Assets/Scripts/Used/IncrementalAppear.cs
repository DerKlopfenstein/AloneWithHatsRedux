using UnityEngine;
using System.Collections;

//UPDATED

public class IncrementalAppear : MonoBehaviour 
{
	Appear appearScript;

	void Start() 
    {
		appearScript = GetComponent<Appear>();
	}

	void Update() 
    {

	}

    void AddTransparency(float num)
    {
        appearScript.maximum -= num;            //reduces maximum value (inverted Appear)
                                                //in inspector, set Appear's min and max equal
    }
}
