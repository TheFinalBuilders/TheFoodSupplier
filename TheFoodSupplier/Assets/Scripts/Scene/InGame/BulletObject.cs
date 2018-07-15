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

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += this.velocity * shotSpeed * Time.deltaTime;
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
			this.Return();
		}else{
			this.Return();
		}
	}

	private void Return(){
		this.isReturn = true;
		this.velocity = (this.transform.parent.position - this.transform.position).normalized;
	}
}
