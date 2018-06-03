﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : SingletonMonoBehaviour<InGameManager> {
	public static float GAMETIME = 60f;
	public float currentTime = 0f;
	public int score = 0;
	public bool isFinished = false;

	// Use this for initialization
	void Start () {
		this.currentTime = 0f;
		this.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isFinished){
			// ゲーム中

			// ゲーム終了判定
			this.currentTime += Time.deltaTime;
			if(this.currentTime <= GAMETIME){
				this.isFinished = true;
			}
		}else{
			// ゲーム終了
			// シーン切り替え
		}
	}

}