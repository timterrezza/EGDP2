using UnityEngine;
using System.Collections;

public class lightup : MonoBehaviour {
	public Texture texture;
	public Texture texture1;
	public Texture texture2;
	public Texture texture3;
	public Texture a;
	int randomNumber;
	// Use this for initialization
	void Start () {
		randomNumber = UnityEngine.Random.Range(0,100);
		renderer.material.mainTexture = texture;
		if (randomNumber <= 25){
			renderer.material.mainTexture = texture;
		}
		if (randomNumber <= 50 && randomNumber > 25){
			renderer.material.mainTexture = texture1;
		}
		if (randomNumber <= 75 && randomNumber > 50){
			renderer.material.mainTexture = texture2;
		}
		if (randomNumber > 75){
			renderer.material.mainTexture = texture3;
		}

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
			//renderer.material.mainTexture = texture;
			if (randomNumber <= 25){
				renderer.material.mainTexture = texture;
			}
			if (randomNumber <= 50 && randomNumber > 25){
				renderer.material.mainTexture = texture1;
			}
			if (randomNumber <= 75 && randomNumber > 50){
				renderer.material.mainTexture = texture2;
			}
			if (randomNumber > 75){
				renderer.material.mainTexture = texture3;
			}
			
		}
		if (c.gameObject.tag == "Pawn"){
			renderer.material.mainTexture = texture;
			if (randomNumber <= 25){
				renderer.material.mainTexture = texture;
			}
			if (randomNumber <= 50 && randomNumber > 25){
				renderer.material.mainTexture = texture1;
			}
			if (randomNumber <= 75 && randomNumber > 50){
				renderer.material.mainTexture = texture2;
			}
			if (randomNumber > 75){
				renderer.material.mainTexture = texture3;
			}
			
		}
		
	}
}
