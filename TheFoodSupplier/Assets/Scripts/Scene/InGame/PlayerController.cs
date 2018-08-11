using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.Model;

public class PlayerController : InputGestureManager {
	public static int shotLimited = 3;
	public GameObject shotObject;
	public Vector3 shotPosition = new Vector3(0f, 0.2f, 0f);
	public int currentShotNum = 0;
	public CharacterType characterType = CharacterType.Normal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateInput();

		if(!InGameManager.Instance.isFinished){
			// ゲーム中
			if(this._gesture_info.IsDown){
				if(this.currentShotNum < shotLimited){
					currentShotNum++;
					this.Shot();
				}
			}
		}else{
			this.GetComponent<Animator>().SetTrigger("Finished");
		}
	}

	public void Init(CharacterType characterType){
		this.characterType = characterType;
	}

	public void Shot(){
		this.GetComponent<Animator>().SetTrigger("Throw");
		StartCoroutine(createShot());
	}

	private IEnumerator createShot(){
		yield return new WaitForSeconds(0.3f);

		GameObject shot = Instantiate (shotObject, this.transform.position + shotPosition, Quaternion.identity);
		shot.transform.parent = this.transform;
		shot.transform.rotation = shotObject.transform.rotation;
		Vector3 direction = new Vector3(this._gesture_info.ScreenPosition.x - (Camera.main.pixelWidth / 2), 0, this._gesture_info.ScreenPosition.y);
		shot.GetComponent<BulletObject>().Init(characterType, direction.normalized);
	}

	// 引数はあとでFoodクラス作る
	public void CollectFood(int point){
		if(currentShotNum > 0){
			currentShotNum--;
		}
		InGameManager.Instance.addPoint(point);
	}
}
