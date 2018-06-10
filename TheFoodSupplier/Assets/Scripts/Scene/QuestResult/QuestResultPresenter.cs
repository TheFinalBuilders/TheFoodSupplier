using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TFS.Model;
using TFS.Repository;

namespace TFS.UI
{
    public class QuestResultParameter
    {
        public uint QuestID { get; set; }
        public uint StarCount { get; set; }
        public uint Score { get; set; }
    }

    public enum QuestResultType
    {
        Success
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
        private QuestView questView = null;

        private QuestResultType type;
        private QuestModel quest;
        private int starCount;
        private uint score;
        private bool isNoticeMax;

        // Use this for initialization
        void Start()
        {
            // TODO: とりあえず
            var rep = new QuestRepository();

            Initialize(
                QuestResultType.Success,
                rep.Get(0),
                2,
                1234567890,
                true
            );
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateClearText();
            stars.UpdateView(starCount);
            scoreText.text = score.ToString() + pt;
            maxscoreUpdateNotification.gameObject.SetActive(isNoticeMax);
            questView.UpdateView(quest, 0); // 使用しないため0となっている
        }

        private void UpdateClearText()
        {
            if (type == QuestResultType.Success) {
                clearText.text = "採集成功";
            }
        }

        public void Initialize(QuestResultType type, QuestModel quest, int starCount, uint score, bool isNoticeMax)
        {
            this.type = type;
            this.quest = quest;
            this.starCount = starCount;
            this.score = score;
            this.isNoticeMax = isNoticeMax;
        }
	}
}