using UnityEngine;
using System.Collections;

public class enemyManager : MonoBehaviour {
	public GameObject[] enemies;

	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("enemy");
	}

	public void stepEnemies () {
		for (int i = 0; i < enemies.Length; i++) {
			enemies[i].gameObject.transform.localPosition += new Vector3(0f,0f,1f);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
