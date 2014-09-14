using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class thirdPersonMovement : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 0.2f;
	private float startTime;
	private float journeyLength;
	public Transform target;
	public float smooth = 1.0f;
	public Transform top1;
	public Transform top2;
	public Transform top3;
	public Transform bottom1;
	public Transform bottom2;
	public Transform bottom3;
	public Transform middle1;
	public Transform middle2;
	public Transform middle3;
	public Transform currentMarker;

	public Transform beginningMarker;

	GUITexture startButton;

	Transform[] markers;
	bool canInput;
	float distCovered;
	float fracJourney;

	List<string> inputString;

	bool initialPhase;

	bool isLerping;

	int lerpIndex;

	void Start() {
		startButton = GameObject.Find ("Start").guiTexture;
		canInput = true;
		markers = new Transform[9];
		inputString = new List<string>();
		markers[0] = top1;
		markers[1] = top2;
		markers[2] = top3;
		markers[3] = bottom1;
		markers[4] = bottom2;
		markers[5] = bottom3;
		markers[6] = middle1;
		markers[7] = middle2;
		markers[8] = middle3;
		initialPhase = true;

		isLerping = false;
	}

	void setEndMarker(string input) {
		for (int i = 0; i < markers.Length; i++) {
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

	bool canMoveInDirection(string input) {
		if (currentMarker.gameObject.tag.Contains(input)) {
			return true;
		}
		return false;
	}

	void Update() {
		if (initialPhase) {
			if (startButton.HitTest(Input.mousePosition)) {
				if (Input.GetMouseButtonDown(0)) {
					transform.position = beginningMarker.position;
					currentMarker = beginningMarker;
					setEndMarker(inputString[0]);
					startTime = Time.time;
					lerpIndex = 0;
					initialPhase = false;
				}
			}
			if(Input.GetKeyDown(KeyCode.W)){
				if (canMoveInDirection("up") && canInput) {
					setEndMarker("up");
					inputString.Add("up");
					canInput = false;
					startTime = Time.time;
				}
			}
			if(Input.GetKeyDown(KeyCode.A)){
				if (canMoveInDirection("left") && canInput) {
					setEndMarker("left");
					inputString.Add("left");
					canInput = false;
					startTime = Time.time;
				}
			}
			if(Input.GetKeyDown(KeyCode.S)){
				if (canMoveInDirection("down") && canInput) {
					setEndMarker("down");
					inputString.Add("down");
					canInput = false;
					startTime = Time.time;
				}
			}
			if(Input.GetKeyDown(KeyCode.D) && canInput){
				if (canMoveInDirection("right") && canInput) {
					setEndMarker("right");
					inputString.Add("right");
					canInput = false;
					startTime = Time.time;
				}
			}
			if (!canInput) {
				distCovered = (Time.time - startTime) * speed;
				fracJourney = distCovered / 4;
				transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
				if (fracJourney > 0.1) {
					canInput = true;
					currentMarker = endMarker;
				}
			}
		}
		else {
			if (isLerping) {
				distCovered = (Time.time - startTime);
				fracJourney = distCovered / 4;
				transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
				if (transform.position.x == endMarker.position.x && transform.position.z == endMarker.position.z) {
					currentMarker = endMarker;
					isLerping = false;
					lerpIndex += 1;
				}
			}
			if (!isLerping) {
				if (lerpIndex == inputString.Count) {
					initialPhase = true;
				}
				else {
					transform.position = endMarker.position;
					setEndMarker(inputString[lerpIndex]);
					startTime = Time.time;
					isLerping = true;
				}
			}

		}
	}
}
