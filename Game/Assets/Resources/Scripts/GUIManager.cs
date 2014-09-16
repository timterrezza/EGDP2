using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	float startTime;
	public string textInfo;
	Texture talkingPerson;

	GUISkin skin;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		textInfo = "story elements go here";
		talkingPerson = (Texture)Resources.Load("Materials/testRed");
		skin = (GUISkin)Resources.Load ("GUI/Beginning");
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
			GUI.Box(new Rect(Screen.height / 7,Screen.height / 30,Screen.width - Screen.width / 8,Screen.height - Screen.height / 20), textInfo);
		}
	}
}

