using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.Model;

public class BulletObject : MonoBehaviour {

	bool isReturn = false;
	bool isCollect = false;
	public CharacterType characterType = CharacterType.Normal;
	public int shotSpeed = 1;
	public Vector3 velocity = Vector3.zero;
	private float lifeTime = 0f;

	// Use this for initialization
	void Start () {
		lifeTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		switch(this.characterType){
			case CharacterType.Normal:
				this.transform.position += this.velocity * shotSpeed * Time.deltaTime;
				break;
			case CharacterType.Boomerang:
				if(!isReturn && this.lifeTime >= Mathf.PI * 2){
					isReturn = true;
				}
				lifeTime = lifeTime + Time.deltaTime;
				this.transform.position += new Vector3(Mathf.Cos(lifeTime) * this.velocity.x, 0, Mathf.Sin(lifeTime) * this.velocity.z).normalized * 0.5f * shotSpeed * Time.deltaTime;
				break;
			default:
				this.transform.position += this.velocity * shotSpeed * Time.deltaTime;
				break;
		}
	}

	public void Init(CharacterType characterType, Vector3 velocity){
		this.characterType = characterType;
		this.velocity = velocity;
	}

	void OnTriggerEnter(Collider collider){
		if(collider.transform.tag.Equals("Player")){
			if(isReturn && !isCollect){
				isCollect = true;
				this.transform.parent.GetComponent<ShotController>().CollectFood(this.transform.childCount);
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
		this.velocity = direction.normalized;
		this.lifeTime = 0;
	}
}
