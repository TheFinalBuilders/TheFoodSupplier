using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.Model;

public class PlayerController : InputGestureManager {
	public static int shotLimited = 3;
	public GameObject shotObject;
	public Vector3 shotPosition = new Vector3(0f, 1.4f, 0f);
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
				if(characterType == CharacterType.Diffusion){
					this.DiffusionShot();
				}else{
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
		if(this.currentShotNum >= shotLimited) return;

		SoundManager.Instance.PlaySe("shot");

		currentShotNum++;

		this.GetComponent<Animator>().SetTrigger("Throw");
		Vector3 direction = new Vector3(this._gesture_info.ScreenPosition.x - (Camera.main.pixelWidth / 2), 0, this._gesture_info.ScreenPosition.y);
		StartCoroutine(CreateShot(direction));
	}

	public void DiffusionShot(){
		if(this.currentShotNum != 0) return;

		SoundManager.Instance.PlaySe("shot");
		
		currentShotNum+=3;
		this.GetComponent<Animator>().SetTrigger("Throw");
		Vector3 direction = new Vector3(this._gesture_info.ScreenPosition.x - (Camera.main.pixelWidth / 2), 0, this._gesture_info.ScreenPosition.y);
		Vector3 rightDirction = Quaternion.AngleAxis(15f, Vector3.up) * direction;
		Vector3 leftDirction = Quaternion.AngleAxis(-15f, Vector3.up) * direction;
		StartCoroutine(CreateShot(direction));
		StartCoroutine(CreateShot(rightDirction));
		StartCoroutine(CreateShot(leftDirction));
	}

	private IEnumerator CreateShot(Vector3 direction){
		yield return new WaitForSeconds(0.3f);

		GameObject shot = Instantiate (shotObject, this.transform.position + shotPosition, Quaternion.identity);
		shot.transform.parent = this.transform;
		shot.transform.rotation = shotObject.transform.rotation;
		shot.GetComponent<BulletObject>().Init(characterType, direction.normalized);
	}


	// 引数はあとでFoodクラス作る
	public void CollectFood(int point){
		if(InGameManager.Instance.isFinished) return;

		if(currentShotNum > 0) currentShotNum--;
		
		InGameManager.Instance.addPoint(point);
	}
}
