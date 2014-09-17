using UnityEngine;
using System.Collections;

public class KingMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.tag == "player"){
			if (Application.loadedLevel == 4) Application.LoadLevel("Katie_title_screen");
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
