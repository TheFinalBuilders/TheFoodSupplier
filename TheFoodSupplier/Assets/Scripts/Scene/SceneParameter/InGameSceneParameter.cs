using UnityEngine;
using System.Collections;
using TFS.Model;

public class InGameSceneParameter : ISceneParameter
{
    public CharacterModel Character { get; private set; }
    public QuestGroupModel QuestGroup { get; private set; }
    public QuestModel Quest { get; private set; }

    public InGameSceneParameter(CharacterModel character, QuestGroupModel questGroup, QuestModel quest)
    {
        this.Character = character;
        this.QuestGroup = questGroup;
        this.Quest = quest;
    }
}
