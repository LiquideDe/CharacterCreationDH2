using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigForCharacterFromBackground
{
    private List<Skill> _skills = new List<Skill>();
    private List<Talent> _talents = new List<Talent>();
    private List<Equipment> _equipments = new List<Equipment>();
    private List<MechImplant> _mechImplants = new List<MechImplant>();

    public string Name { get; set; }

    public List<Talent> Talents => _talents;

    public List<Skill> Skills => _skills;

    public List<Equipment> Equipments => _equipments;

    public GameStat.Inclinations Inclination { get; set; }

    public List<MechImplant> MechImplants => _mechImplants;

    public string RememberThing { get; set; }

    public string Bonus { get; set; }

    public void SetSkills(List<Skill> skills)
    {
        _skills = new List<Skill>(skills);
        
        foreach(Skill skill in _skills)
        {
            skill.LvlLearned = 1;
        }
    }

    public void SetTalents(List<Talent> talents)
    {
        _talents = new List<Talent>(talents);
    }

    public void SetEquipment(List<Equipment> equipments)
    {
        _equipments = new List<Equipment>(equipments);
    }

    public void SetImplants(List<MechImplant> implants)
    {
        _mechImplants = new List<MechImplant>(implants);
    }

}
