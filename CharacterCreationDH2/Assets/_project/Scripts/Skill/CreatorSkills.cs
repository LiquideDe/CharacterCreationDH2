using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace CharacterCreation
{
    public class CreatorSkills
    {
        public event Action SkillsIsCreated;
        private List<Skill> _skills = new List<Skill>();
        public List<Skill> Skills { get => _skills; }

        public void StartCreating() => CreateSkills().Forget();

        public Skill GetSkill(string skillName)
        {
            foreach (Skill skill in _skills)
            {
                if (string.Compare(skill.Name, skillName, true) == 0)
                    return skill;

            }
            Debug.Log($"!!!!!! Не нашли умение!!!! Искали {skillName}");
            return null;
        }

        private async UniTask CreateSkills()
        {
            List<string> dirs = new List<string>();
            dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Skills"));
            for (int i = 0; i < dirs.Count; i++)
            {
                List<string> knowledges = new List<string>();
                knowledges.AddRange(Directory.GetFiles(dirs[i], "*.JSON"));

                for (int j = 0; j < knowledges.Count; j++)
                {
                    string[] data = File.ReadAllLines(knowledges[j]);
                    JSONSkillLoader skillLoader = JsonUtility.FromJson<JSONSkillLoader>(data[0]);
                    string typeName = new DirectoryInfo(System.IO.Path.GetDirectoryName(knowledges[j])).Name;
                    _skills.Add(new Knowledge(skillLoader, typeName));
                    await UniTask.Yield();
                }
            }
            List<string> skills = new List<string>();
            skills.AddRange(Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Skills", "*.JSON"));
            for (int i = 0; i < skills.Count; i++)
            {
                string[] data = File.ReadAllLines(skills[i]);
                JSONSkillLoader skillLoader = JsonUtility.FromJson<JSONSkillLoader>(data[0]);
                _skills.Add(new Skill(skillLoader, "Skill"));
                await UniTask.Yield();
            }

            SkillsIsCreated?.Invoke();
        }
    }
}

