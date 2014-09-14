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

	GameObject enemyManager;

	bool bumpedIntoWall;

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "wall") {
			endMarker = currentMarker;
			bumpedIntoWall = true;
		}
	}

	void Start() {
		bumpedIntoWall = false;

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

		enemyManager = GameObject.Find("Enemy Manager");
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
				if (transform.rotation.eulerAngles.y > 315 || transform.rotation.eulerAngles.y < 46) {
					setEndMarker("up");
				}
				else if (transform.rotation.eulerAngles.y > 45 && transform.rotation.eulerAngles.y < 136) {
					setEndMarker("right");
				}
				else if (transform.rotation.eulerAngles.y > 135 && transform.rotation.eulerAngles.y < 226) {
					setEndMarker("down");
				}
				else {
					setEndMarker("left");
				}

				canInput = false;
				startTime = Time.time;
			}
			if(Input.GetKeyDown(KeyCode.A)) {
				if (transform.rotation.eulerAngles.y > 315 || transform.rotation.eulerAngles.y < 46) {
					setEndMarker("left");
				}
				else if (transform.rotation.eulerAngles.y > 45 && transform.rotation.eulerAngles.y < 136) {
					setEndMarker("up");
				}
				else if (transform.rotation.eulerAngles.y > 135 && transform.rotation.eulerAngles.y < 226) {
					setEndMarker("right");
				}
				else {
					setEndMarker("down");
				}
				canInput = false;
				startTime = Time.time;
			}
			if(Input.GetKeyDown(KeyCode.S)) {
				if (transform.rotation.eulerAngles.y > 315 || transform.rotation.eulerAngles.y < 46) {
					setEndMarker("down");
				}
				else if (transform.rotation.eulerAngles.y > 45 && transform.rotation.eulerAngles.y < 136) {
					setEndMarker("left");
				}
				else if (transform.rotation.eulerAngles.y > 135 && transform.rotation.eulerAngles.y < 226) {
					setEndMarker("up");
				}
				else {
					setEndMarker("right");
				}
				canInput = false;
				startTime = Time.time;
			}
			if(Input.GetKeyDown(KeyCode.D)) {
				if (transform.rotation.eulerAngles.y > 315 || transform.rotation.eulerAngles.y < 46) {
					setEndMarker("right");
				}
				else if (transform.rotation.eulerAngles.y > 45 && transform.rotation.eulerAngles.y < 136) {
					setEndMarker("down");
				}
				else if (transform.rotation.eulerAngles.y > 135 && transform.rotation.eulerAngles.y < 226) {
					setEndMarker("left");
				}
				else {
					setEndMarker("up");
				}
				canInput = false;
				startTime = Time.time;
			}
		}
		else {
			distCovered = (Time.time - startTime) * speed;
			fracJourney = distCovered / 4;
			transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
			if (fracJourney > 0.1) {
				currentMarker = endMarker;
				if (bumpedIntoWall == false) {
					enemyManager.GetComponent<enemyManager>().stepEnemies();
				}
				else {
					bumpedIntoWall = false;
				}
				canInput = true;
			}
		}
	}
}
