using UnityEngine;
using System.Collections;

namespace TFS.Model
{
    public class QuestGroupModel : IModel
    {
        public uint ID { get; private set; }
        public string Name { get; private set; }
        public string bannerFilename { get; private set; }
        public uint[] questIDs { get; private set; }

        public QuestGroupModel(uint id, string name, string bannerPath,uint[] questIDs)
        {
            this.ID = id;
            this.Name = name;
            this.bannerFilename = bannerPath;
            this.questIDs = questIDs;
        }
    }

}
