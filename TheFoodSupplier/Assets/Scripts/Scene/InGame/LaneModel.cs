using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaneType{
	Forward = 0,
	Middle = 1,
	Back = 2,
};

public class LaneModel {
	public float speed { get; private set; }
	public float generateSpeed { get; private set; }
	public float probability { get; private set; }
	private static LaneModel instance = new LaneModel();

	public static LaneModel Instance {
		get {
			return instance;
		}
	}

	LaneModel(){}

	private LaneModel(float speed, float generateSpeed, float probability){
		this.speed = speed;
		this.generateSpeed = generateSpeed;
		this.probability = probability;
	}

	public LaneModel GetLane(LaneType lanetype){
		switch(lanetype){
			case LaneType.Forward :
				return new LaneModel(2f, 0.75f, 80f);
			case LaneType.Middle :
				return new LaneModel(1.5f, 1f, 60f);
			case LaneType.Back :
				return new LaneModel(1f, 1.5f, 40f);
			default:
				return new LaneModel(2f, 0.5f, 60f);
		}
	}
}
