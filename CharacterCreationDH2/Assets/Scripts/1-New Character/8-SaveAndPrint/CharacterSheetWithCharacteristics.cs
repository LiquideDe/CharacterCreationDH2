using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterSheetWithCharacteristics : TakeScreenshot
{
    [SerializeField]
    private TextMeshProUGUI textWeapon, textBallistic, textStrength, textToughness, textAgility, textIntelligence, textPerception, textWillpower,
        textFelloweship, textInfluence, textWeaponBonus, textBallisticBonus, textStrengthBonus, textToughnessBonus,
        textAgilityBonus, textIntelligenceBonus, textPerceptionBonus, textWillpowerBonus, textFelloweshipBonus;

    [SerializeField] private GameObject[] circlesWeapon;
    [SerializeField] private GameObject[] circlesBallistic;
    [SerializeField] private GameObject[] circlesStrength;
    [SerializeField] private GameObject[] circlesToughness;
    [SerializeField] private GameObject[] circlesAgility;
    [SerializeField] private GameObject[] circlesIntelligence;
    [SerializeField] private GameObject[] circlesPerception;
    [SerializeField] private GameObject[] circlesWillpower;
    [SerializeField] private GameObject[] circlesFellowship;
    private List<GameObject[]> circlesGroups;

    public string BonusStrength => textStrengthBonus.text;
    public string BonusToughness => textToughnessBonus.text;
    public string BonusAgility => textAgilityBonus.text;
    public string Strength => textStrength.text;
    public string BonusWillpower => textWillpowerBonus.text;

    public virtual void Initialize(ICharacter character)
    {
        _character = character;
        circlesGroups = new List<GameObject[]>
        {
            circlesWeapon,
            circlesBallistic,
            circlesStrength,
            circlesToughness,
            circlesAgility,
            circlesIntelligence,
            circlesPerception,
            circlesWillpower,
            circlesFellowship
        };

        int bonusStrenthFromArmor = 0;
        foreach (Equipment equipment in _character.Equipments)
            if (equipment is Armor armor)
                bonusStrenthFromArmor += armor.BonusStrength;

        textWeapon.text = character.Characteristics[0].Amount.ToString();
        textBallistic.text = character.Characteristics[1].Amount.ToString();
        textStrength.text = $"{character.Characteristics[2].Amount + bonusStrenthFromArmor}";
        textToughness.text = character.Characteristics[3].Amount.ToString();
        textAgility.text = character.Characteristics[4].Amount.ToString();
        textIntelligence.text = character.Characteristics[5].Amount.ToString();
        textPerception.text = character.Characteristics[6].Amount.ToString();
        textWillpower.text = character.Characteristics[7].Amount.ToString();
        textFelloweship.text = character.Characteristics[8].Amount.ToString();
        textInfluence.text = character.Characteristics[9].Amount.ToString();

        for (int i = 0; i < circlesGroups.Count; i++)
        {
            for (int j = 0; j < character.Characteristics[i].LvlLearned; j++)
            {
                circlesGroups[i][j].SetActive(true);
            }
        }

        //int superWeapon = 0;
        //int superBallistic = 0;
        int superStrength = 0;
        int superToughness = 0;
        int superAgility = 0;
        int superIntelligence = 0;
        int superPerception = 0;
        int superWillpower = 0;
        int superFelloweship = 0;

        foreach(Trait trait in _character.Traits)
        {
            if (string.Compare(trait.Name, "Сверхъестественная Сила") == 0)            
                superStrength = trait.Lvl;
            
            else if (string.Compare(trait.Name, "Сверхъестественная Выносливость") == 0)
                superToughness += trait.Lvl;

            else if(string.Compare(trait.Name, "Сверхъестественная Ловкость") == 0)
                superAgility += trait.Lvl;

            else if(string.Compare(trait.Name, "Сверхъестественный Интеллект") == 0)
                superIntelligence += trait.Lvl;

            else if(string.Compare(trait.Name, "Сверхъестественное Восприятие") == 0)
                superPerception += trait.Lvl;

            else if(string.Compare(trait.Name, "Сверхъестественная Сила Воли") == 0)
                superWillpower += trait.Lvl;

            else if(string.Compare(trait.Name, "Сверхъестественная Общительность") ==0)
                superFelloweship += trait.Lvl;

            else if(string.Compare(trait.Name, "Демонический") == 0)
                superToughness += trait.Lvl;
        }

        if (superStrength > 0)
            textStrengthBonus.text = $"{superStrength + (int)(_character.Characteristics[GameStat.CharacteristicToInt["Сила"]].Amount + bonusStrenthFromArmor )/ 10}";
        else textStrengthBonus.text = "";

        if (superToughness > 0)
            textToughnessBonus.text = $"{superToughness + (int)_character.Characteristics[GameStat.CharacteristicToInt["Выносливость"]].Amount / 10}";
        else textToughnessBonus.text = "";

        if (superAgility > 0)
            textAgilityBonus.text = $"{superAgility + (int)_character.Characteristics[GameStat.CharacteristicToInt["Ловкость"]].Amount / 10}";
        else textAgilityBonus.text = "";

        if (superIntelligence > 0)
            textIntelligenceBonus.text = $"{superIntelligence + (int)_character.Characteristics[GameStat.CharacteristicToInt["Интеллект"]].Amount / 10}";
        else textIntelligenceBonus.text = "";

        if (superPerception > 0)
            textPerceptionBonus.text = $"{superPerception + (int)_character.Characteristics[GameStat.CharacteristicToInt["Восприятие"]].Amount / 10}";
        else textPerceptionBonus.text = "";

        if (superWillpower > 0)
            textWillpowerBonus.text = $"{superWillpower + (int)_character.Characteristics[GameStat.CharacteristicToInt["Сила Воли"]].Amount / 10}";
        else textWillpowerBonus.text = "";

        if (superFelloweship > 0)
            textFelloweshipBonus.text = $"{superFelloweship + (int)_character.Characteristics[GameStat.CharacteristicToInt["Общительность"]].Amount / 10}";
        else textFelloweshipBonus.text = "";

    }
}
