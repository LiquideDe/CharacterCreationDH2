using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorWorlds
{
    private List<Homeworld> homeworlds = new List<Homeworld>();
    private int id;

    public CreatorWorlds()
    {
        homeworlds.Add(new Homeworld(GameStat.WorldName.FeralWorld.ToString(), GameStat.CharacterName.Strength, GameStat.CharacterName.Toughness, GameStat.CharacterName.Influence, 2,
            GameStat.Inclinations.Toughness,9));

        homeworlds.Add(new Homeworld(GameStat.WorldName.ForgeWorld.ToString(), GameStat.CharacterName.Intelligence, GameStat.CharacterName.Toughness, GameStat.CharacterName.Fellowship, 3,
            GameStat.Inclinations.Intelligence, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.HighBorn.ToString(), GameStat.CharacterName.Fellowship, GameStat.CharacterName.Influence, GameStat.CharacterName.Toughness, 4,
             GameStat.Inclinations.Fellowship, 9));

        homeworlds.Add(new Homeworld(GameStat.WorldName.HiveWorld.ToString(), GameStat.CharacterName.Agility, GameStat.CharacterName.Perception, GameStat.CharacterName.Willpower, 2,
            GameStat.Inclinations.Perception, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.TempleWorld.ToString(), GameStat.CharacterName.Fellowship, GameStat.CharacterName.Willpower, GameStat.CharacterName.Perception, 3,
             GameStat.Inclinations.Willpower, 7));

        homeworlds.Add(new Homeworld(GameStat.WorldName.VoidBorn.ToString(), GameStat.CharacterName.Intelligence, GameStat.CharacterName.Willpower, GameStat.CharacterName.Strength, 3,
             GameStat.Inclinations.Intelligence, 7));
        homeworlds[^1].AddTalent("Непреклонный");

        homeworlds.Add(new Homeworld(GameStat.WorldName.AgroWorld.ToString(), GameStat.CharacterName.Strength, GameStat.CharacterName.Agility, GameStat.CharacterName.Fellowship, 2,
             GameStat.Inclinations.Strength, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.FeodalWorld.ToString(), GameStat.CharacterName.Perception, GameStat.CharacterName.WeaponSkill, GameStat.CharacterName.Intelligence, 3,
             GameStat.Inclinations.Weapon, 9));

        homeworlds.Add(new Homeworld(GameStat.WorldName.FrontWorld.ToString(), GameStat.CharacterName.Perception, GameStat.CharacterName.BallisticSkill, GameStat.CharacterName.Fellowship, 3,
             GameStat.Inclinations.Ballistic, 7));

        homeworlds.Add(new Homeworld(GameStat.WorldName.DaemonWorld.ToString(), GameStat.CharacterName.Perception, GameStat.CharacterName.Willpower, GameStat.CharacterName.Fellowship, 3,
             GameStat.Inclinations.Willpower, 7));
        homeworlds[^1].AddSkill(GameStat.SkillName.Psyniscience.ToString());

        homeworlds.Add(new Homeworld(GameStat.WorldName.PrisonWorld.ToString(), GameStat.CharacterName.Toughness, GameStat.CharacterName.Perception, GameStat.CharacterName.Influence, 3,
             GameStat.Inclinations.Toughness, 10));
        homeworlds[^1].AddSkill(GameStat.SkillName.Awareness.ToString());
        homeworlds[^1].AddSkill(GameStat.KnowledgeName.Criminal.ToString());
        homeworlds[^1].AddTalent("Связи (Криминальные Картели)");

        homeworlds.Add(new Homeworld(GameStat.WorldName.QuarantineWorld.ToString(), GameStat.CharacterName.BallisticSkill, GameStat.CharacterName.Intelligence, GameStat.CharacterName.Strength, 3,
             GameStat.Inclinations.Fieldcraft, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.GardenWorld.ToString(), GameStat.CharacterName.Fellowship, GameStat.CharacterName.Agility, GameStat.CharacterName.Toughness, 2,
             GameStat.Inclinations.Fellowship, 7));

        homeworlds.Add(new Homeworld(GameStat.WorldName.ScienseStation.ToString(), GameStat.CharacterName.Intelligence, GameStat.CharacterName.Perception, GameStat.CharacterName.Fellowship, 3,
             GameStat.Inclinations.Knowledge, 8));
    }

    public Homeworld GetHomeworld(string worldName)
    {
        foreach(Homeworld homeworld in homeworlds)
        {
            if (homeworld.Name == worldName)
            {
                return homeworld;
            }
        }
        return null;
    }

    public Homeworld GetNextWorld()
    {
        if(id + 1 < homeworlds.Count)
        {
            id += 1;
        }
        else
        {
            id = 0;
        }

        Debug.Log($"id = {id}");
        return homeworlds[id];
    }

    public Homeworld GetPrevWorld()
    {
        if(id - 1 < 0)
        {
            id = homeworlds.Count - 1;
        }
        else
        {
            id -= 1;
        }
        return homeworlds[id];
    }
}
