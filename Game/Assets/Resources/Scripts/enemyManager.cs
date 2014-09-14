using UnityEngine;
using System.Collections;

public class enemyManager : MonoBehaviour {
	public GameObject[] enemies;
	public GameObject[] Baddies;
	public GameObject[] Pawnies;
	public int dogm;

	public float derp;

	private CharacterMotor jsScript;

	public bool canMove = true;

	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		Baddies = GameObject.FindGameObjectsWithTag("Dog");
		Pawnies = GameObject.FindGameObjectsWithTag("Pawn");
	}

	public void stepEnemies () {
		derp = Time.time;
		canMove = false;
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
	
	void Update () {
		//CharacterMotor code = GameObject.Find ("First Person Controller").GetComponent<CharacterMotor>();

		enemies = GameObject.FindGameObjectsWithTag("enemy");
		Baddies = GameObject.FindGameObjectsWithTag("Dog");
		Pawnies = GameObject.FindGameObjectsWithTag("Pawn");

		/*if(canMove == false)	{
			code.canControl = false;
		}
		else
			code.canControl = true;*/

		if(Time.time > derp + 1.5f)	{
			canMove = true;
		}

	}
}
