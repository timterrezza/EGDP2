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
	bool story = false;

	GUISkin skin;

	// Use this for initialization
	void Start () {

		if (Application.loadedLevel == 1 && GameObject.FindGameObjectWithTag("narrative").GetComponent<NarrativeMonitor>().one == false) story = true;
		if (Application.loadedLevel == 2 && GameObject.FindGameObjectWithTag("narrative").GetComponent<NarrativeMonitor>().two == false) story = true;
		if (Application.loadedLevel == 3 && GameObject.FindGameObjectWithTag("narrative").GetComponent<NarrativeMonitor>().three == false) story = true;
		if (Application.loadedLevel == 4 && GameObject.FindGameObjectWithTag("narrative").GetComponent<NarrativeMonitor>().four == false) story = true;

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
			textInfo.Add ("What the hell was that about?");
			textInfo.Add ("You killed one of us, we killed one of you.");
			textInfo.Add ("But ours was a contract; yours was just petty revenge.");
			textInfo.Add ("Well, maybe next time you’ll think about killing one of us.");
			textInfo.Add ("You can’t be serious.  We’re supposed to be professionals, damn it.");

			pi = false;
			ki = true;
		}
		if (Application.loadedLevel == 3)
		{
			textInfo.Add ("You’re going to pay for what you’ve done.");
			textInfo.Add ("And then you’ll pay, and then, we’ll pay, I get it.");
			textInfo.Add ("Shut up- this is serious business.");
			textInfo.Add ("Listen to yourself.  Just the same as the last guy and the next guy.");

			pi = true;
			ki = false;
		}
		if (Application.loadedLevel == 4)
		{
			textInfo.Add ("You already know why I’m here.");
			textInfo.Add ("We could stop this, here and now.");
			textInfo.Add ("How?  Who’s going to tell the bosses to go to hell?");
			textInfo.Add ("I guess you have a point.");
			textInfo.Add ("When you find someone neutral, let me know.");

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


		if (Time.time - startTime < textInfo.Count * 3 && story == true) {
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
		else
		{
			if (Application.loadedLevel == 1) GameObject.FindGameObjectWithTag("narrative").GetComponent<NarrativeMonitor>().one = true;
			if (Application.loadedLevel == 2) GameObject.FindGameObjectWithTag("narrative").GetComponent<NarrativeMonitor>().two = true;
			if (Application.loadedLevel == 3) GameObject.FindGameObjectWithTag("narrative").GetComponent<NarrativeMonitor>().three = true;
			if (Application.loadedLevel == 4) GameObject.FindGameObjectWithTag("narrative").GetComponent<NarrativeMonitor>().four = true;
		}
	}
}

