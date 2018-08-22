using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public Canvas options;
	public GameObject GM;
	public AudioSource click;
	void Start () {
		options = GameObject.FindGameObjectWithTag ("Options").GetComponent<Canvas>();
		options.gameObject.SetActive (false);
	}



	public void show_options()
	{
		Debug.Log ("Click");
		options.gameObject.SetActive(true);
		Time.timeScale = 0;
		GM.SetActive (false);
		click.Play ();
	}

	public void resume()
	{
		options.gameObject.SetActive (false);
		Time.timeScale = 1;
		GM.SetActive (true);
		click.Play ();
	}
	 public void restart()
	{
		Application.LoadLevel (Application.loadedLevelName);
		click.Play ();
	}
	public void mainmenu()
	{
		Application.LoadLevel (0);
		click.Play ();
	}
	public void selectLevel()
	{
		Application.LoadLevel (7);
		click.Play ();
	}
	public	void hint ()
	{
		if (gameInfo.hints > 0) {
			GameObject[] objects_find = GameObject.FindGameObjectsWithTag ("object");
			int r =	Random.Range (0, objects_find.Length-1);
			iTween.ShakePosition (objects_find [r],new Vector3(0.1f,0,0), 5f);
			gameInfo.hints--;
		}
	}
}
