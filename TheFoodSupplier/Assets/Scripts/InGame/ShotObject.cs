using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotObject : MonoBehaviour {

	bool isReturn = false;
	bool isCollect = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
			collider.transform.parent = this.transform;
			collider.transform.tag = this.transform.tag;
			collider.gameObject.layer = this.gameObject.gameObject.layer;
			this.Return();
		}else{
			this.Return();
		}
	}

	private void Return(){
		this.isReturn = true;
		Vector3 direction =  (this.transform.parent.position - this.transform.position).normalized;
		this.gameObject.GetComponent<Rigidbody>().velocity = 
			direction * this.transform.parent.GetComponent<ShotController>().shotSpeed;
	}
}
