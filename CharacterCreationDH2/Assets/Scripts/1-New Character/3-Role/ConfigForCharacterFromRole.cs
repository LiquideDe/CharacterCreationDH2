using System.Collections.Generic;

public class ConfigForCharacterFromRole
{
    private List<GameStat.Inclinations> _inclinations = new List<GameStat.Inclinations>();
    private List<Talent> _talents = new List<Talent>();
    public List<Talent> Talents => _talents;
    public string NameRole { get; set; }
    public string BonusRole { get; set; }
    public List<GameStat.Inclinations> Inclinations => _inclinations;
    

    public void SetInclinations(List<GameStat.Inclinations> inclinations)
    {
        _inclinations = new List<GameStat.Inclinations>(inclinations);
    }

    public void SetTalents(List<Talent> talents)
    {
        _talents.AddRange(talents);
    }

}
