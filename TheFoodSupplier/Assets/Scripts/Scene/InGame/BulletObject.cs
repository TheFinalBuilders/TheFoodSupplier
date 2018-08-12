using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.Model;

public class BulletObject : MonoBehaviour {

	bool isReturn = false;
	public CharacterType characterType = CharacterType.Normal;
	public int shotSpeed = 1;
	public Vector3 direction = Vector3.zero;
	private float lifeTime = 0f;
	private bool isCollect = false;

	// Use this for initialization
	void Start () {
		lifeTime = 0f;
		this.transform.LookAt(this.transform.position + this.direction);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		lifeTime += Time.deltaTime;
		switch(this.characterType){
			case CharacterType.Normal:
				this.transform.position += this.direction * shotSpeed * 1.5f * Time.deltaTime;
				break;
			case CharacterType.Boomerang:
				if(lifeTime > 1f){
					isReturn = true;
				}
				Vector3 offsetPosition = new Vector3(Mathf.Sign(this.transform.position.x) * (Mathf.Abs(this.transform.position.x) + 0.1f), 0f, this.transform.position.z);
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(this.transform.parent.position - offsetPosition), lifeTime * lifeTime * 0.01f);
				this.transform.position += this.transform.forward * shotSpeed * Time.deltaTime;
				break;
			case CharacterType.Diffusion:
				this.transform.position += this.direction * shotSpeed * 2f * Time.deltaTime;
				break;
			default:
				this.transform.position += this.direction * shotSpeed *1.5f * Time.deltaTime;
				break;
		}
	}

	public void Init(CharacterType characterType, Vector3 direction){
		this.characterType = characterType;
		this.direction = direction.normalized;
	}

	void OnTriggerEnter(Collider collider){
		if(collider.transform.tag.Equals("Player")){
			if(isReturn && !isCollect){
				isCollect = true;
				int scoreCount = 0;
				foreach(Transform child in this.transform){
					scoreCount += child.GetComponent<FoodObject>().GetScore();
				}
				this.transform.parent.GetComponent<PlayerController>().CollectFood(scoreCount);
				GameObject.Destroy(this.gameObject);
			}
		}else if(collider.transform.tag.Equals("Food")){
			// 戻ってきたときに弾と当てたくない
			collider.GetComponent<FoodObject>().Catch();
			collider.transform.parent = this.transform;
			collider.transform.tag = this.transform.tag;
			collider.gameObject.layer = this.gameObject.layer;
			if(this.characterType != CharacterType.Boomerang && !this.isReturn){
				this.Return();
			}
		}else{
			this.Return();
		}
	}

	private void Return(){
		this.isReturn = true;
		Vector3 direction = (this.transform.parent.position - this.transform.position);
		direction.y = 0;
		this.direction = direction.normalized;
		this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, -this.transform.rotation.z, this.transform.rotation.w);
	}
}