﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodGenerator : MonoBehaviour {

	public GameObject foodObject;
	public Vector3 generatePosiotion;
	public Vector3 exitPosiotion;
	public LaneType laneType;

	private float timer;

	// Use this for initialization
	void Start () {
		this.generatePosiotion = this.transform.position + new Vector3(-(this.transform.localScale.x / 2), 0.75f, 0);
		this.exitPosiotion = this.transform.position + new Vector3((this.transform.localScale.x / 2), 0.75f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= 1.0f){
			if(Random.Range(0f,100f) < 30f){
				this.Generate();
			}
			timer = 0f;
		}
	}

	void Generate(){
		GameObject food = Instantiate (foodObject, generatePosiotion, Quaternion.identity);
		food.transform.parent = this.transform;
	}
}
