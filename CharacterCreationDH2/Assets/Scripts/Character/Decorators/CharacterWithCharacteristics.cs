using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWithCharacteristics : CharacterDecorator, ICharacter
{
    private List<Characteristic> _characteristics;
    private List<float> _parametrsForWeight = new List<float>() { 0.9f, 2.25f, 4.5f, 9f, 18f, 27f, 36f, 45f, 56f, 67f, 78f, 90f, 112f, 225f, 337f, 450f, 675f, 900f, 1350f, 1800f, 2250f };
    public CharacterWithCharacteristics(ICharacter character) : base(character)
    {
    }

    public int Age => _character.Age;

    public int InsanityPoints => _character.InsanityPoints;

    public int Wounds => _character.Wounds;

    public int CorruptionPoints => _character.CorruptionPoints;

    public int PsyRating => _character.PsyRating;

    public int HalfMove => GetHalfMove();

    public int FullMove => GetHalfMove() * 2;

    public int Natisk => GetHalfMove() * 3;

    public int Fatigue => _characteristics[3].Amount / 10 + _characteristics[7].Amount / 10;

    public float CarryWeight => GetCarryWeight();

    public float LiftWeight => GetCarryWeight() * 2;

    public float PushWeight => GetCarryWeight() * 4;

    public int ExperienceTotal => _character.ExperienceTotal;

    public int ExperienceUnspent => _character.ExperienceUnspent;

    public int ExperienceSpent => _character.ExperienceSpent;

    public List<Characteristic> Characteristics => _characteristics;

    public List<string> MentalDisorders => _character.MentalDisorders;

    public int Run => GetHalfMove() * 6;

    public string BonusBack => _character.BonusBack;

    public List<string> Mutation => _character.Mutation;

    public string Background => _character.Background;

    public string Role => _character.Role;

    public string AgeText => _character.AgeText;

    public string Constitution => _character.Constitution;

    public string Hair => _character.Hair;

    public string Eyes => _character.Eyes;

    public string Skeen => _character.Skeen;

    public string PhysFeatures => _character.PhysFeatures;

    public string MemoryOfHome => _character.MemoryOfHome;

    public string MemoryOfBackground => _character.MemoryOfBackground;

    public string Gender => _character.Gender;

    public string Homeworld => _character.Homeworld;

    public string Elite => _character.Elite;

    public string Tradition => _character.Tradition;

    public int BonusToughness => (int)_characteristics[3].Amount/10;

    public ICharacter GetCharacter => _character;

    public string BonusHomeworld => _character.BonusHomeworld;

    public string BonusRole => _character.BonusRole;

    public int FatePoint => _character.FatePoint;

    public string Name => _character.Name;

    public string Prophecy => _character.Prophecy;

    public void SetCharacteristics(List<int> characteristics)
    {
        _characteristics = new List<Characteristic>();
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.WeaponSkill, GameStat.Inclinations.Weapon, GameStat.Inclinations.Offense)); //0
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.BallisticSkill, GameStat.Inclinations.Ballistic, GameStat.Inclinations.Finesse)); //1
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Strength, GameStat.Inclinations.Strength, GameStat.Inclinations.Offense)); //2
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Toughness, GameStat.Inclinations.Toughness, GameStat.Inclinations.Defense)); //3
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Agility, GameStat.Inclinations.Agility, GameStat.Inclinations.Finesse)); //4
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Intelligence, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge)); //5
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Perception, GameStat.Inclinations.Perception, GameStat.Inclinations.Fieldcraft)); //6
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Willpower, GameStat.Inclinations.Willpower, GameStat.Inclinations.Psyker)); //7
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Fellowship, GameStat.Inclinations.Fellowship, GameStat.Inclinations.Social)); //8
        _characteristics.Add(new Characteristic(GameStat.CharacteristicName.Influence, GameStat.Inclinations.None, GameStat.Inclinations.None));

        for(int i = 0; i < characteristics.Count; i++)
        {
            _characteristics[i].Amount = characteristics[i];
        }
    }

    private int GetHalfMove() => _characteristics[4].Amount / 10;

    private int GetForce() => _characteristics[2].Amount / 10 + _characteristics[3].Amount / 10;

    private float GetCarryWeight() => _parametrsForWeight[GetForce()];


}
