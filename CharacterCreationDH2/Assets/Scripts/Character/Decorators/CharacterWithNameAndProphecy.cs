using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWithNameAndProphecy : CharacterDecorator, ICharacter
{
    private string _gender, _prophecy, _name;
    private int _fatepoint;
    public CharacterWithNameAndProphecy(ICharacter character) : base(character)
    {
        _fatepoint = character.FatePoint;
    }

    public int Age => _character.Age;

    public int FatePoint => _fatepoint;

    public int InsanityPoints => _character.InsanityPoints;

    public int Wounds => _character.Wounds;

    public int CorruptionPoints => _character.CorruptionPoints;

    public int PsyRating => _character.PsyRating;

    public int ExperienceTotal => _character.ExperienceTotal;

    public int ExperienceUnspent => _character.ExperienceUnspent;

    public int ExperienceSpent => _character.ExperienceSpent;

    public List<Characteristic> Characteristics => _character.Characteristics;

    public List<string> MentalDisorders => _character.MentalDisorders;

    public string BonusBack => _character.BonusBack;

    public List<string> Mutation => _character.Mutation;

    public string Name => _name;

    public string Background => _character.Background;

    public string Role => _character.Role;

    public string AgeText => _character.AgeText;

    public string Prophecy => _prophecy;

    public string Constitution => _character.Constitution;

    public string Hair => _character.Hair;

    public string Eyes => _character.Eyes;

    public string Skeen => _character.Skeen;

    public string PhysFeatures => _character.PhysFeatures;

    public string MemoryOfHome => _character.MemoryOfHome;

    public string MemoryOfBackground => _character.MemoryOfBackground;

    public string Gender => _gender;

    public string Homeworld => _character.Homeworld;

    public string Elite => "";

    public string Tradition => _character.Tradition;

    public ICharacter GetCharacter => _character;

    public string BonusHomeworld => _character.BonusHomeworld;

    public string BonusRole => _character.BonusRole;

    public void SetName(string name) => _name = name;

    public void SetGender(string gender) => _gender = gender;

    public void SetProphecy(string prophecy) => _prophecy = prophecy;

    public void IncreaseFatePoint(int amount) => _fatepoint += amount;
}
