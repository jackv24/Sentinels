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
		AudioClip MusicClip;
		MusicClip = (AudioClip)Resources.Load("Music/Menu_Music.mp3");
		Music.clip = MusicClip;

		//Finds the location of the button pressed sound effect and assigns it a variable
		Confirm = (AudioSource)gameObject.AddComponent ("AudioSource");
		AudioClip ConfirmClip;
		ConfirmClip = (AudioClip)Resources.Load("SFX/Menu_Confirm.wav");
		Confirm.clip = ConfirmClip;

		//Finds the location of the cancellation sound effect and assigns it a variable
		Cancel = (AudioSource)gameObject.AddComponent ("AudioSource");
		AudioClip CancelClip;
		CancelClip = (AudioClip)Resources.Load("SFX/Menu_Cancel.wav");
		Cancel.clip = CancelClip;

		audio.PlayOneShot (MMusic, 100f);
	}
	
	// Update is called once per frame
	void Update () 
	{

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
