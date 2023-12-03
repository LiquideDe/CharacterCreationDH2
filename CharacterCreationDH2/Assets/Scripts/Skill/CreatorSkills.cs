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
    private List<Knowledge> knowledges = new List<Knowledge>();

    public List<Skill> Skills { get => skills; }
    public List<Knowledge> Knowledges { get => knowledges; }
    public CreatorSkills()
    {
        List<string> inclinations = new List<string>();

        GameStat.SkillName skillName;
        GameStat.KnowledgeName knowledgeName;
        GameStat.Inclinations first;
        GameStat.Inclinations second;
        string typeSkill;
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Images/Skills"));
        for (int i = 0; i < dirs.Count; i++)
        {
            inclinations = ReadText(dirs[i] + "/Inclinations.txt").Split(new char[] { '/' }).ToList();
            skillName = (GameStat.SkillName)Enum.Parse(typeof(GameStat.SkillName), ReadText(dirs[i] + "/InternalName.txt"));
            typeSkill = ReadText(dirs[i] + "/Type.txt");
            first = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), inclinations[0]);
            second = (GameStat.Inclinations)Enum.Parse(typeof(GameStat.Inclinations), inclinations[1]);
            if (typeSkill == "Skill")
            {
                skills.Add(new Skill(skillName, first, second, ReadText(dirs[i] + "/Описание.txt")));
            }
            else
            {
                knowledgeName = (GameStat.KnowledgeName)Enum.Parse(typeof(GameStat.KnowledgeName), ReadText(dirs[i] + "/KnowledgeName.txt"));
                knowledges.Add(new Knowledge(knowledgeName, skillName, first, second, ReadText(dirs[i] + "/Описание.txt")));
            }
        }

    }

    protected string ReadText(string nameFile)
    {
        string txt;
        using (StreamReader _sw = new StreamReader(nameFile, Encoding.Default))
        {
            txt = (_sw.ReadToEnd());
            _sw.Close();
        }
        return txt;
    }

    public Skill GetSkill(GameStat.SkillName skillName)
    {
        foreach(Skill skill in skills)
        {
            if(skill.InternalName == skillName)
            {
                return skill;
            }
        }
        return null;
    }

    public Knowledge GetKnowledge(GameStat.KnowledgeName knowledgeName)
    {
        foreach(Knowledge knowledge in knowledges)
        {
            if (knowledge.InternalNameKnowledge == knowledgeName)
            {
                return knowledge;
            }
        }
        return null;
    }

}
