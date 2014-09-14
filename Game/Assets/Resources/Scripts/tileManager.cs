using UnityEngine;
using System.Collections;

public class tileManager : MonoBehaviour {

	public GameObject[] tiles;
	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectsWithTag("wall");
	}
	
	public void rotateTiles () {
		for (int i = 0; i < tiles.Length; i++) {
			if (tiles[i].GetComponent<tileRotation>().canRotate) {
				tiles[i].gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
			}
		}
	}

	void Update () {

	}
}
