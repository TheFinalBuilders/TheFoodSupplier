using UnityEngine;
using System.Collections;
using TFS.Repository;

namespace TFS.Model
{
    public enum CharacterType
    {
        Normal = 0,
        Boomerang = 1,
        Diffusion = 2,
    };

    public class CharacterModel : IModel
    {
        private readonly uint OpenValue = 9999999;

        public uint ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public CharacterType Type { get; private set; }
        public string iconPath { get; private set; }
        public uint openClearQuestID { get; private set; }

        public CharacterModel(uint id, string name, string description, CharacterType type, string iconPath, uint openQuestID)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.iconPath = iconPath;
            this.openClearQuestID = openQuestID;
        }

        public bool IsOpen()
        {
            if (openClearQuestID == OpenValue)
            {
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