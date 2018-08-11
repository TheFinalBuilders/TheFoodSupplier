using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.Model;

// あとでQuestから持ってくる
public enum Difficuly{
	Easy = 0,
	Normal = 2,
	Hard = 5,
};

public class FoodGenerator : MonoBehaviour {

	public GameObject foodObject;
	public Vector3 generatePosiotion;
	public Vector3 exitPosiotion;
	public LaneType laneType;
	private LaneModel laneModel;

	private float timer;
	private Difficuly difficuly;

	// Use this for initialization
	void Start () {
        //this.generatePosiotion = new Vector3(-10, this.transform.position.y + 1.26f, this.transform.position.z);
        //this.exitPosiotion = new Vector3(+12, this.transform.position.y + 1.26f, this.transform.position.z);
		this.laneModel = LaneModel.Instance.GetLane(this.laneType);
	}
	
	// Update is called once per frame
	void Update () {
		this.timer += Time.deltaTime;
		if(this.timer >= this.laneModel.generateSpeed){
			if(Random.Range(0f,100f) < this.laneModel.probability){
				switch(laneType){
					case LaneType.Forward:
						this.Generate(FoodType.Blond);
						break;
					case LaneType.Middle:
						this.Generate(FoodType.Silver);
						break;
					case LaneType.Back:
						if(Random.Range(0, 10) < 8){
							this.Generate(FoodType.Gold);
						}else{
							this.Generate(FoodType.Platina);
						}
						break;
					default :
						this.Generate(FoodType.Blond);
						break;
				}
			}
			this.timer = 0f;
		}
	}

	void Generate(FoodType foodType){
		GameObject food = (GameObject) Instantiate(Resources.Load("InGame/foodObject/FoodObjectKan" + foodType.ToString()));
		food.transform.position = this.generatePosiotion;
		food.transform.parent = this.transform;
		Vector3 direction = (this.exitPosiotion -this.generatePosiotion).normalized;
		food.GetComponent<FoodObject>().Init(direction, this.laneModel.speed, this.exitPosiotion.x);
	}
}
