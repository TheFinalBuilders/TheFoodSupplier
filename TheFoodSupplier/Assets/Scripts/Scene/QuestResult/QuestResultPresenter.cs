using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TFS.Model;
using TFS.Repository;

namespace TFS.UI
{
    public enum QuestResultType
    {
        Success,
        Fail
    }

    public class QuestResultPresenter : MonoBehaviour
    {
        readonly string pt = "pt";

        [SerializeField]
        private Text clearText = null;

        [SerializeField]
        private StarView stars = null;

        [SerializeField]
        private Text scoreText = null;

        [SerializeField]
        private Text maxscoreUpdateNotification = null;

        [SerializeField]
        private Text questGroupName = null;

        [SerializeField]
        private QuestView questView = null;

        private QuestResultType type;
        private QuestGroupModel questGroup;
        private QuestModel quest;
        private int starCount;
        private int score;
        private bool isNoticeMax;

        // Use this for initialization
        void Start()
        {
            var questResultSceneParameter = SceneMoveManager.Instance.CurrentSceneParameter as QuestResultSceneParameter;
            if (questResultSceneParameter == null) {
                return;
            }

            Initialize(
                questResultSceneParameter.resultType,
                questResultSceneParameter.QuestGroup,
                questResultSceneParameter.Quest,
                questResultSceneParameter.StarCount,
                questResultSceneParameter.Score,
                CanUpdateScore(questResultSceneParameter.Score, questResultSceneParameter.Quest)
            );
        }

        private static bool CanUpdateScore(int nextScore, QuestModel model)
        {
            var playerQuestRepository = new PlayerQuestRepository();
            var playerQuestModel = playerQuestRepository.Get(model.ID);

            return playerQuestModel.CurrentScore < nextScore;
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateClearText();
            stars.UpdateView(starCount);
            scoreText.text = score.ToString() + pt;
            maxscoreUpdateNotification.gameObject.SetActive(isNoticeMax);
            questGroupName.text = questGroup.Name;
            questView.UpdateView(quest); // 使用しないため0となっている
        }

        private void UpdateClearText()
        {
            if (type == QuestResultType.Success) {
                clearText.text = "採集成功";
            }
        }

        public void Initialize(QuestResultType type,QuestGroupModel questGroup, QuestModel quest, int starCount, int score, bool isNoticeMax)
        {
            this.type = type;
            this.questGroup = questGroup;
            this.quest = quest;
            this.starCount = starCount;
            this.score = score;
            this.isNoticeMax = isNoticeMax;

            // 値のセット
            var playerQuestRepository = new PlayerQuestRepository();
            var playerQuestModel = playerQuestRepository.Get(quest.ID);

            if (CanUpdateScore(score, quest))
            {
                playerQuestModel.CurrentStarNum = starCount;
                playerQuestModel.CurrentScore = score;
                playerQuestRepository.Set(playerQuestModel);
            }
        }
	}
}