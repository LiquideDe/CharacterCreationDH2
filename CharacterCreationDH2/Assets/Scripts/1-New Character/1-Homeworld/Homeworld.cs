using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;
using System;

public class Homeworld : IHistoryCharacter
{
    private string _pathHomeworld;
    private int _fatepoint;
    private int _porogFatepoint;
    private GameStat.CharacteristicName[] _advantageCharacteristics = new GameStat.CharacteristicName[2];
    private GameStat.CharacteristicName _disadvantageCharacteristic;
    private GameStat.Inclinations _inclination;
    private int _startWound;
    private List<string> _talentsName = new List<string>();
    private List<Skill> _skills = new List<Skill>();
    private string  _nameWorld, _bonusesText, _descriptionText, _citataText, _bonusFromHomeworld;
    private List<string> _skeensOptions = new List<string>();
    private List<string> _eyesOptions = new List<string>();
    private List<string> _hairOptions = new List<string>();
    private List<string> _ageOptions = new List<string>();
    private List<string> _agesIntOptions = new List<string>();
    private List<string> _rememberThingOptions = new List<string>();
    private List<string> _bodyOptions = new List<string>();
    private List<string> _traditionsOptions = new List<string>();
    private List<string> _physOptions = new List<string>();

    public Homeworld(string path, CreatorSkills creatorSkills)
    {
        //pathHomeworld = $"{Application.dataPath}/Images/Worlds/{name}/";
        _pathHomeworld = path;
        string[] data = File.ReadAllLines(path + "/Parameters.JSON");
        HomeworldLoader worldReader = JsonUtility.FromJson<HomeworldLoader>(data[0]);
        _nameWorld = GameStat.ReadText(_pathHomeworld + "/Название.txt");
        _bonusFromHomeworld = GameStat.ReadText(_pathHomeworld + "/Бонус.txt");
        _descriptionText = GameStat.ReadText(path + "/Описание.txt");
        _citataText = GameStat.ReadText(path + "/Цитата.txt");
        _advantageCharacteristics[0] = (GameStat.CharacteristicName)Enum.Parse(typeof(GameStat.CharacteristicName), worldReader.advantageCharacteristicsFirst);
        _advantageCharacteristics[1] = (GameStat.CharacteristicName)Enum.Parse(typeof(GameStat.CharacteristicName), worldReader.advantageCharacteristicsSecond);
        _disadvantageCharacteristic = (GameStat.CharacteristicName)Enum.Parse(typeof(GameStat.CharacteristicName), worldReader.disadvantageCharacteristic);
        _fatepoint = worldReader.fatepoint;
        _porogFatepoint = worldReader.porogFatepoint;        
        _inclination = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), worldReader.inclination);
        _startWound = worldReader.wound;
        if (File.Exists(_pathHomeworld + "/Skills.txt"))
        {
            List<string> skillsText = GameStat.ReadText(_pathHomeworld + "/Skills.txt").Split(new char[] { '/' }).ToList();
            foreach(string skillName in skillsText)
            {
                _skills.Add(creatorSkills.GetSkill(skillName));
            }
        }

        if (File.Exists(_pathHomeworld + "/Talents.txt"))
        {
            _talentsName = GameStat.ReadText(_pathHomeworld + "/Talents.txt").Split(new char[] { '/' }).ToList();
        }

        _skeensOptions = GameStat.ReadText(path + "/Кожа.txt").Split(new char[] { '/' }).ToList();
        _eyesOptions = GameStat.ReadText(path + "/Глаза.txt").Split(new char[] { '/' }).ToList();
        _hairOptions = GameStat.ReadText(path + "/Волосы.txt").Split(new char[] { '/' }).ToList();
        _ageOptions = GameStat.ReadText(path + "/Возраст.txt").Split(new char[] { '/' }).ToList();
        _bodyOptions = GameStat.ReadText(path + "/Телосложение.txt").Split(new char[] { '/' }).ToList();
        _rememberThingOptions = GameStat.ReadText(path + "/Памятные вещи.txt").Split(new char[] { '/' }).ToList();
        _traditionsOptions = GameStat.ReadText(path + "/Традиции.txt").Split(new char[] { '/' }).ToList();
        _physOptions = GameStat.ReadText(path + "/Физические особенности.txt").Split(new char[] { '/' }).ToList();
        _agesIntOptions = GameStat.ReadText(path + "/Age.txt").Split(new char[] { '/' }).ToList();

        _bonusesText += $"\n \n +{GameStat.characterTranslate[AdvantageCharacteristics[0]]},\n +{GameStat.characterTranslate[AdvantageCharacteristics[1]]},\n " +
            $"-{GameStat.characterTranslate[DisadvantageCharacteristic]}";
    }

    public int Fatepoint => _fatepoint;
    public GameStat.CharacteristicName[] AdvantageCharacteristics => _advantageCharacteristics; 
    public GameStat.CharacteristicName DisadvantageCharacteristic => _disadvantageCharacteristic; 
    public GameStat.Inclinations Inclination => _inclination; 
    public int PorogFatepoint => _porogFatepoint;
    public string Name => _nameWorld;
    public string BonusText => _bonusesText;
    public string BonusFromHomeworld => _bonusFromHomeworld;
    public string Description => _descriptionText;

    public string Citata => _citataText;

    public int StartWound => _startWound;

    public List<string> SkeensOptions => _skeensOptions; 
    public List<string> EyesOptions => _eyesOptions; 
    public List<string> HairOptions => _hairOptions; 
    public List<string> AgeOptions => _ageOptions;
    public List<string> AgesIntOptions => _agesIntOptions;
    public List<string> RememberThingOptions => _rememberThingOptions;
    public List<string> BodyOptions => _bodyOptions;
    public List<string> TraditionsOptions => _traditionsOptions;
    public List<string> PhysOptions => _physOptions;
    public string Path => _pathHomeworld;

    public List<Skill> Skills => _skills;

    public List<string> GetTalents()
    {
        if(_talentsName.Count > 0)
        {
            return _talentsName;
        }
        else
        {
            return null;
        }
    }

}
