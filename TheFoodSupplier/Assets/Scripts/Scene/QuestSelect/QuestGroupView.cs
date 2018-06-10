using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TFS.Repository;

namespace TFS.UI
{
    public class QuestGroupView : MonoBehaviour
    {

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

            UpdateViewFromQuestGroupID(0);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateViewFromQuestGroupID(uint id)
        {
            var questGroupRepository = new QuestGroupRepository();
            var questRepository = new QuestRepository();

            var questGroup = questGroupRepository.Get(id);
            var quest1 = questRepository.Get(questGroup.questIDs[0]);
            var quest2 = questRepository.Get(questGroup.questIDs[1]);
            var quest3 = questRepository.Get(questGroup.questIDs[2]);

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
    }
}