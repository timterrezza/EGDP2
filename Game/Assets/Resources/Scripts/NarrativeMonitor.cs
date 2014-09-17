using UnityEngine;
using System.Collections;

public class NarrativeMonitor : MonoBehaviour {

	public bool one = false;
	public bool two = false;
	public bool three = false;
	public bool four = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
