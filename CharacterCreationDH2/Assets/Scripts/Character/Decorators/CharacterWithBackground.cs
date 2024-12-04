using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWithBackground : CharacterDecorator,ICharacter
{
    private string _bonusBack, _nameBackground, _memoryBackground;
    private int _psyRating;

    public CharacterWithBackground(ICharacter character) : base (character) { }

    public int Age => _character.Age;

    public int InsanityPoints => _character.InsanityPoints;

    public int Wounds => _character.Wounds;

    public int CorruptionPoints => _character.CorruptionPoints;

    public int PsyRating => _psyRating;

    public int ExperienceTotal => _character.ExperienceTotal;

    public int ExperienceUnspent => _character.ExperienceUnspent;

    public int ExperienceSpent => _character.ExperienceSpent;

    public List<Characteristic> Characteristics => _character.Characteristics;

    public List<string> MentalDisorders => _character.MentalDisorders;

    public string BonusBack => _bonusBack;

    public List<string> Mutation => _character.Mutation;

    public string Background => _nameBackground;

    public string Role => throw new System.NotImplementedException();

    public string AgeText => _character.AgeText;

    public string Constitution => _character.Constitution;

    public string Hair => _character.Hair;

    public string Eyes => _character.Eyes;

    public string Skeen => _character.Skeen;

    public string PhysFeatures => _character.PhysFeatures;

    public string MemoryOfHome => _character.MemoryOfHome;

    public string MemoryOfBackground => _memoryBackground;

    public string Gender => throw new System.NotImplementedException();

    public string Homeworld => _character.Homeworld;

    public string Elite => _character.Elite;

    public string Tradition => _character.Tradition;

    public ICharacter GetCharacter => _character;

    public string BonusHomeworld => _character.BonusHomeworld;

    public string BonusRole => throw new System.NotImplementedException();

    public int FatePoint => _character.FatePoint;

    public string Name => throw new System.NotImplementedException();

    public string Prophecy => throw new System.NotImplementedException();

    public void SetBackground(ConfigForCharacterFromBackground config)
    {
        _nameBackground = config.Name;
        _memoryBackground = config.RememberThing;
        _bonusBack = config.Bonus;

        foreach(Skill skill in config.Skills)        
            if(!TryFindDoubleSkill(skill))
                _skills.Add(skill);
        

        foreach(Talent talent in config.Talents)
        {
            _talents.Add(talent);
            if (string.Compare(talent.Name, "Псайкер") == 0)
                _psyRating = 1;
        }

        foreach(Equipment equipment in config.Equipments)        
            _equipment.Add(equipment);
        

        _inclinations.Add(config.Inclination);

        foreach(MechImplant implant in config.MechImplants)        
            _mechImplants.Add(implant);
        

        foreach (Trait trait in config.Traits)
            _traits.Add(trait);
    }

    private bool TryFindDoubleSkill(Skill skill)
    {
        foreach(Skill skill1 in _skills)
        {
            if (string.Compare(skill1.Name, skill.Name, true) == 0)
                return true;
        }

        return false;
    }

    
}
