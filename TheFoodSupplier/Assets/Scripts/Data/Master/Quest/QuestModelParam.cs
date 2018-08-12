using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.Model;

[CreateAssetMenu]
public class QuestModelParam : ScriptableObject
{
    public uint ID;
    public string Name;
    public string bannerFilename;
    public QuestModel.QuestDifficulty Difficulty;
    public int ClearScore;
}