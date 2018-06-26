﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.UI;

public class InGameManager : SingletonMonoBehaviour<InGameManager> {
	public static float GAMETIME = 60f;
	public float currentTime = 0f;
	public int score = 0;
	public bool isFinished = false;
	public bool isSceneChanged = false;
	private string scoreText = "Score:";
	public UnityEngine.UI.Text ScoreUI;
	public UnityEngine.UI.Text TimerUI;

	// Use this for initialization
	void Start () {
		this.currentTime = 0f;
		this.score = 0;
		this.updateScore();
		this.updateTimer();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isFinished){
			// ゲーム中
			this.currentTime += Time.deltaTime;
			this.updateTimer();
			// ゲーム終了判定
			if(this.currentTime >= GAMETIME){
				this.isFinished = true;
			}
		}else if(!isSceneChanged){
			// ゲーム終了
			isSceneChanged = true;
            // パラメータの作成 TODO : サンプル
            var inGameSceneParameter = SceneMoveManager.Instance.CurrentSceneParameter as InGameSceneParameter;
            var parameter = new QuestResultSceneParameter(
                inGameSceneParameter.Character,
                inGameSceneParameter.QuestGroup,
                inGameSceneParameter.Quest,
                100,
                2,
                QuestResultType.Success
            );
			// シーン切り替え
            SceneMoveManager.Instance.MoveScene("QuestResultScene", parameter);
		}
	}

	public void addPoint(int point){
		this.score += point;
		this.updateScore();
	}

	private void updateScore(){
		ScoreUI.text = scoreText + this.score;
	}

	private void updateTimer(){
		TimerUI.text = ((int) (GAMETIME - currentTime)).ToString();
	}
}
