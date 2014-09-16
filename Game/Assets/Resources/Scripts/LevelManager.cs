using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "Level1B") {
			PlayerPrefs.SetInt("level", 2);
		}
		else if (Application.loadedLevelName == "Level1R") {
			PlayerPrefs.SetInt("level", 1);
		}
		else if (Application.loadedLevelName == "Level2B") {
			PlayerPrefs.SetInt("level", 4);
		}
		else if (Application.loadedLevelName == "Level2R") {
			PlayerPrefs.SetInt("level", 3);
		}
		else {
			PlayerPrefs.SetInt("level", 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
