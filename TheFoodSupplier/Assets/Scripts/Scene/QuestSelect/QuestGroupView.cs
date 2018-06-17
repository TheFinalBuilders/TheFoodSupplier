using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TFS.Repository;
using TFS.Model;

namespace TFS.UI
{
    public class QuestGroupView : MonoBehaviour
    {

        [SerializeField]
        private Text QuestGroupName = null;

        [SerializeField]
        private Image Banner = null;

        [SerializeField]
        private QuestView questViewMorning = null;

        [SerializeField]
        private QuestView questViewEvening = null;

        [SerializeField]
        private QuestView questViewNight = null;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateView(QuestGroupModel questGroup)
        {
            var questRepository = new QuestRepository();

            var quest1 = questRepository.Get(questGroup.questIDs[0]);
            var quest2 = questRepository.Get(questGroup.questIDs[1]);
            var quest3 = questRepository.Get(questGroup.questIDs[2]);

            // シーン移動の設定をする
            MoveBattleScene(
                questViewMorning.GetComponent<Button>(),
                quest1
            );
            MoveBattleScene(
                questViewEvening.GetComponent<Button>(),
                quest2
            );
            MoveBattleScene(
                questViewNight.GetComponent<Button>(),
                quest3
            );

            QuestGroupName.text = questGroup.Name;
            Banner.sprite = ResourceLoader.LoadSceneSprite(questGroup.bannerFilename);

            questViewMorning.UpdateView(
                quest1.Name,
                quest1.bannerFilename,
                1
            );

            questViewEvening.UpdateView(
                quest2.Name,
                quest2.bannerFilename,
                2
            );

            questViewNight.UpdateView(
                quest3.Name,
                quest3.bannerFilename,
                3
            );
        }

        private void MoveBattleScene(Button button, QuestModel model)
        {
            if (button == null)
            {
                return;
            }

            button.onClick.AddListener(() =>
            {
                // 仮
                SceneMoveManager.Instance.MoveScene("InGame");
            });
        }
    }
}