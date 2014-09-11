using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogMove : MonoBehaviour {
	public float speed = 5;
	Vector3 target;
	private float cd = 1f;
	private float next;
	public int movement = 3;
	private int curr = 1;
	public Vector3[] point = new Vector3[4];
	private Vector3 test;
	
	// Use this for initialization
	void Start () {
		next = Time.time;
		target = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
		

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
		test = new Vector3(transform.position.x - point[curr].x, transform.position.y - point[curr].y,transform.position.z - point[curr].z);
		if(test.x == 0 && test.z == 0){
			curr++;
			if(curr >= point.GetLength(0)){
				curr = 0;
			}
		}
	}
	public void Calc(){
		test = new Vector3(transform.position.x - point[curr].x, transform.position.y - point[curr].y,transform.position.z - point[curr].z);
		if(test.x >= 1){
			MoveU();
		}else
		if(test.x <= -1){
			MoveD();
		}else
		if(test.z >= 1){
			MoveR();
		}else
		if(test.z <= -1){
			MoveL();
		}



	}
	public void MoveR(){
		target = new Vector3(transform.position.x,transform.position.y,transform.position.z - 4);
	}
	public void MoveL(){
		target = new Vector3(transform.position.x,transform.position.y,transform.position.z + 4);
	}
	public void MoveU(){
		target = new Vector3(transform.position.x + 4,transform.position.y,transform.position.z - 4);
	}
	public void MoveD(){
		target = new Vector3(transform.position.x - 4,transform.position.y,transform.position.z - 4);
	}
}
