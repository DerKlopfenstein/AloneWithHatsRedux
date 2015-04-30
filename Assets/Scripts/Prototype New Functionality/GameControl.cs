using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	// delegates for each hat

	public delegate void topHat();
	public static event topHat topHatKey;

	public delegate void propHat();
	public static event propHat propHatKey;

	public delegate void minimi();
	public static event minimi minimiKey;

	public delegate void crown();
	public static event crown crownKey;
	
	public delegate void mushroom();
	public static event mushroom mushroomKey;

	public delegate void fedora();
	public static event fedora fedoraKey;

	public delegate void strawHat();
	public static event strawHat strawHatKey;

	public delegate void fez();
	public static event fez fezKey;

	public delegate void sombrero();
	public static event sombrero sombreroKey;

	public delegate void pinkFloppyHat();
	public static event pinkFloppyHat pinkFloppyHatKey;

	public delegate void pilotHat();
	public static event pilotHat pilotHatKey;

	private static GameControl _instance;
	
	public static GameControl instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = Object.FindObjectOfType<GameControl>();
				DontDestroyOnLoad(_instance);
			}
			return _instance;
		}
	}

	void Awake()
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			// There is already an instance! Destroy self!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	
	void Start () {
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.R) && (topHatKey != null))
			topHatKey();

		if (Input.GetKeyDown(KeyCode.T) && (propHatKey != null))
			propHatKey();

		if (Input.GetKeyDown(KeyCode.Y) && (minimiKey != null))
			minimiKey();

		if (Input.GetKeyDown(KeyCode.U) && (crownKey != null))
			crownKey();

		if (Input.GetKeyDown(KeyCode.I) && (mushroomKey != null))
			mushroomKey();

		if (Input.GetKeyDown(KeyCode.O) && (fedoraKey != null))
			fedoraKey();

		if (Input.GetKeyDown(KeyCode.F) && (strawHatKey != null))
			strawHatKey();

		if (Input.GetKeyDown(KeyCode.G) && (fezKey != null))
			fezKey();

		if (Input.GetKeyDown(KeyCode.H) && (sombreroKey != null))
			sombreroKey();

		if (Input.GetKeyDown(KeyCode.J) && (pinkFloppyHatKey != null))
			pinkFloppyHatKey();

		if (Input.GetKeyDown(KeyCode.K) && (pilotHatKey != null))
			pilotHatKey();
	}

}
