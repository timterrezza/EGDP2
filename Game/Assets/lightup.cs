using UnityEngine;
using System.Collections;

public class lightup : MonoBehaviour {
	public Texture texture;
	public Texture a;
	// Use this for initialization
	void Start () {
		renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision c) {
		if (c.gameObject.tag == "Dog"){
			renderer.material.mainTexture = a;

		}
		if (c.gameObject.tag == "Pawn"){
			renderer.material.mainTexture = a;
			
		}


	}
	void OnCollisionExit (Collision c) {
		if (c.gameObject.tag == "Dog"){
			renderer.material.mainTexture = texture;
			
		}
		if (c.gameObject.tag == "Pawn"){
			renderer.material.mainTexture = texture;
			
		}
		
	}
}
