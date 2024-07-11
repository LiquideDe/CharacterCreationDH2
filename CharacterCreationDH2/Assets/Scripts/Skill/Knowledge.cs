using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knowledge : Skill
{
    private string _nameKnowledge;

    public string NameKnowledge { get => _nameKnowledge; }
    public string InternalNameKnowledge { get => _internalName; }
    public Knowledge(JSONSkillLoader skillLoader, string path)
        : base (skillLoader, path)
    {
        _nameKnowledge = _name;
        _isKnowledge = true;
    }

    public Knowledge(Knowledge skill, int lvl) : base(skill, lvl)
    {
        _nameKnowledge = skill.NameKnowledge;
        _isKnowledge = skill.IsKnowledge;
    }
}
