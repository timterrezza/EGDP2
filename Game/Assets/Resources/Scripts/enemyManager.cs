using UnityEngine;
using System.Collections;

public class enemyManager : MonoBehaviour {
	public GameObject[] enemies;
	public GameObject[] Baddies;
	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		Baddies = GameObject.FindGameObjectsWithTag("Dog");
	}

	public void stepEnemies () {
		for (int i = 0; i < enemies.Length; i++) {
			enemies[i].gameObject.transform.localPosition += new Vector3(0f,0f,1f);
		}
		for (int i = 0; i < Baddies.Length; i++) {
			Baddies[i].gameObject.GetComponent<DogMove>().Calc();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
