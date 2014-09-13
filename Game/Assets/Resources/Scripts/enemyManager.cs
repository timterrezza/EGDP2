﻿using UnityEngine;
using System.Collections;

public class enemyManager : MonoBehaviour {
	public GameObject[] enemies;
	public GameObject[] Baddies;
	public GameObject[] Pawnies;
	public int dogm;
	
	private bool canMove = true;
	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		Baddies = GameObject.FindGameObjectsWithTag("Dog");
		Pawnies = GameObject.FindGameObjectsWithTag("Pawn");
	}

	public void stepEnemies () {
		for (int i = 0; i < enemies.Length; i++) {
			enemies[i].gameObject.transform.localPosition += new Vector3(0f,0f,1f);
		}
		for (int i = 0; i < Baddies.Length; i++) {

			Baddies[i].gameObject.GetComponent<DogMove>().Calc();
			Baddies[i].gameObject.GetComponent<DogMove>().reset();

		}
		for (int i = 0; i < Pawnies.Length; i++) {
			
			Pawnies[i].gameObject.GetComponent<PawnMove>().Calc();

			
		}


	}
		
	// Update is called once per frame
	void Update () {
//		enemies = GameObject.FindGameObjectsWithTag("enemy");
//		Baddies = GameObject.FindGameObjectsWithTag("Dog");
//		Pawnies = GameObject.FindGameObjectsWithTag("Pawn");
//		
//		for (int i = 0; i < enemies.Length; i++) {
//			
//		}
//		for (int i = 0; i < Baddies.Length; i++) {
//			
//		}
//		for (int i = 0; i < Pawnies.Length; i++) {
//			if (Pawnies[i].GetComponent<PawnMove>().ismoving == true) 
//			canMove = false;
//		}
//		
//		if (canMove == false) GameObject.Find ("First Person Controller")
	
	}
}
