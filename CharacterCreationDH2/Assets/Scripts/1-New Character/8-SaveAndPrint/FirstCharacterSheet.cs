using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FirstCharacterSheet : TakeScreenshot
{
    [SerializeField] private SkillList[] skillSquares;
    [SerializeField]
    private TextMeshProUGUI textName, textHomeworld, textBackstory, textRole, textProphecy, textGender, textAge, textSkeen, textPhys, textEyes,
        textTraditions, textMemories, textWeapon, textBallistic, textStrength, textToughness, textAgility, textIntelligence, textPerception, textWillpower,
        textFelloweship, textInfluence, textFate, textTalents, textBody, textHair, textCorruptionPoints, textMutationText, textInsanityPoints, textMentalText, textElite;
    [SerializeField] private GameObject[] circlesWeapon;
    [SerializeField] private GameObject[] circlesBallistic;
    [SerializeField] private GameObject[] circlesStrength;
    [SerializeField] private GameObject[] circlesToughness;
    [SerializeField] private GameObject[] circlesAgility;
    [SerializeField] private GameObject[] circlesIntelligence;
    [SerializeField] private GameObject[] circlesPerception;
    [SerializeField] private GameObject[] circlesWillpower;
    [SerializeField] private GameObject[] circlesFellowship;    
    private List<GameObject[]> circlesGroups = new List<GameObject[]>();
    
    private void Awake()
    {
        circlesGroups.Add(circlesWeapon);
        circlesGroups.Add(circlesBallistic);
        circlesGroups.Add(circlesStrength);
        circlesGroups.Add(circlesToughness);
        circlesGroups.Add(circlesAgility);
        circlesGroups.Add(circlesIntelligence);
        circlesGroups.Add(circlesPerception);
        circlesGroups.Add(circlesWillpower);
        circlesGroups.Add(circlesFellowship);
    }
    public void Initialize(ICharacter character)
    {
        gameObject.SetActive(true);
        _character = character;
        textName.text = character.Name;
        textHomeworld.text = character.Homeworld;
        textBackstory.text = character.Background;
        textRole.text = character.Role;
        textProphecy.text = character.Prophecy;
        textGender.text = character.Gender;
        textAge.text = character.Age.ToString();
        textSkeen.text = character.Skeen;
        textPhys.text = character.PhysFeatures;
        textEyes.text = character.Eyes;

        string trad = character.Tradition.Trim();
        textTraditions.text = trad.Substring(0, trad.IndexOf(':'));

        textMemories.text = $"{character.MemoryOfHome}, {character.MemoryOfBackground}";
        textWeapon.text = character.Characteristics[0].Amount.ToString();
        textBallistic.text = character.Characteristics[1].Amount.ToString();
        textStrength.text = character.Characteristics[2].Amount.ToString();
        textToughness.text = character.Characteristics[3].Amount.ToString();
        textAgility.text = character.Characteristics[4].Amount.ToString();
        textIntelligence.text = character.Characteristics[5].Amount.ToString();
        textPerception.text = character.Characteristics[6].Amount.ToString();
        textWillpower.text = character.Characteristics[7].Amount.ToString();
        textFelloweship.text = character.Characteristics[8].Amount.ToString();
        textInfluence.text = character.Characteristics[9].Amount.ToString();
        textElite.text = character.Elite;

        textFate.text = character.FatePoint.ToString();
        textBody.text = character.Constitution;
        textHair.text = character.Hair;
        for (int i = 0; i < circlesGroups.Count; i++)
        {
            for(int j = 0; j < character.Characteristics[i].LvlLearned; j++)
            {
                circlesGroups[i][j].SetActive(true);
            }
        }
        foreach (Talent talent in character.Talents)
        {
            if(string.Compare(talent.Name, "Псайкер", true) == 0)
            {
                if (string.Compare("Адептус Астра Телепатика", character.Background) == 0)
                {
                    textTalents.text += ", Санкционированный Псайкер";
                }
                else
                {
                    textTalents.text += ", Несанкционированный Псайкер";
                }
            }
            else
            {
                textTalents.text += $", {talent.Name}";
            }
            
        }
        
        foreach (Trait feature in character.Traits)
        {
            if(feature.Lvl > 0)
            {
                textTalents.text += $", {feature.Name}({feature.Lvl})";
            }
            else
            {
                textTalents.text += $", {feature.Name}";
            }
            
        }
        char[] myChar = { ' ', ',' };
        textTalents.text = textTalents.text.TrimStart(myChar);

        foreach (Skill skill in character.Skills)
        {
            if(skill.LvlLearned > 0)
            {
                ActivateSquare(skill);
            }
        }

        foreach(string mut in character.Mutation)
        {
            textMutationText.text += mut + '\n';
        }

        foreach(string ins in character.MentalDisorders)
        {
            textMentalText.text += ins + '\n';
        }
        if(character.CorruptionPoints > 0)
        {
            textCorruptionPoints.text = character.CorruptionPoints.ToString();
        }
        else
        {
            textCorruptionPoints.text = "";
        }

        if (character.InsanityPoints > 0)
        {
            textInsanityPoints.text = character.InsanityPoints.ToString();
        }
        else
        {
            textInsanityPoints.text = "";
        }
        StartScreenshot(PageName.First.ToString());
    }

    private void ActivateSquare(Skill skill)
    {
        if(!skill.IsKnowledge)
        {
            foreach (SkillList skillList in skillSquares)
            {
                if (string.Compare(skillList.SkillName, skill.Name, true) == 0)
                {

                    skillList.SetLvlLearned(skill.LvlLearned);
                    break;
                }
            }
        }
        else
        {
            foreach (SkillList skillList in skillSquares)
            {
                if (string.Compare(skillList.SkillName, skill.TypeSkill, true) == 0)
                {
                    if (skillList.KnowledgeTextName.Length == 0)
                    {
                        skillList.KnowledgeTextName = skill.Name;
                        skillList.SetLvlLearned(skill.LvlLearned);
                        break;
                    }
                }
            }
        }        
    }

    
}
