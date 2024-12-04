using System.Collections.Generic;
using System.Linq;

public class CharacterWithHomeworld : CharacterDecorator,ICharacter
{
    
    private string _ageText;
    private string _constitution;
    private string _physFeatures;
    private string _memoryOfHome;
    private string _hair;
    private string _eyes;
    private string _skeen;
    private string _homeworld;
    private int _wounds, _fatepoint;
    private int _age;
    private GameStat.CharacteristicName _advantageCharacteristicFirst;
    private GameStat.CharacteristicName _advantageCharacteristicSecond;
    private GameStat.CharacteristicName _disadvantageCharacteristic;
    private string _tradition;
    private string _bonusHomeworld;

    

    public CharacterWithHomeworld(ICharacter character) : base(character) { }

    public int Age => _age;

    public int InsanityPoints => _character.InsanityPoints;

    public int Wounds => _wounds;

    public int CorruptionPoints => _character.CorruptionPoints;

    public int PsyRating => _character.PsyRating;

    public int ExperienceTotal => _character.ExperienceTotal;

    public int ExperienceUnspent => _character.ExperienceUnspent;

    public int ExperienceSpent => _character.ExperienceSpent;

    public List<Characteristic> Characteristics => _character.Characteristics;    

    public List<string> MentalDisorders => _character.MentalDisorders;

    public string BonusBack => _character.BonusBack;

    public List<string> Mutation => _character.Mutation;    

    public string Background => throw new System.NotImplementedException();

    public string Role => throw new System.NotImplementedException();

    public string AgeText => _ageText;

    public string Constitution => _constitution;

    public string Hair => _hair;

    public string Eyes => _eyes;

    public string Skeen => _skeen;

    public string PhysFeatures => _physFeatures;

    public string MemoryOfHome => _memoryOfHome;

    public string MemoryOfBackground => throw new System.NotImplementedException();

    public string Gender => throw new System.NotImplementedException();

    public string Homeworld => _homeworld;

    public string Elite => throw new System.NotImplementedException();

    public string Tradition => _tradition;

    public ICharacter GetCharacter => _character;

    public GameStat.CharacteristicName AdvantageCharacteristicFirst => _advantageCharacteristicFirst;
    public GameStat.CharacteristicName AdvantageCharacteristicSecond => _advantageCharacteristicSecond; 
    public GameStat.CharacteristicName DisadvantageCharacteristic => _disadvantageCharacteristic;

    public string BonusHomeworld => _bonusHomeworld;

    public string BonusRole => throw new System.NotImplementedException();

    public int FatePoint => _fatepoint;

    public string Name => throw new System.NotImplementedException();

    public string Prophecy => throw new System.NotImplementedException();

    public void SetHomeWorld(ConfigForCharacterFromHomeworld config)
    {
        _homeworld = config.HomeworldName;
        _wounds = config.Wound;
        _inclinations.Add(config.Inclination);
        if (config.Skills.Count > 0)
        {
            foreach (Skill skill in config.Skills)
            {
                _skills.Add(skill);
            }                
        }

        if (config.Talents.Count > 0)
        {
            foreach (string talent in config.Talents)
                 _talents.Add(new Talent(talent));
        }

        _ageText = config.AgeText;
        _constitution = config.Body;
        _physFeatures = config.Phys;
        _memoryOfHome = config.Remember;
        _hair = config.Hair;
        _eyes = config.Eyes;
        _skeen = config.Skeen;
        _fatepoint = config.Fate;
        _age = config.Age;
        _advantageCharacteristicFirst = config.AdvantageCharacteristicFirst;
        _advantageCharacteristicSecond = config.AdvantageCharacteristicSecond;
        _disadvantageCharacteristic = config.DisadvantageCharacteristic;
        _bonusHomeworld = config.BonusHomeworld;
        _tradition = config.Tradition;
        
    }

    
}
