using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour {

	public GameObject foodObject;
	public Vector3 generatePosiotion;
	public Vector3 exitPosiotion;

	private float timer;

	// Use this for initialization
	void Start () {
        this.generatePosiotion = new Vector3(-10, this.transform.position.y + 1.26f, this.transform.position.z);
        this.exitPosiotion = new Vector3(+12, this.transform.position.y + 1.26f, this.transform.position.z);
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
