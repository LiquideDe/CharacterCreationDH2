using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent
{
    private string name;
    private string textDescription;
    private GameStat.Inclinations[] inclinations = new GameStat.Inclinations[2];
    private List<Characteristic> requirementCharacteristics = new List<Characteristic>();
    private List<Skill> requirementSkills = new List<Skill>();
    private List<MechImplants> requirementImplants = new List<MechImplants>();
    private List<Talent> requirementTalents = new List<Talent>();
    private bool isCanTaken;
    private int rank;
    private int cost;

    public string Name { get { return  name; } }
    public string Description { get { return textDescription; } }
    public GameStat.Inclinations[] Inclinations { get { return inclinations; } }
    public bool IsCanTaken { get => isCanTaken; }
    public int Cost { get => cost; }

    public Talent(string name, string textDescription, int rank ,GameStat.Inclinations firstInclination, GameStat.Inclinations secondInclination, List<Characteristic> requirementCharacteristics,
        List<Skill> requirementSkills, List<MechImplants> requirementImplants, List<Talent> requirementTalents, bool isCanTaken = true)
    {
        this.name = name;
        this.textDescription = textDescription;
        this.rank = rank;
        inclinations[0] = firstInclination;
        inclinations[1] = secondInclination;
        if(requirementCharacteristics != null)
            this.requirementCharacteristics = new List<Characteristic>(requirementCharacteristics);
        if (requirementSkills != null)
            this.requirementSkills = new List<Skill>(requirementSkills);
        if (requirementImplants != null)
            this.requirementImplants = new List<MechImplants>(requirementImplants);
        if (requirementTalents != null)
            this.requirementTalents = new List<Talent>(requirementTalents);

        this.isCanTaken = isCanTaken;
    }

    public Talent(string name)
    {
        this.name = name;
    }

    public bool IsTalentAvailable(List<Characteristic> characteristicsOfCharacter,
        List<Skill> skillsOfCharacter, List<MechImplants> implantsOfCharacter, List<Talent> talentsOfCharacter)
    {
        if(CheckCharacteristic(characteristicsOfCharacter) && CheckSkills(skillsOfCharacter) && CheckImplants(implantsOfCharacter) && CheckTalents(talentsOfCharacter) && isCanTaken
            && CheckTalentRepeat(talentsOfCharacter))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckTalentRepeat(List<Talent> talentsOfCharacter)
    {
        foreach(Talent talent in talentsOfCharacter)
        {
            if (talent.Name == name)
            {
                return false;
            }
        }
        return true;
    }
    private bool CheckCharacteristic(List<Characteristic> characteristicsOfCharacter)
    {
        int amountReq = requirementCharacteristics.Count;
        if(amountReq == 0)
        {
            return true;
        }
        for (int i = 0; i < amountReq; i++)
        {
            for(int j = 0; j < characteristicsOfCharacter.Count; j++)
            {
                if(requirementCharacteristics[i].InternalName == characteristicsOfCharacter[j].InternalName)
                {
                    if (requirementCharacteristics[i].Amount > characteristicsOfCharacter[j].Amount)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                        
                }
            }

        }
        return true;
    }

    private bool CheckSkills(List<Skill> skillsOfCharacter)
    {
        int amountReq = requirementSkills.Count;
        if (amountReq == 0)
        {
            return true;
        }
        for (int i = 0; i < amountReq; i++)
        {
            for(int j = 0; j < skillsOfCharacter.Count; j++)
            {
                if(requirementSkills[i].InternalName == skillsOfCharacter[j].InternalName)
                {
                    if(requirementSkills[i].LvlLearned > skillsOfCharacter[j].LvlLearned)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        return true;
    }

    private bool CheckImplants(List<MechImplants> implantsOfCharacter)
    {
        
        int amountReq = requirementImplants.Count;
        if (amountReq == 0)
        {
            return true;
        }
        
        int sum = 0;
        for (int i = 0; i < amountReq; i++)
        {
            for (int j = 0; j < implantsOfCharacter.Count; j++)
            {
                if(requirementImplants[i].Name == implantsOfCharacter[j].Name)
                {
                    sum += 1;
                }
            }
        }

        if(sum == amountReq)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckTalents(List<Talent> talentsOfCharacter)
    {
        int amountReq = requirementTalents.Count;
        if (amountReq == 0)
        {
            return true;
        }
        int sum = 0;
        for (int i = 0; i < amountReq; i++)
        {
            for (int j = 0; j < talentsOfCharacter.Count; j++)
            {
                if (requirementTalents[i].Name == talentsOfCharacter[j].Name)
                {
                    sum += 1;
                }
            }
        }

        if (sum == amountReq)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void CalculateCost(List<GameStat.Inclinations> inclinations)
    {
        int sum = 0;
        foreach (GameStat.Inclinations incl in inclinations)
        {
            if(incl == this.inclinations[0] || incl == this.inclinations[1])
            {
                sum++;
            }
        }
        cost = 300 * (1 + rank) - 150 * (rank + sum);
    }
}
