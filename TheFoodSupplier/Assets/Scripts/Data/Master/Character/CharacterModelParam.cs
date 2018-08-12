using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.Model;

[CreateAssetMenu]
public class CharacterModelParam : ScriptableObject
{ 
        public uint id;
        public new string name;
        [Multiline] public string description;
        public CharacterType type;
        public string iconPath;
}