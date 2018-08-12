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
        public int ClearScore { get; private set; }

        public QuestModel(uint id, string name, string bannerPath, QuestDifficulty difficulty, int clearScore)
        {
            this.ID = id;
            this.Name = name;
            this.bannerFilename = bannerPath;
            this.Difficulty = difficulty;
            this.ClearScore = clearScore;
        }

        public float GetDifficulySpeed(){
            switch(this.Difficulty){
                case QuestDifficulty.morning :
                    return 1.0f;
                case QuestDifficulty.evening :
                    return 1.2f;
                case QuestDifficulty.night :
                    return 1.5f;
                default :
                    return 1.0f;
            }
        }

        public int GetDifficulyScoreResult(int score){
            if(score < this.ClearScore){
                return 0;
            }else if(score < 4000){
                return 1;
            }else if(score < 5000){
                return 2;
            }else{
                return 3;
            }
        }
    }

}
