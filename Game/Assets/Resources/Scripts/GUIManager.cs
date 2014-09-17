using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

	float startTime;
	public List<string> textInfo = new List<string> ();
	public Texture talkingPerson;

	GUISkin skin;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		skin = (GUISkin)Resources.Load ("GUI/Beginning");
		if (Application.loadedLevel == 1)
		{
			textInfo.Add ("asdf");
			textInfo.Add ("ghjjkl");
			textInfo.Add ("asdf");
			textInfo.Add ("ghjjkl");
		}
		if (Application.loadedLevel == 2)
		{
			textInfo.Add ("asdf");
			textInfo.Add ("ghjjkl");
		}
		if (Application.loadedLevel == 3)
		{
			textInfo.Add ("asdf");
			textInfo.Add ("ghjjkl");
		}
		if (Application.loadedLevel == 4)
		{
			textInfo.Add ("asdf");
			textInfo.Add ("ghjjkl");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		skin.box.fontSize = Screen.height / 15;
		skin.box.contentOffset = new Vector2(0,Screen.height / 50);
		GUI.skin = skin;
		if (Time.time - startTime < 10) {
			GUI.Label(new Rect(Screen.height / 30,Screen.height / 30,Screen.height / 15,Screen.height / 15), talkingPerson);
			for (int i = 0; i < textInfo.Count; i++)
			{
				GUI.Box (new Rect(Screen.width / 8, Screen.height / textInfo.Count * i, Screen.width * 2 / 3, Screen.height / textInfo.Count), textInfo[i]);
			}
		}
	}
}

