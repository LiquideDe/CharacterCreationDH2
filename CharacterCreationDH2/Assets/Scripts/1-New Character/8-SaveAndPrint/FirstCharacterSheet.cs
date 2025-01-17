using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FirstCharacterSheet : CharacterSheetWithCharacteristics
{
    [SerializeField] private SkillList[] skillSquares;
    [SerializeField]
    private TextMeshProUGUI textName, _textDescription, _textMutationText, _textCorruptionPoints, _textMentalText, _textInsanityPoints, _textFatePoint,
        _textSpentExperience, _textUnspentExperience, _textTotalExperience;  

    public override void Initialize(ICharacter character)
    {
        base.Initialize(character);
        gameObject.SetActive(true);
        _character = character;
        textName.text = character.Name;

        string trad = character.Tradition.Trim();
        _textDescription.text = $"<b>������ ���:</b> <u>{character.Homeworld}</u>. <b>�����������:</b> <u>{character.Background}</u>. <b>����:</b> <u>{character.Role}</u>. " +
            $"<b>�����������:</b> <u>{character.Prophecy}</u>. <b>���:</b> <u>{character.Gender}</u>. <b>���:</b> <u>{character.Age}</u>. <b>����:</b> <u>{character.Skeen}</u>. " +
            $"<b>����������:</b> <u>{character.Constitution}</u>. <b>������:</b> <u>{character.Hair}</u>. <b>�����������:</b> <u>{character.PhysFeatures}</u>. " +
            $"<b>�����:</b> <u>{character.Eyes}</u>. <b>������������:</b> <u>{trad.Substring(0, trad.IndexOf(':'))}</u>. <b>�������� ���� � ������� ����:</b> <u>{character.MemoryOfHome}</u>. " +
            $"<b>�������� ���� �� �����������:</b> <u>{character.MemoryOfBackground}</u>.";

        _textFatePoint.text = character.FatePoint.ToString();
        _textSpentExperience.text = character.ExperienceSpent.ToString();
        _textUnspentExperience.text = character.ExperienceUnspent.ToString();
        _textTotalExperience.text = character.ExperienceTotal.ToString();

        foreach (Skill skill in character.Skills)
        {
            if(skill.LvlLearned > 0)
            {
                ActivateSquare(skill);
            }
        }

        foreach(string mut in character.Mutation)
        {
            _textMutationText.text += mut + '\n';
        }

        foreach(string ins in character.MentalDisorders)
        {
            _textMentalText.text += ins + '\n';
        }
        if(character.CorruptionPoints > 0)
        {
            _textCorruptionPoints.text = character.CorruptionPoints.ToString();
        }
        else
        {
            _textCorruptionPoints.text = "";
        }

        if (character.InsanityPoints > 0)
        {
            _textInsanityPoints.text = character.InsanityPoints.ToString();
        }
        else
        {
            _textInsanityPoints.text = "";
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
