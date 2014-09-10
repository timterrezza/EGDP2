using UnityEngine;
using System.Collections;

public class playerTileInteraction : MonoBehaviour {
	GameObject enemyManager;
	// Use this for initialization
	void Start () {
		enemyManager = GameObject.Find ("Enemy Manager");
	}

	void OnCollisionExit (Collision c) {
		if (c.gameObject.tag == "tile") {
			enemyManager.GetComponent<enemyManager>().stepEnemies();
		}
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = GameObject.Find ("First Person Controller").gameObject.transform.localPosition;
		gameObject.transform.rotation = GameObject.Find ("First Person Controller").gameObject.transform.localRotation;
	}
}
