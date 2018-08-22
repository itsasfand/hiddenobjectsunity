using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class choose_object : MonoBehaviour {
	public AudioSource background_music;
	public AudioSource finish;
	public int objects_value;
	public List<GameObject> object_find;
	public Canvas Screen;
	public AudioSource audio;
	public Camera camera;
	public Canvas Finish;
	public Text time_con;
	public Text Time_rem;
	float start_time;
	float end_time;
	public float timeLeft;
	public Canvas Lose_canvas;
	public AudioSource end_sound;
	public int play_count;
	void Start () {

		play_count = 0;
		Debug.Log (gameInfo.stat);
		Time.timeScale = 1;
		Finish = GameObject.FindGameObjectWithTag ("end").GetComponent<Canvas>();
		Lose_canvas.gameObject.SetActive (false);
		Finish.gameObject.SetActive (false);
		start_time = Time.time;
		if (objects_value > 7) {
			objects_to_find (7);
			AddSpriteToInventory (7);
		} else
		{
			objects_to_find (7);
			AddSpriteToInventory (7);
		}

	}


	void Update () {
		//Timer
		timeLeft -= Time.deltaTime;
		Time_rem.text = Mathf.RoundToInt (timeLeft).ToString()+" s"; 
		if ( timeLeft < 0 )
		{
			
			if (!end_sound.isPlaying && play_count==0) {
				play_count++;
				end_sound.Play ();

			}

			Lose ();

			Debug.Log("TimeEnd");

		}

		
		check_for_hit ();

		if (object_find.Count==0)
		{
			end_time = Time.time;

			Win ();
			Time.timeScale = 0;
		}
	}


	void check_for_hit()
	{
		RaycastHit hit;

		for (int i = 0; i < Input.touchCount; i++) 
		{

			Ray ray = camera.ScreenPointToRay(Input.GetTouch(i).position);
			if (Physics.Raycast(ray,out hit)  && hit.transform.tag =="object") 
			{
				GameObject found_object = hit.transform.gameObject;
				check_for_find_objects (ref found_object);

			}
			
		}

	}

	void check_for_find_objects(ref GameObject found_object)
	{

		if (object_find.Contains (found_object)) 
		{
			audio.Play ();
			Inventory (found_object);
			object_find.Remove (found_object);
			Destroy (found_object);

			if (objects_value>7) {
				
				UpdateObjectFind ();
				objects_value--;
			}

		}
	}

	void Win()
	{
		if (!finish.isPlaying && play_count==0) {
			play_count++;
			finish.Play ();

		}
		background_music.Stop ();
		float finish_time = end_time - start_time;
		Finish.gameObject.SetActive (true);
		time_con.text = finish_time.ToString();
		Screen.gameObject.SetActive (false);
		PlayerPrefs.SetInt ("levels_unlocked",System.Int32.Parse (Application.loadedLevelName)+1);
		
	}
	void Lose()
	{
		
		background_music.Stop ();

		Time.timeScale = 0;
		Lose_canvas.gameObject.SetActive (true);
		Screen.gameObject.SetActive (false);

	}
	void Inventory(GameObject found_object)
	{
		GameObject [] invent = GameObject.FindGameObjectsWithTag ("inventory item");
	
		foreach (var item in invent) {

			if (item.GetComponent<Image> ().sprite ==null) {
				continue;
			}

			if (item.GetComponent<Image> ().sprite.name == found_object.name) {
				
				item.GetComponent<Image> ().sprite =null;

			}
			
			
		
			
		}
	}

	void objects_to_find(int max)
	{
		
		GameObject  [] objects_on_sc = GameObject.FindGameObjectsWithTag("sprite");
		Debug.Log (objects_on_sc.Length);
		for (int i = 0; i < max; i++) {
			
		
			int j = Random.Range (0,objects_on_sc.Length-1);
			if (!object_find.Contains (objects_on_sc [j])) {
				object_find.Add (objects_on_sc [j]);
				object_find [i].tag = "object";

			} else 
			{
				i--;
			}
		} 
			
	}

	void AddSpriteToInventory(int max)

	{
		
		GameObject[] invent = GameObject.FindGameObjectsWithTag ("inventory item");
		for (int i = 0; i < max; i++) 
		{
			
			invent [i].GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Sprites/objects/"+object_find[i].name); 
	

		}
	}


	void UpdateSprite(GameObject new_object)
	{
		GameObject [] invent = GameObject.FindGameObjectsWithTag ("inventory item");


		foreach (var item in invent)
		{
			
			if (item.GetComponent<Image> ().sprite ==null) 
			{

				item.GetComponent<Image> ().sprite = Resources.Load<Sprite>("Sprites/objects/"+new_object.name);

			}

		}
	}

	void UpdateObjectFind()
	{

		GameObject  [] objects_on_sc = GameObject.FindGameObjectsWithTag("sprite");
		int item = Random.Range (0, objects_on_sc.Length );

		if (object_find.Count < 7 && !object_find.Contains(objects_on_sc[item])) 
		{
			objects_on_sc [item].tag = "object";
			object_find.Add(objects_on_sc [item]);
			Debug.Log (object_find.Count);
			UpdateSprite (objects_on_sc [item]);
			
		}

	}


}
