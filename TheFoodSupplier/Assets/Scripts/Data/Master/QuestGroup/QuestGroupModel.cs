using UnityEngine;
using System.Collections;
using TFS.Repository;

namespace TFS.Model
{
    public class QuestGroupModel : IModel
    {
        private readonly uint OpenValue = 9999999;

        public uint ID { get; private set; }
        public string Name { get; private set; }
        public string bannerFilename { get; private set; }
        public string Description { get; private set; }
        public uint[] questIDs { get; private set; }
        public uint openClearQuestGroupID { get; private set; }

        public QuestGroupModel(uint id, string name, string bannerPath, string description,uint[] questIDs, uint openClearID)
        {
            this.ID = id;
            this.Name = name;
            this.bannerFilename = bannerPath;
            this.Description = description;
            this.questIDs = questIDs;
            this.openClearQuestGroupID = openClearID;
        }

        public bool IsOpen()
        {            
            if (openClearQuestGroupID == OpenValue)
            {
                return true;
            }

            var playerQuestRepository = new PlayerQuestRepository();
            var questGroupRepository = new QuestGroupRepository();
            foreach(var questID in questGroupRepository.Get(openClearQuestGroupID).questIDs) {
                if (!playerQuestRepository.Get(questID).IsClear())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
