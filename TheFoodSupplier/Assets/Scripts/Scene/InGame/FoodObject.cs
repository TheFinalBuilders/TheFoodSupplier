using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType{
	Blond = 0,
	Silver = 1,
	Gold = 2,
	Platina = 3
};

public class FoodObject : MonoBehaviour {

	public Vector3 direction = Vector3.right;
	public float speed = 1.0f;
	public float exitPositionX;
	public bool isCatched = false;
	public FoodType foodType;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if(!isCatched){
			this.transform.position += this.direction * speed * Time.deltaTime;
			if(exitPositionX >= 0){
				if(transform.position.x >= exitPositionX){
					GameObject.Destroy(this.gameObject);
				}
			}else{
				if(transform.position.x <= exitPositionX){
					GameObject.Destroy(this.gameObject);
				}
			}
		}
	}
	public void Init(Vector3 direction,float speed, float exitPositionX){
		this.direction = direction;
		this.speed = speed;
		this.exitPositionX = exitPositionX;
	}

	public int GetScore(){
		switch(foodType){
			case FoodType.Blond :
				return 100;
			case FoodType.Silver :
				return 200;
			case FoodType.Gold :
				return 500;
			case FoodType.Platina :
				return 1000;
			default :
				return 100;
		}
	}

	public void Catch(){
		isCatched = true;
	}
}
