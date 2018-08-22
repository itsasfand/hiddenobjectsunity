using UnityEngine;
using System.Collections;

public class gameInfo : MonoBehaviour {

	public static int stat { get; set;}
	public static int hints { get; set; }
	void Start () {
		hints = 2;
		if (PlayerPrefs.GetInt ("levels_unlocked") == null || PlayerPrefs.GetInt ("levels_unlocked") < 1) {
			stat = 1;
		} else {

			stat = PlayerPrefs.GetInt ("levels_unlocked");
			
		}

	}


}
