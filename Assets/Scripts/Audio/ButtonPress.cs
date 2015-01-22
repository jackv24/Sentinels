using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour 
{
	public AudioSource Music;
	public AudioSource Confirm;
	public AudioSource Cancel;
	public AudioClip MMusic;
	public AudioClip LMB;
	public AudioClip Esc;

	// Use this for initialization
	void Start () 
	{
		//Finds the location of the menu music and assigns it a variable
		Music = (AudioSource)gameObject.AddComponent ("AudioSource");
        Music.clip = MMusic;

		//Finds the location of the button pressed sound effect and assigns it a variable
		Confirm = (AudioSource)gameObject.AddComponent ("AudioSource");
        Confirm.clip = LMB;

		//Finds the location of the cancellation sound effect and assigns it a variable
		Cancel = (AudioSource)gameObject.AddComponent ("AudioSource");
        Cancel.clip = Esc;

		audio.PlayOneShot (MMusic, 100f);
	}
	
	// Update is called once per frame
	void Update () 
	{
        Music.volume = Preferences.instance.musicVolume * Preferences.instance.masterVolume;
        Confirm.volume = Preferences.instance.soundVolume * Preferences.instance.masterVolume;
        Cancel.volume = Preferences.instance.soundVolume * Preferences.instance.masterVolume;

	}

	void OnGUI()
	{
		//Plays the sound effect when the left mouse button is pressed
		if (Input.GetMouseButtonDown (0))
		{
			audio.PlayOneShot (LMB, 20f);
		}

		//Plays the sound effect when the escape key is pressed
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			audio.PlayOneShot (Esc, 20f);
		}
	}
}
