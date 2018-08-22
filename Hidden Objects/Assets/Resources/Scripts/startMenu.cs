using UnityEngine;
using System.Collections;

public class startMenu : MonoBehaviour {

	public AudioSource background_music;
	public AudioSource click;
	void Update()
	{
		if (!background_music.isPlaying) {
			background_music.Play ();
		}
	}

	public void start_game()
	{
		click.Play ();	
		Application.LoadLevel (7);

	}
	public void exit()
	{
		click.Play ();	
		Application.Quit ();
	}

	

}
