using UnityEngine;
using System.Collections;

namespace TFS.Model
{
    public class PlayerQuestModel : IModel
    {
        public uint ID { get; private set; }
        public int CurrentStarNum { get; set; }
        public float CurrentScore { get; set; }

        public PlayerQuestModel(uint id, int currentStarNum, float maxScore)
        {
            this.ID = id;
            this.CurrentStarNum = currentStarNum;
            this.CurrentScore = maxScore;
        }

        public bool IsClear() 
        {
            return CurrentStarNum > 0;
        }
    }
}