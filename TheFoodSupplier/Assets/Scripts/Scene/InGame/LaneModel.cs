using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaneType{
	Forward = 0,
	Middle = 1,
	Back = 2,
};

public class LaneModel {

	public uint ID { get; private set; }
	public float speed { get; private set; }
	public float generateSpeed { get; private set; }

	public LaneModel(uint id, float speed, float generateSpeed){
		this.ID = id;
		this.speed = speed;
		this.generateSpeed = generateSpeed;
	}

	public LaneModel GetLane(LaneType lanetype){
		switch(lanetype){
			case LaneType.Forward :
				return new LaneModel(0, 1, 0.5f);
			case LaneType.Middle :
				return new LaneModel(1, 1.5f, 1f);
			case LaneType.Back :
				return new LaneModel(2, 2f, 2f);
			default:
				return new LaneModel(0, 1, 0.5f);
		}
	}
}
