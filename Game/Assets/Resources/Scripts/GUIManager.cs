using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	float startTime;
	public float textWidth;
	public float textHeight;
	public float textLeft;
	public float textTop;
	public float pictureWidth;
	public float pictureHeight;
	public float pictureLeft;
	public float pictureTop;
	public string textInfo;
	Texture talkingPerson;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		textWidth = 380;
		textHeight = 250;
		textLeft = 70;
		textTop = 10;
		pictureWidth = 50;
		pictureHeight = 50;
		pictureLeft = 10;
		pictureTop = 10;
		textInfo = "story elements go here";
		talkingPerson = (Texture)Resources.Load("Materials/testRed");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (Time.time - startTime < 10) {
			GUI.Label(new Rect(pictureLeft,pictureTop,pictureWidth,pictureHeight), talkingPerson);
			GUI.Box(new Rect(textLeft,textTop,textWidth,textHeight), textInfo);
		}
	}
}

