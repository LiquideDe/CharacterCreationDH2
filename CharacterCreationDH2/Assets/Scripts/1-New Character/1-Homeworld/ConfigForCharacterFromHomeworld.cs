using System.Collections.Generic;

public class ConfigForCharacterFromHomeworld
{
    public string HomeworldName { get; set; }

    public int Fate { get; set; }

    public int Wound { get; set; }

    public int Age { get; set; }

    public string AgeText { get; set; }

    public string Hair { get; set; }

    public string Tradition { get; set; }

    public string Skeen {get; set;}

    public string Remember { get; set; }

    public string Body { get; set; }

    public string Eyes { get; set; }

    public string Phys { get; set; }

    public string BonusHomeworld { get; set; }

    public GameStat.Inclinations Inclination { get; set; }

    public GameStat.CharacteristicName AdvantageCharacteristicFirst { get; set; }
    public GameStat.CharacteristicName AdvantageCharacteristicSecond { get; set; }
    public GameStat.CharacteristicName DisadvantageCharacteristic { get; set; }

    private List<Skill> _skills = new List<Skill>();

    public List<Skill> Skills => _skills;

    private List<string> talents = new List<string>();

    public List<string> Talents => talents;

    public void SetSkills(List<Skill> skills)
    {
        _skills = new List<Skill>(skills);

        foreach (Skill skill in _skills)
        {
            skill.LvlLearned = 1;
        }
    }

}
