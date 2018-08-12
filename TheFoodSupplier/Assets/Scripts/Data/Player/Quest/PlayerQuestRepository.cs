using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;
using System.Linq;

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
            var questRepository = new QuestRepository();
            foreach (var quest in questRepository.GetALL())
            {
                playerQuestModels.Add(new PlayerQuestModel(
                    quest.ID,
                    0,
                    0
                ));
            }
        }

        public PlayerQuestModel Get(uint id)
        {
            return playerQuestModels.Find((PlayerQuestModel obj) => obj.ID == id);
        }

        public PlayerQuestModel Set(uint id, PlayerQuestModel model)
        {
            for (int i = 0; i < playerQuestModels.Count(); i++) {
                if (playerQuestModels[i].ID == id) {
                    playerQuestModels[i] = model;
                    return model;
                }
            }
            return null;
        }

        public IEnumerable<PlayerQuestModel> GetALL()
        {
            return playerQuestModels;
        }
    }
}
