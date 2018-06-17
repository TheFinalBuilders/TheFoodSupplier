using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : InputGestureManager {
	public static int shotLimited = 3;
	public GameObject shotObject;
	public int shotSpeed = 20;
	public Vector3 shotPosition = new Vector3(0f, 0.2f, 0f);
	public int currentShotNum = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateInput();

		if(!InGameManager.Instance.isFinished){
			// ゲーム中
			if(this._gesture_info.IsDown && this.currentShotNum < shotLimited){
				this.Shot();
			}
		}else{
			// ゲーム終了
		}
	}

	public void Shot(){
		GameObject shot = Instantiate (shotObject, this.transform.position + shotPosition, Quaternion.identity);
		shot.transform.parent = this.transform;
		shot.transform.rotation = shotObject.transform.rotation;
			
		Vector3 direction = new Vector3(this._gesture_info.ScreenPosition.x - (Camera.main.pixelWidth / 2), 0, this._gesture_info.ScreenPosition.y);
		shot.GetComponent<Rigidbody>().velocity = direction.normalized * shotSpeed;
		currentShotNum++;
	}

	// 引数はあとでFoodクラス作る
	public void CollectFood(int point){
		currentShotNum--;
		InGameManager.Instance.addPoint(point);
	}
}
