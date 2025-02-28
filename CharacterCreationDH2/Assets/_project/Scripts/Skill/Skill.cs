using System;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCreation
{
    public class Skill : INameWithDescription
    {
        protected string _name;
        private int _lvlLearned;
        protected bool _isKnowledge;
        private GameStat.Inclinations[] _inclinations = new GameStat.Inclinations[2];
        private string _description, _typeSkill;
        public string Description => _description;
        public GameStat.Inclinations[] Inclinations { get { return _inclinations; } }
        public string Name => _name;
        public int LvlLearned { get => _lvlLearned; set => _lvlLearned = value; }
        public bool IsKnowledge => _isKnowledge;
        public string TypeSkill => _typeSkill;

        public Skill(JSONSkillLoader skillLoader, string typeSkill)
        {
            _name = skillLoader.name;
            _inclinations[0] = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), skillLoader.firstInclination);
            _inclinations[1] = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), skillLoader.secondInclination);
            _typeSkill = typeSkill;
            _description = skillLoader.description;
        }

        public Skill(Skill skill, int lvlLearned)
        {
            _name = skill.Name;
            _lvlLearned = lvlLearned;
            _inclinations[0] = skill.Inclinations[0];
            _inclinations[1] = skill.Inclinations[1];
            _typeSkill = skill.TypeSkill;
            _isKnowledge = skill.IsKnowledge;
            _description = skill.Description;
        }

        public Skill(string name, int lvl)
        {
            _name = name;
            _lvlLearned = lvl;
        }
        public int SetNewLvl()
        {
            _lvlLearned++;
            Mathf.Clamp(_lvlLearned, 0, 4);
            return _lvlLearned;
        }

        public int CancelNewLvl()
        {
            _lvlLearned--;
            Mathf.Clamp(_lvlLearned - 1, 0, 4);
            return _lvlLearned;
        }

        public int CalculateInclinations(List<GameStat.Inclinations> charIncl)
        {
            int sumIncls = 0;
            foreach (GameStat.Inclinations incl in charIncl)
            {
                if (incl == _inclinations[0] || incl == _inclinations[1])
                {
                    sumIncls++;
                }
            }

            return sumIncls;
            //cost = ((lvlLearned + 1) * 300) - (100 * sumIncls * (lvlLearned + 1));
        }
    }
}

