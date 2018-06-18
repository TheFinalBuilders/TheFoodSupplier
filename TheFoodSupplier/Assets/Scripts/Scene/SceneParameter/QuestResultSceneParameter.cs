using UnityEngine;
using System.Collections;
using TFS.Model;
using TFS.UI;

public class QuestResultSceneParameter : ISceneParameter
{
    public CharacterModel Chracter { get; private set; }
    public QuestGroupModel QuestGroup { get; private set; }
    public QuestModel Quest { get; private set; }
    public int Score { get; private set; }
    public int StarCount { get; private set; }
    public QuestResultType resultType { get; private set; }

    public QuestResultSceneParameter(
        CharacterModel character,
        QuestGroupModel questGroup,
        QuestModel quest,
        int score,
        int starCount,
        QuestResultType resultType)
    {
        this.Chracter = character;
        this.QuestGroup = questGroup;
        this.Quest = quest;
        this.Score = score;
        this.StarCount = starCount;
        this.resultType = resultType;
    }
}
