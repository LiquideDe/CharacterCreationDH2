using UnityEngine;
using TMPro;
using System.Collections.Generic;
using static UnityEditor.Progress;

namespace CharacterCreation
{
    public class FirstCharacterSheet : CharacterSheetWithCharacteristics
    {
        [SerializeField] private SkillList[] skillSquares;
        [SerializeField]
        private TextMeshProUGUI textName, _textDescription, _textMutationText, _textCorruptionPoints, _textMentalText, _textInsanityPoints, _textFatePoint,
            _textSpentExperience, _textUnspentExperience, _textTotalExperience;
        private Dictionary<string, SkillList> _skillListDict = new Dictionary<string, SkillList>();

        private void Awake()
        {
            foreach (var item in skillSquares)
            {
                if (CheckSkillListNotKnowlidge(item))
                    _skillListDict.Add(item.SkillName, item);
            }
        }

        public override void Initialize(ICharacter character)
        {
            base.Initialize(character);
            gameObject.SetActive(true);
            _character = character;
            textName.text = character.Name;

            string trad = character.Tradition.Trim();
            _textDescription.text = $"<b>Родной Мир:</b> <u>{character.Homeworld}</u>. <b>Предыстория:</b> <u>{character.Background}</u>. <b>Роль:</b> <u>{character.Role}</u>. " +
                $"<b>Пророчество:</b> <u>{character.Prophecy}</u>. <b>Пол:</b> <u>{character.Gender}</u>. <b>Лет:</b> <u>{character.Age}</u>. <b>Кожа:</b> <u>{character.Skeen}</u>. " +
                $"<b>Комплекция:</b> <u>{character.Constitution}</u>. <b>Волосы:</b> <u>{character.Hair}</u>. <b>Особенности:</b> <u>{character.PhysFeatures}</u>. " +
                $"<b>Глаза:</b> <u>{character.Eyes}</u>. <b>Предрассудки:</b> <u>{trad.Substring(0, trad.IndexOf(':'))}</u>. <b>Памятная вещь с родного мира:</b> <u>{character.MemoryOfHome}</u>. " +
                $"<b>Памятная вещь из предыстории:</b> <u>{character.MemoryOfBackground}</u>.";

            _textFatePoint.text = character.FatePoint.ToString();
            _textSpentExperience.text = character.ExperienceSpent.ToString();
            _textUnspentExperience.text = character.ExperienceUnspent.ToString();
            _textTotalExperience.text = character.ExperienceTotal.ToString();

            foreach (Skill skill in character.Skills)
            {
                if (skill.LvlLearned > 0)
                {
                    ActivateSquare(skill);
                }
            }

            foreach (string mut in character.Mutations)
            {
                _textMutationText.text += mut + '\n';
            }

            foreach (string ins in character.MentalDisorders)
            {
                _textMentalText.text += ins + '\n';
            }
            if (character.CorruptionPoints > 0)
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
            if (!skill.IsKnowledge)
            {
                _skillListDict[skill.Name].SetLvlLearned(skill.LvlLearned);
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

        private bool CheckSkillListNotKnowlidge(SkillList skillList)
        {
            if (string.Compare(skillList.SkillName, "0", true) == 0)            
                return false;

            if (string.Compare(skillList.SkillName, "CommonLore", true) == 0)
                return false;

            if (string.Compare(skillList.SkillName, "Trade", true) == 0)
                return false;

            if (string.Compare(skillList.SkillName, "ForbiddenLore", true) == 0)
                return false;

            if (string.Compare(skillList.SkillName, "Linguistics", true) == 0)
                return false;

            if (string.Compare(skillList.SkillName, "ScholasticLore", true) == 0)
                return false;

            return true;

        }
    }
}

