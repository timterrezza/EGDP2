using UnityEngine;
using System.Collections;

public class pewpew : MonoBehaviour {
	public float speed = 20;
	public float fadeSpeed = 1.5f;   
	public AudioClip gun;
	private bool ded = false;
	void Start () {
		ded = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(ded){
			GameObject.FindGameObjectWithTag("fader").GetComponent<fader>().EndScene();
		}
	}
	void OnTriggerEnter(Collider c) {

		if (c.gameObject.tag == "player" && this.GetComponent<PawnMove>().isturning == true) {
			//Debug.Log ("hi");
			c.audio.clip = gun;
			c.audio.Play();
			ded = true;

		}
	}

}
