using UnityEngine;
using System.Collections;

namespace TFS.Model
{
    public class QuestModel : IModel
    {
        public enum QuestDifficulty
        {
            morning,evening,night
        };

        public uint ID { get; private set; }
        public string Name { get; private set; }
        public string bannerFilename { get; private set; }
        public QuestDifficulty Difficulty { get; private set; }

        public QuestModel(uint id, string name, string bannerPath, QuestDifficulty difficulty)
        {
            this.ID = id;
            this.Name = name;
            this.bannerFilename = bannerPath;
            this.Difficulty = difficulty;
        }
    }

}
