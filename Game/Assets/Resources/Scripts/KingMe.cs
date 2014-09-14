using UnityEngine;
using System.Collections;

public class KingMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision collision) {
		Debug.Log("hit me");
		if(collision.gameObject.name == "player"){
			Application.LoadLevel("Resources/Scenes/Karl_Scene");

		}
	}
}
