using System.Collections.Generic;

namespace CharacterCreation
{
    public interface ICharacter
    {
        public List<Equipment> Equipments { get; }
        public int Age { get; }
        public int FatePoint { get; }
        public int InsanityPoints { get; }
        public int Wounds { get; }
        public int CorruptionPoints { get; }
        public int PsyRating { get; }
        public int ExperienceTotal { get; }
        public int ExperienceUnspent { get; }
        public int ExperienceSpent { get; }
        public List<Characteristic> Characteristics { get; }
        public List<GameStat.Inclinations> Inclinations { get; }
        public List<Skill> Skills { get; }
        public List<Talent> Talents { get; }
        public List<MechImplant> Implants { get; }
        public List<string> MentalDisorders { get; }
        public string BonusBack { get; }
        public List<string> Mutations { get; }
        public List<PsyPower> PsyPowers { get; }
        public List<Trait> Traits { get; }
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
        public ICharacter GetCharacter { get; }
        public string BonusHomeworld { get; }

        public string BonusRole { get; }

    }
}

    

