using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodObject : MonoBehaviour {

	public int speed = 1;
	public bool isCatched = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!isCatched){
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}
	}

	public void Catch(){
		isCatched = true;
	}
}
