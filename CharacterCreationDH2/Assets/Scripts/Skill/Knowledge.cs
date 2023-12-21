using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knowledge : Skill
{
    private string nameKnowledge;

    public string NameKnowledge { get => nameKnowledge; }
    public string InternalNameKnowledge { get => internalName; }
    public Knowledge(JSONSkillLoader skillLoader, string path)
        : base (skillLoader, path)
    {
        nameKnowledge = name;
        isKnowledge = true;
    }

    public Knowledge(string name, string nameSkill, int lvlLearned)
        : base (nameSkill, lvlLearned)
    {
        nameKnowledge = name;
    }

}
