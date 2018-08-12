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
        private Text QuestGroupDescription = null;

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
            var playerQuestRepository = new PlayerQuestRepository();

            var quest1 = questRepository.Get(questGroup.questIDs[0]);
            var quest2 = questRepository.Get(questGroup.questIDs[1]);
            var quest3 = questRepository.Get(questGroup.questIDs[2]);
            var playerQuest1 = playerQuestRepository.Get(questGroup.questIDs[0]);
            var playerQuest2 = playerQuestRepository.Get(questGroup.questIDs[1]);
            var playerQuest3 = playerQuestRepository.Get(questGroup.questIDs[2]);

            // シーン移動の設定をする
            MoveBattleScene(
                questViewMorning.GetComponent<Button>(),
                questGroup,
                quest1
            );
            MoveBattleScene(
                questViewEvening.GetComponent<Button>(),
                questGroup,
                quest2
            );
            MoveBattleScene(
                questViewNight.GetComponent<Button>(),
                questGroup,
                quest3
            );

            QuestGroupName.text = questGroup.Name;
            Banner.sprite = ResourceLoader.LoadSceneSprite(questGroup.bannerFilename);
            QuestGroupDescription.text = questGroup.Description;

            questViewMorning.UpdateView(quest1, playerQuest1);
            questViewEvening.UpdateView(quest2, playerQuest2);
            questViewNight.UpdateView(quest3, playerQuest3);

            questViewMorning.gameObject.SetActive(quest1.IsOpen());
            questViewEvening.gameObject.SetActive(quest2.IsOpen());
            questViewNight.gameObject.SetActive(quest3.IsOpen());
        }

        private void MoveBattleScene(Button button, QuestGroupModel questGroup, QuestModel quest)
        {
            if (button == null)
            {
                return;
            }

            button.onClick.AddListener(() =>
            {
                var playerSettingPresenter = new PlayerSettingRepository();
                var playerSettingModel = playerSettingPresenter.Get(0);

                // parameter
                var parameter = new InGameSceneParameter(                    
                    new CharacterRepository().Get(playerSettingModel.CharacterID),
                    questGroup,
                    quest                                    
                );
                SceneMoveManager.Instance.MoveScene("InGame", parameter);
            });
        }
    }
}