﻿using UnityEngine;
using System.Collections;

public class titleScreenKnight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 50*Time.deltaTime,0);
	}
}
