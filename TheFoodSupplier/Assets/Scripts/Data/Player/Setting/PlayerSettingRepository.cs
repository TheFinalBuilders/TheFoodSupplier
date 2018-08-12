using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TFS.Model;
using System.Linq;

namespace TFS.Repository
{
    public class PlayerSettingRepository : IRepository<PlayerSettingModel>
    {
        static PlayerSettingModel playerSettingModel = null;

        public PlayerSettingRepository()
        {
            if (playerSettingModel == null)
            {
                var characterRepository = new CharacterRepository();
                playerSettingModel = new PlayerSettingModel(0, characterRepository.GetALL().First().ID);
            }
        }

        public PlayerSettingModel Get(uint id)
        {
            return playerSettingModel;
        }

        public PlayerSettingModel Set(uint id, PlayerSettingModel model)
        {
            playerSettingModel = model;
            return playerSettingModel;
        }

        public IEnumerable<PlayerSettingModel> GetALL()
        {
            var list = new List<PlayerSettingModel>();
            list.Add(playerSettingModel);
            return list;
        }
    }
}
