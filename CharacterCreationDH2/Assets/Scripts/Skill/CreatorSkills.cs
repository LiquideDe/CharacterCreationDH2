using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class CreatorSkills
{
    private List<Skill> skills = new List<Skill>();

    public List<Skill> Skills { get => skills; }
    public CreatorSkills()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Skills"));
        for (int i = 0; i < dirs.Count; i++)
        {
            string[] data = File.ReadAllLines(dirs[i] + "/Parameters.JSON");
            JSONSkillLoader skillLoader = JsonUtility.FromJson<JSONSkillLoader>(data[0]);
            if (skillLoader.type != "Knowledge")
            {
                skills.Add(new Skill(skillLoader, dirs[i]));
            }
            else
            {
                skills.Add(new Knowledge(skillLoader, dirs[i]));
            }
        }

    }   

    public Skill GetSkill(string skillName)
    {
        foreach(Skill skill in skills)
        {
            if (string.Compare(skill.Name, skillName, true) == 0)
            {
                return skill;
            }
        }
        Debug.Log($"!!!!!! Не нашли умение!!!! Искали {skillName}");
        return null;
    }

    public bool IsSkillKnowledge(string skillName)
    {
        foreach (Skill skill in skills)
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
}
