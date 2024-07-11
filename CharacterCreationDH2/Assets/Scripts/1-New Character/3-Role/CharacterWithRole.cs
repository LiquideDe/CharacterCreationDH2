using System.Collections.Generic;

public class CharacterWithRole : CharacterDecorator, ICharacter
{
    private int _psyRating;
    private string _roleName;
    private string _bonusRole;

    public CharacterWithRole(ICharacter character) : base(character) { _psyRating = character.PsyRating; }

    public int Age => _character.Age;

    public int InsanityPoints => _character.InsanityPoints;

    public int Wounds => _character.Wounds;

    public int CorruptionPoints => _character.CorruptionPoints;

    public int PsyRating => _psyRating;

    public int HalfMove => throw new System.NotImplementedException();

    public int FullMove => throw new System.NotImplementedException();

    public int Natisk => throw new System.NotImplementedException();

    public int Fatigue => _character.Fatigue;

    public float CarryWeight => throw new System.NotImplementedException();

    public float LiftWeight => throw new System.NotImplementedException();

    public float PushWeight => throw new System.NotImplementedException();

    public int ExperienceTotal => _character.ExperienceTotal;

    public int ExperienceUnspent => _character.ExperienceUnspent;

    public int ExperienceSpent => _character.ExperienceSpent;

    public List<Characteristic> Characteristics => _character.Characteristics;

    public List<string> MentalDisorders => _character.MentalDisorders;

    public int Run => throw new System.NotImplementedException();

    public string BonusBack => _character.BonusBack;

    public List<string> Mutation => _character.Mutation;

    public List<Feature> Features => _character.Features;

    public string Background => _character.Background;

    public string Role => _roleName;

    public string AgeText => _character.AgeText;

    public string Constitution => _character.Constitution;

    public string Hair => _character.Hair;

    public string Eyes => _character.Eyes;

    public string Skeen => _character.Skeen;

    public string PhysFeatures => _character.PhysFeatures;

    public string MemoryOfHome => _character.MemoryOfHome;

    public string MemoryOfBackground => _character.MemoryOfBackground;

    public string Gender => throw new System.NotImplementedException();

    public string Homeworld => _character.Homeworld;

    public string Elite => _character.Elite;

    public string Tradition => _character.Tradition;

    public int BonusToughness => _character.BonusToughness;

    public ICharacter GetCharacter => _character;

    public string BonusHomeworld => _character.BonusHomeworld;

    public string BonusRole => _bonusRole;

    public int FatePoint => _character.FatePoint;

    public string Name => throw new System.NotImplementedException();

    public string Prophecy => throw new System.NotImplementedException();

    public void SetRole(ConfigForCharacterFromRole config)
    {
        _roleName = config.NameRole;
        _bonusRole = config.BonusRole;

        foreach(GameStat.Inclinations inclination in config.Inclinations)
        {            
            _inclinations.Add(inclination);
        }

        foreach(Talent talent in config.Talents)
        {
            _talents.Add(talent);
            if (string.Compare(talent.Name, "Псайкер") == 0)
                _psyRating = 1;
        }

        
    }
}
