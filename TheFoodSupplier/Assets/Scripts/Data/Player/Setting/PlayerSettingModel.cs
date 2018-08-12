using UnityEngine;
using System.Collections;

namespace TFS.Model
{
    public class PlayerSettingModel : IModel
    {
        public uint ID { get; private set; }
        public uint CharacterID { get; set; }

        public PlayerSettingModel(uint id, uint characterID)
        {
            this.ID = id;
            this.CharacterID = characterID;
        }
    }
}