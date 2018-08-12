using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.Model;

[CreateAssetMenu]
public class QuestGroupModelParam : ScriptableObject
{
    public uint ID;
    public string Name;
    public string bannerFilename;
    [Multiline(2)] public string Description;
    public uint[] questIDs;
}