using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class select_level : MonoBehaviour {

	public AudioSource audio;
	public AudioSource music;
	GameObject [] levels;
	GameObject [] locks;

	void Start()
	{
		int i = 0;
		levels = GameObject.FindGameObjectsWithTag ("level");
		locks =	GameObject.FindGameObjectsWithTag ("lock");
		Debug.Log ("stat = " + gameInfo.stat);
		while (i <= levels.Length - 1) 
		{
			
			if (System.Int32.Parse (levels [i].name) > gameInfo.stat)
			{
				levels [i].GetComponent<Button> ().enabled = false;

			} else {
				levels [i].GetComponent<Button> ().enabled = true;
			}
			i++;
		}
		foreach (var item in locks)
		{
			if (System.Int32.Parse (item.name) > gameInfo.stat)
			{
				item.gameObject.SetActive (true);


			} else
			{
				item.gameObject.SetActive (false);

			}
			
		}
			

			
		}




	


	public void lvl1 ()

	{		
		    audio.Play ();
			Application.LoadLevel (1);
		
	}
	public void lvl2 ()
	{
		audio.Play ();
		Application.LoadLevel (2);

	}
	public void lvl3 ()
	{
		audio.Play ();
		Application.LoadLevel (3);

	}
	public void lvl4 ()
	{
		audio.Play ();
		Application.LoadLevel (4);

	}
	public void lvl5 ()
	{
		audio.Play ();
		Application.LoadLevel (5);

	}
	public void lvl6 ()
	{
		audio.Play ();
		Application.LoadLevel (6);

	}

}
