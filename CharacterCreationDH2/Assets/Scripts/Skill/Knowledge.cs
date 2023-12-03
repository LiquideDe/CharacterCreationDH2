using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knowledge : Skill
{
    private GameStat.KnowledgeName nameKnowledge;
    private int lvlLearned;

    public string NameKnowledge { get => GameStat.knowledgeTranslation[nameKnowledge]; }
    public GameStat.KnowledgeName InternalNameKnowledge { get => nameKnowledge; }
    public Knowledge(GameStat.KnowledgeName name, GameStat.SkillName nameSkill, GameStat.Inclinations firstInclination, GameStat.Inclinations secondInclination, string description)
        : base (nameSkill, firstInclination, secondInclination, description)
    {
        nameKnowledge = name;
    }

    public Knowledge(GameStat.KnowledgeName name, GameStat.SkillName nameSkill, int lvlLearned)
        : base (nameSkill, lvlLearned)
    {
        nameKnowledge = name;
    }

}
