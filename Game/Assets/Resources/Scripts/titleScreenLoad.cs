using UnityEngine;
using System.Collections;

public class titleScreenLoad : MonoBehaviour {

	void OnMouseDown() {
		if (gameObject.name == "New") {
			if (Input.GetMouseButtonDown(0)) {
				Application.LoadLevel(1);
			}
		}
		else if (gameObject.name == "Continue") {
			if (Input.GetMouseButtonDown(0)) {
				Application.LoadLevel(PlayerPrefs.GetInt("level"));
			}
		}
		else if (gameObject.name == "Quit") {
			if (Input.GetMouseButtonDown(0)) {
				Application.Quit();
			}
		}
	}

}
