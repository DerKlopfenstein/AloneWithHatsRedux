using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberRetainer : MonoBehaviour 
{

    float number;
    public Text phrase;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(transform.gameObject);
        phrase = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {

	
	}

    void SaveNumber(float num)
    {
        number = num;
    }

    void WritePhrase()
    {
        phrase.text = "Odd, that should have ended the game. Perhaps you are missing something.";
    }
}
