using UnityEngine;
using System.Collections;

public class tileManager : MonoBehaviour {

	public GameObject[] tiles;
	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectsWithTag("tile");
	}
	
	public void rotateTiles () {
		for (int i = 0; i < tiles.Length; i++) {
			if (tiles[i].GetComponent<tileRotation>().canRotate) {
				tiles[i].gameObject.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
			}
		}
	}

	void Update () {

	}
}
