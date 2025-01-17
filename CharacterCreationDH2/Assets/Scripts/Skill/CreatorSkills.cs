using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorSkills
{
    public event Action SkillsIsCreated;
    private AudioManager _audioManager;
    private List<Skill> _skills = new List<Skill>();

    public List<Skill> Skills { get => _skills; }
    public CreatorSkills(AudioManager audioManager) => _audioManager = audioManager;

    public void StartCreating() => _audioManager.StartCoroutine(CreateSkillsCoroutine());

    public Skill GetSkill(string skillName)
    {
        foreach(Skill skill in _skills)
        {
            if (string.Compare(skill.Name, skillName, true) == 0)            
                return skill;
            
        }
        Debug.Log($"!!!!!! Не нашли умение!!!! Искали {skillName}");
        return null;
    }

    public bool IsSkillKnowledge(string skillName)
    {
        foreach (Skill skill in _skills)
        {
            if (string.Compare(skill.Name, skillName, true) == 0)
            {
                if (skill.IsKnowledge)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private IEnumerator CreateSkillsCoroutine()
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
                yield return null;
            }
        }
        List<string> skills = new List<string>();
        skills.AddRange(Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Skills", "*.JSON"));
        for (int i = 0; i < skills.Count; i++)
        {
            string[] data = File.ReadAllLines(skills[i]);
            JSONSkillLoader skillLoader = JsonUtility.FromJson<JSONSkillLoader>(data[0]);
            _skills.Add(new Skill(skillLoader, "Skill"));
            yield return null;
        }

        SkillsIsCreated?.Invoke();
    }
}
