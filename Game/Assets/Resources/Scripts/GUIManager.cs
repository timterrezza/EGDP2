using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour {

	float startTime;
	public List<string> textInfo = new List<string> ();

	public Texture altPawnIcon;
	public Texture altKingIcon;
	public Texture PawnIcon;
	public Texture KingIcon;

	bool pi = false;
	bool ki = false;

	GUISkin skin;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		skin = (GUISkin)Resources.Load ("GUI/Beginning");
		if (Application.loadedLevel == 1)
		{
			textInfo.Add ("Hey, Red, why’d you call that hit on us?");
			textInfo.Add ("It was his fault- shouldn’t have got a bounty put on his head.");
			textInfo.Add ("I don’t care what they offered, you should have known better.");
			textInfo.Add ("It’s just business, Blue, don’t take it so personally.");
			textInfo.Add ("You made it personal when you attacked my comrade.");
			textInfo.Add ("Well what’re you going to do about it?");
			textInfo.Add ("Send your head on a plate to your boss.");
			textInfo.Add ("Not a chance- you’ll never sneak past all my minions undetected!");

			pi = true;
			ki = false;

		}
		if (Application.loadedLevel == 2)
		{
			textInfo.Add ("asdf");
			textInfo.Add ("ghjjkl");

			pi = false;
			ki = true;
		}
		if (Application.loadedLevel == 3)
		{
			textInfo.Add ("asdf");
			textInfo.Add ("ghjjkl");

			pi = true;
			ki = false;
		}
		if (Application.loadedLevel == 4)
		{
			textInfo.Add ("asdf");
			textInfo.Add ("ghjjkl");

			pi = false;
			ki = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		skin.box.fontSize = Screen.height / 15;
		skin.box.contentOffset = new Vector2(0,Screen.height / 50);
		GUI.skin = skin;

		if (Time.time - startTime < textInfo.Count * 3) {
			for (int i = 0; i < textInfo.Count; i++)
			{
				if (i%2 == 0 && pi == true) GUI.Label (new Rect(Screen.width * 7 / 10, Screen.height / textInfo.Count * i, Screen.width / 5, Screen.height / textInfo.Count * 2), PawnIcon);
				else if (i%2 == 0 && pi == false) GUI.Label (new Rect(Screen.width * 7 / 10, Screen.height / textInfo.Count * i, Screen.width / 8, Screen.height / textInfo.Count), altPawnIcon);

				if (i%2 == 1 && ki == true) GUI.Label (new Rect(Screen.width / 10, Screen.height / textInfo.Count * i, Screen.width / 5, Screen.height / textInfo.Count), KingIcon);
				else if (i%2 == 1 && ki == false) GUI.Label (new Rect(Screen.width / 10, Screen.height / textInfo.Count * i, Screen.width / 8, Screen.height / textInfo.Count), altKingIcon);

			}
			for (int i = 0; i < textInfo.Count; i++)
			{
				if (GUI.skin.box.alignment == TextAnchor.MiddleLeft) GUI.skin.box.alignment = TextAnchor.MiddleRight;
				else GUI.skin.box.alignment = TextAnchor.MiddleLeft;
				GUI.Box (new Rect(Screen.width / 8, Screen.height / textInfo.Count * i, Screen.width * 2 / 3, Screen.height / textInfo.Count), textInfo[i]);
			}
		}
	}
}

