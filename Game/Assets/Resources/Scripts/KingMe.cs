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
		if(collision.gameObject.name == "player"){
			Application.LoadLevel("Katie_title_screen");
			Debug.Log ("PLAYER HIT KING");
		}
	}
}
