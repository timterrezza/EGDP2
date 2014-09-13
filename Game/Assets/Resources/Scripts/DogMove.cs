using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogMove : MonoBehaviour {
	public float speed = 9;
	public float turnspeed = 5;
	Vector3 target;
	public int movement = 3;
	private int curr = 1;
	public Vector3[] point = new Vector3[4];
	public int[] Turnp = new int[4];
	private Vector3 test;
	private int extra = 0;
	public int runs;
	private Quaternion qr;
	public bool ismoving = false;
	// Use this for initialization
	void Start () {
		extra = runs;
		target = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		qr = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
		

		float step = speed * Time.deltaTime;
		transform.rotation = Quaternion.Lerp(transform.rotation,qr,Time.deltaTime*turnspeed);
		if(transform.position == target){
			ismoving = false;
		}

		transform.position = Vector3.MoveTowards(transform.position, target, step);
		

		test = new Vector3(transform.position.x - point[curr].x, transform.position.y - point[curr].y,transform.position.z - point[curr].z);
		if(test.x == 0 && test.z == 0){
			if(Turnp[curr] == 0){
				qr = Quaternion.Euler(new Vector3(0,0,0));
			}
			if(Turnp[curr] == 1){
				qr = Quaternion.Euler(new Vector3(0,90,0));
			}
			if(Turnp[curr] == 2){
				qr = Quaternion.Euler(new Vector3(0,180,0));
			}
			if(Turnp[curr] == 3){
				qr = Quaternion.Euler(new Vector3(0,270,0));
			}
			curr++;
			if(curr >= point.GetLength(0)){
				curr = 0;
			}
		}
		if(transform.position.x == target.x && transform.position.z == target.z && extra < runs){
			Calc();
			extra++;
		}

	}
	public void Calc(){
		test = new Vector3(transform.position.x - point[curr].x, transform.position.y - point[curr].y,transform.position.z - point[curr].z);
		ismoving = true;
		if(test.x >= 1){
			MoveD();
		}else
		if(test.x <= -1){
			MoveU();
		}else
		if(test.z >= 1){
			MoveR();
		}else
		if(test.z <= -1){
			MoveL();
		}


	}
	public void reset(){
		extra = 0;
	}
	public void MoveR(){
		target = new Vector3(transform.position.x,transform.position.y,transform.position.z - 4);
	}
	public void MoveL(){
		target = new Vector3(transform.position.x,transform.position.y,transform.position.z + 4);
	}
	public void MoveU(){
		target = new Vector3(transform.position.x + 4,transform.position.y,transform.position.z);
	}
	public void MoveD(){
		target = new Vector3(transform.position.x - 4,transform.position.y,transform.position.z);
	}
}
