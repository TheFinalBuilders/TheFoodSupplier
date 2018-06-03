using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : InputGestureManager {
	public GameObject shotObject;
	public int shotSpeed = 10;

	public Vector3 shotPosition = new Vector3(0f, 1f, 0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateInput();

		if(this._gesture_info.IsDown){
			GameObject shot = Instantiate (shotObject, this.transform.position + shotPosition, Quaternion.identity);
			shot.transform.parent = this.transform;
			shot.transform.rotation = shotObject.transform.rotation;
				
			Vector3 direction = new Vector3(this._gesture_info.ScreenPosition.x - (Camera.main.pixelWidth / 2), 0, this._gesture_info.ScreenPosition.y);
			shot.GetComponent<Rigidbody>().velocity = direction.normalized * shotSpeed;
		}
	}
}
