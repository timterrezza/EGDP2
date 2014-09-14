using UnityEngine;
using System.Collections;

public class playerTileInteraction : MonoBehaviour {
	GameObject enemyManager;
<<<<<<< HEAD
	GameObject tileManager;
	// Use this for initialization
=======


>>>>>>> b06860bae1e2cf3fdceae8036ebd08395b850919
	void Start () {
		enemyManager = GameObject.Find ("Enemy Manager");
		tileManager = GameObject.Find ("Tile Manager");
	}

	void OnCollisionExit (Collision c) {
		if (c.gameObject.tag == "tile") {
			enemyManager.GetComponent<enemyManager>().stepEnemies();
			tileManager.GetComponent<tileManager>().rotateTiles();
		}
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = GameObject.Find ("First Person Controller").gameObject.transform.localPosition;
		gameObject.transform.rotation = GameObject.Find ("First Person Controller").gameObject.transform.localRotation;
	}
}
