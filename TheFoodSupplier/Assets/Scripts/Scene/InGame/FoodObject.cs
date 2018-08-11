using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour {

	public float speed = 1.0f;
	public bool isCatched = false;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if(!isCatched){
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}
	}
	public void Init(float speed){
		this.speed = speed;
	}

	public void Catch(){
		isCatched = true;
	}
}
