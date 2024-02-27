using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FirstCharacterSheet : TakeScreenshot
{
    [SerializeField] SkillList[] skillSquares;
    [SerializeField] TextMeshProUGUI textName, textHomeworld, textBackstory, textRole, textProphecy, textGender, textAge, textSkeen, textPhys, textEyes,
        textTraditions, textMemories, textWeapon, textBallistic, textStrength, textToughness, textAgility, textIntelligence, textPerception, textWillpower,
        textFelloweship, textInfluence, textFate, textTalents, textBody, textHair, textCorruptionPoints, textMutationText, textInsanityPoints, textMentalText;
    [SerializeField] GameObject[] circlesWeapon;
    [SerializeField] GameObject[] circlesBallistic;
    [SerializeField] GameObject[] circlesStrength;
    [SerializeField] GameObject[] circlesToughness;
    [SerializeField] GameObject[] circlesAgility;
    [SerializeField] GameObject[] circlesIntelligence;
    [SerializeField] GameObject[] circlesPerception;
    [SerializeField] GameObject[] circlesWillpower;
    [SerializeField] GameObject[] circlesFellowship;    
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
    public void FillCharacterSheet(Character character)
    {
        gameObject.SetActive(true);
        isFirst = true;
        this.character = character;
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
        //textTraditions.text = character.HomeWorld.Traditions;
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
            textTalents.text += $", {talent.Name}";
        }
        foreach(Feature feature in character.Features)
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
        StartScreenshot();


    }

    private void ActivateSquare(Skill skill)
    {
        if(!skill.IsKnowledge)
        {
            foreach (SkillList skillList in skillSquares)
            {
                if (skillList.SkillName == skill.InternalName)
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
                if (skillList.SkillName == skill.InternalName)
                {
                    if (skillList.KnowledgeTextName == "")
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
