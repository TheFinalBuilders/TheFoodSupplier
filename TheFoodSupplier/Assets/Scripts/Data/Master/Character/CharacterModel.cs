using UnityEngine;
using System.Collections;

namespace TFS.Model
{
    public enum CharacterType
    {
        Normal = 0,
        Boomerang = 1
    };

    public class CharacterModel : IModel
    {
        public uint ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public CharacterType Type { get; private set; }
        public string iconPath { get; private set; }

        public CharacterModel(uint id, string name, string description, CharacterType type, string iconPath)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.iconPath = iconPath;
        }
    }

}