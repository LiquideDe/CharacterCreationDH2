public class Knowledge : Skill
{
    private string _nameKnowledge;
    public string NameKnowledge { get => _nameKnowledge; }
    public Knowledge(JSONSkillLoader skillLoader, string type)
        : base (skillLoader, type)
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
