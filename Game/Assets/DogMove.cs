using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogMove : MonoBehaviour {
	public float speed = 5;
	Vector3 target;
	private float cd = 1f;
	private float next;
	
	// Use this for initialization
	void Start () {
		next = Time.time;
		target = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(next + cd < Time.time){
			MoveR();
			next = Time.time;
		}
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target, step);
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
