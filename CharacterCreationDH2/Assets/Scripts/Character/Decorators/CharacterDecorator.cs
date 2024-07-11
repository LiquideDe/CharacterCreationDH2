using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CharacterDecorator
{
    protected ICharacter _character;
    protected List<GameStat.Inclinations> _inclinations = new List<GameStat.Inclinations>();
    protected List<Skill> _skills = new List<Skill>();
    protected List<Talent> _talents = new List<Talent>();
    protected List<Equipment> _equipment = new List<Equipment>();
    protected List<MechImplant> _mechImplants = new List<MechImplant>();
    protected List<PsyPower> _psyPowers = new List<PsyPower>();

    public CharacterDecorator(ICharacter character)
    {
        _character = character;
    }

    public List<PsyPower> PsyPowers => GetPsyPowers();
    public List<GameStat.Inclinations> Inclinations => GetInclinations();

    public List<Skill> Skills => GetSkills();

    public List<Talent> Talents => GetTalents();

    public List<MechImplant> Implants => GetMechImplants();

    public List<Equipment> Equipments => GetEquipments();

    private List<Skill> GetSkills()
    {
        List<Skill> skills = new List<Skill>(_character.Skills);

        List<Skill> unionSkills = new List<Skill>();

        unionSkills.AddRange(_skills);

        foreach (Skill skill in skills)
            if (TryNotDouble(_skills, skill.Name))
                unionSkills.Add(skill);

        return unionSkills;
    }

    private List<Talent> GetTalents()
    {
        List<Talent> talents = new List<Talent>(_character.Talents);

        List<Talent> unionTalent = new List<Talent>();

        unionTalent.AddRange(_talents);

        foreach (Talent talent in talents)
            if (TryNotDouble(_talents, talent.Name))
                unionTalent.Add(talent);

        return unionTalent;
    }

    private List<Equipment> GetEquipments()
    {
        List<Equipment> equipments = new List<Equipment>(_character.Equipments);

        List<Equipment> unionEquipment = new List<Equipment>();

        unionEquipment.AddRange(_equipment);

        foreach (Equipment equipment in equipments)
            if (TryNotDouble(_equipment,equipment.Name))
                unionEquipment.Add(equipment);

        return unionEquipment;
    }

    private List<MechImplant> GetMechImplants()
    {
        List<MechImplant> mechImplants = new List<MechImplant>(_character.Implants);

        List<MechImplant> unionImplants = new List<MechImplant>();

        unionImplants.AddRange(_mechImplants);

        foreach (MechImplant implant in mechImplants)
            if (TryNotDouble(_mechImplants, implant.Name))
                unionImplants.Add(implant);

        return unionImplants;
    }

    private List<GameStat.Inclinations> GetInclinations()
    {
        List<GameStat.Inclinations> inclinations = new List<GameStat.Inclinations>(_character.Inclinations);

        List<GameStat.Inclinations> unionInclination = new List<GameStat.Inclinations>();

        unionInclination.AddRange(_inclinations);

        foreach(GameStat.Inclinations inclination in inclinations)        
            if (!unionInclination.Contains(inclination))
                unionInclination.Add(inclination);        

        return unionInclination;
    }

    private List<PsyPower> GetPsyPowers()
    {
        List<PsyPower> psyPowers = new List<PsyPower>(_character.PsyPowers);

        List<PsyPower> unionPsyPowers = new List<PsyPower>();

        unionPsyPowers.AddRange(_psyPowers);

        foreach(PsyPower psyPower in psyPowers)
        {
            if (TryNotDouble(_psyPowers,psyPower.Name))
                unionPsyPowers.Add(psyPower);
        }

        return unionPsyPowers;        
    }

    private bool TryNotDouble<T>(List<T> listCharacter, string name) where T : IName
    {
        foreach(T t in listCharacter)
            if (string.Compare(name, t.Name, true) == 0)
                return false;
        return true;
    }

    
}
