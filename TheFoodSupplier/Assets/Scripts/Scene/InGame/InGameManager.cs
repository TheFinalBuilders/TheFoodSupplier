using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.UI;
using TFS.Model;
using TFS.Repository;

public class InGameManager : SingletonMonoBehaviour<InGameManager> {
	public static float GAMETIME = 60f;
	public InGameSceneParameter inGameSceneParameter = null;
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

		this.inGameSceneParameter = SceneMoveManager.Instance.CurrentSceneParameter as InGameSceneParameter;
		if(this.inGameSceneParameter == null){
			var characterRepository	= new CharacterRepository();
			var questGroupRepository = new QuestGroupRepository();
			var questRepository = new QuestRepository();
			this.inGameSceneParameter = new InGameSceneParameter(
				characterRepository.Get(0),
				questGroupRepository.Get(0),
				questRepository.Get(0)
				);
		}

		Instantiate(Resources.Load("InGame/" + this.inGameSceneParameter.QuestGroup.Name));
		GameObject player = (GameObject) Instantiate(Resources.Load("InGame/" + this.inGameSceneParameter.Character.Name));
		player.GetComponent<ShotController>().Init(this.inGameSceneParameter.Character.Type);
	}
	
	// Update is called once per frame
	void Update () {
		if(!this.isFinished){
			// ゲーム中
			this.currentTime += Time.deltaTime;
			this.updateTimer();
			// ゲーム終了判定
			if(this.currentTime >= GAMETIME){
				this.isFinished = true;
			}
		}else if(!this.isSceneChanged){
			// ゲーム終了
			this.isSceneChanged = true;
            // パラメータの作成 TODO : サンプル
            var parameter = new QuestResultSceneParameter(
                this.inGameSceneParameter.Character,
                this.inGameSceneParameter.QuestGroup,
                this.inGameSceneParameter.Quest,
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
		this.ScoreUI.text = this.scoreText + this.score;
	}

	private void updateTimer(){
		this.TimerUI.text = ((int) (GAMETIME - this.currentTime)).ToString();
	}

	/// <summary>
	/// デバッグ表示
	/// </summary>
	#if DEBUG
	void OnGUI()
	{
		int x = 20;
		int y = 800;
		GUI.color = Color.black;
		GUI.Label( new Rect(x,y,300,20), "CharacterName = " + this.inGameSceneParameter.Character.Name.ToString() );
		y += 20;
		GUI.Label( new Rect(x,y,300,20), "QuestGroupName = " + this.inGameSceneParameter.QuestGroup.Name.ToString() );
		y += 20;
		GUI.Label( new Rect(x,y,300,20), "QuestName = " + this.inGameSceneParameter.Quest.Name.ToString() );
	}
	#endif
}
