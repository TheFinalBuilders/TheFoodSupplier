using UnityEngine;
using System.Collections;
using TFS.Repository;

namespace TFS.Model
{
    public class QuestModel : IModel
    {
        private readonly uint OpenValue = 9999999;

        public enum QuestDifficulty
        {
            morning, evening, night
        };

        public uint ID { get; private set; }
        public string Name { get; private set; }
        public string bannerFilename { get; private set; }
        public QuestDifficulty Difficulty { get; private set; }
        public int ClearScore { get; private set; }
        public uint openClearQuestID { get; private set; }

        public QuestModel(uint id, string name, string bannerPath, QuestDifficulty difficulty, int clearScore, uint openClearQuestID)
        {
            this.ID = id;
            this.Name = name;
            this.bannerFilename = bannerPath;
            this.Difficulty = difficulty;
            this.ClearScore = clearScore;
            this.openClearQuestID = openClearQuestID;
        }

        public float GetDifficulySpeed()
        {
            switch (this.Difficulty)
            {
                case QuestDifficulty.morning:
                    return 1.0f;
                case QuestDifficulty.evening:
                    return 1.2f;
                case QuestDifficulty.night:
                    return 1.5f;
                default:
                    return 1.0f;
            }
        }

        public int GetDifficulyScoreResult(int score){
            if(score < this.ClearScore){
                return 0;
            }else if(score < 4000){
                return 1;
            }else if(score < 7000){
                return 2;
            } else {
                return 3;
            }
        }

        public bool IsOpen()
        {
            if (openClearQuestID == OpenValue) {
                return true;
            }

            var playerQuestRepository = new PlayerQuestRepository();
            if (!playerQuestRepository.Get(openClearQuestID).IsClear())
            {
                return false;
            }
            return true;
        }
    }
}
