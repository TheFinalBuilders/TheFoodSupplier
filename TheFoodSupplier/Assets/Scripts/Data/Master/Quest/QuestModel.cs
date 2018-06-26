using UnityEngine;
using System.Collections;

namespace TFS.Model
{
    public class QuestModel : IModel
    {
        public uint ID { get; private set; }
        public string Name { get; private set; }
        public string bannerFilename { get; private set; }

        public QuestModel(uint id, string name, string bannerPath)
        {
            this.ID = id;
            this.Name = name;
            this.bannerFilename = bannerPath;
        }
    }

}
