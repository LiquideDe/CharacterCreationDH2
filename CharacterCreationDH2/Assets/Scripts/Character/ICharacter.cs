using System.Collections.Generic;

public interface ICharacter
{
    public List<Equipment> Equipments { get; }
    public int Age { get; }
    public int FatePoint { get; }
    public int InsanityPoints { get; }
    public int Wounds { get; }
    public int CorruptionPoints { get; }
    public int PsyRating { get; }
    public int HalfMove { get; }
    public int FullMove { get; }
    public int Natisk { get; }
    public int Fatigue { get; }
    public float CarryWeight { get; }
    public float LiftWeight { get; }
    public float PushWeight { get; }
    public int ExperienceTotal { get; }
    public int ExperienceUnspent { get; }
    public int ExperienceSpent { get; }
    public List<Characteristic> Characteristics { get; }
    public List<GameStat.Inclinations> Inclinations { get; }
    public List<Skill> Skills { get; }
    public List<Talent> Talents { get; }
    public List<MechImplant> Implants { get; }
    public List<string> MentalDisorders { get; }
    public int Run { get; }
    public string BonusBack { get; }
    public List<string> Mutation { get; }
    public List<PsyPower> PsyPowers { get; }
    public List<Feature> Features { get; }
    public string Name { get; }
    public string Background { get; }
    public string Role { get; }
    public string AgeText { get; }
    public string Prophecy { get; }
    public string Constitution { get; }
    public string Hair { get; }
    public string Eyes { get; }
    public string Skeen { get; }
    public string PhysFeatures { get; }
    public string MemoryOfHome { get; }
    public string MemoryOfBackground { get; }
    public string Gender { get; }
    public string Homeworld { get; }
    public string Elite { get; }
    public string Tradition { get; }
    public int BonusToughness { get; }
    public ICharacter GetCharacter { get; }
    public string BonusHomeworld { get; }

    public string BonusRole { get; }

}
    

