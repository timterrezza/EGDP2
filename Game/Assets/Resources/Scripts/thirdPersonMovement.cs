using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class thirdPersonMovement : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 0.2f;
	private float startTime;
	private float journeyLength;

	public float smooth = 1.0f;

	public Transform currentMarker;

	GUITexture startButton;

	GameObject[] initialMarkers;
	List<Transform> markers;

	bool canInput;
	float distCovered;
	float fracJourney;

	List<string> inputString;

	void Start() {

		canInput = true;

		GameObject initialTarget = (GameObject)Instantiate(Resources.Load ("Prefabs/target"),transform.position,Quaternion.identity);

		initialMarkers = GameObject.FindGameObjectsWithTag("target");

		markers = new List<Transform>();

		for (int i = 0; i < initialMarkers.Length; i++) {
			markers.Add(initialMarkers[i].transform);
		}

		startMarker = transform;
		endMarker = initialTarget.transform;
		currentMarker = initialTarget.transform;
	}

	void setEndMarker(string input) {
		for (int i = 0; i < markers.Count; i++) {
			if (input == "up") {
				if (currentMarker.gameObject.transform.position.z - markers[i].gameObject.transform.position.z == -4 && currentMarker.gameObject.transform.position.x == markers[i].gameObject.transform.position.x) {
					endMarker = markers[i];
					break;
				}
			}
			else if (input == "down") {
				if (currentMarker.gameObject.transform.position.z - markers[i].gameObject.transform.position.z == 4 && currentMarker.gameObject.transform.position.x == markers[i].gameObject.transform.position.x) {
					endMarker = markers[i];
					break;
				}
			}
			else if (input == "left") {
				if (currentMarker.gameObject.transform.position.x - markers[i].gameObject.transform.position.x == 4 && currentMarker.gameObject.transform.position.z == markers[i].gameObject.transform.position.z) {
					endMarker = markers[i];
					break;
				}
			}
			else {
				if (currentMarker.gameObject.transform.position.x - markers[i].gameObject.transform.position.x == -4 && currentMarker.gameObject.transform.position.z == markers[i].gameObject.transform.position.z) {
					endMarker = markers[i];
					break;
				}
			}
		}
	}

	void Update() {
		if (canInput) {
			if(Input.GetKeyDown(KeyCode.W)){
				setEndMarker("up");
				canInput = false;
				startTime = Time.time;
			}
			if(Input.GetKeyDown(KeyCode.A)){
				setEndMarker("left");
				canInput = false;
				startTime = Time.time;
			}
			if(Input.GetKeyDown(KeyCode.S)){
				setEndMarker("down");
				canInput = false;
				startTime = Time.time;
			}
			if(Input.GetKeyDown(KeyCode.D)){
				setEndMarker("right");
				canInput = false;
				startTime = Time.time;
			}
		}
		else {
			distCovered = (Time.time - startTime) * speed;
			fracJourney = distCovered / 4;
			transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
			if (fracJourney > 0.1) {
				canInput = true;
				currentMarker = endMarker;
			}
		}
	}
}
