using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;

namespace TFS.Repository
{
    public class PlayerQuestRepository : IRepository<PlayerQuestModel>
    {
        static List<PlayerQuestModel> playerQuestModels = null;

        public PlayerQuestRepository()
        {
            if (playerQuestModels != null) {
                return;
            }

            playerQuestModels = new List<PlayerQuestModel>();
            for (uint i = 0; i < QuestGroupRepository.QuestCount; i++)
            {
                playerQuestModels.Add(new PlayerQuestModel(
                    i,
                    0,
                    0
                ));
            }
        }

        public PlayerQuestModel Get(uint id)
        {
            return playerQuestModels[(int)id];
        }

        public PlayerQuestModel Set(uint id, PlayerQuestModel model)
        {
            return playerQuestModels[(int)id] = model;
        }

        public IEnumerable<PlayerQuestModel> GetALL()
        {
            return playerQuestModels;
        }
    }
}
