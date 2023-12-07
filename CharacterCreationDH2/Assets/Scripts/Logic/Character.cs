using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character 
{
    private string name, background, role, ageText, prophecy, constitution, hair, eyes, skeen, physFeatures, memoryOfHome, memoryOfBackground, gender, bonusBack;
    private int age, fatePoint, madnessPoints, corruptionPoints, wounds, psyRating, halfMove, fullMove, natisk, run, fatigue,
        experienceTotal, experienceUnspent = 10000, experienceSpent;
    private float carryWeight, liftWeight, pushWeight;
    private List<Characteristic> characteristics = new List<Characteristic>();
    private List<GameStat.Inclinations> inclinations = new List<GameStat.Inclinations>();
    private List<Talent> talents = new List<Talent>();
    private List<Skill> skills = new List<Skill>();
    private List<Knowledge> knowledges = new List<Knowledge>();
    private List<string> mentalDisorders = new List<string>();
    private List<string> mutation = new List<string>();
    private List<PsyPower> psyPowers = new List<PsyPower>();
    private List<Equipment> equipments = new List<Equipment>();
    private List<MechImplants> implants = new List<MechImplants>();
    private Homeworld homeworld;
    private List<float> parametrsForWeight;
    private CreatorEquipment creatorEquipment;

    #region Свойства
    public string Name { get => name; set => name = value; }
    public Homeworld HomeWorld { get { return homeworld; } }
    public string Background { get { return background; } }
    public string Role { get { return role; } }
    public string AgeText { get => ageText; }
    public string Prophecy { get => prophecy; set => prophecy = value; }
    public string Constitution { get => constitution;}
    public string Hair { get => hair; }
    public string Eyes { get => eyes; }
    public string Skeen { get => skeen; }
    public string Gender { get => gender; }
    public string PhysFeatures { get => physFeatures;}
    public string MemoryOfHome { get => memoryOfHome;}
    public string MemoryOfBackground { get => memoryOfBackground;}
    public List<Equipment> Equipments { get => equipments;}
    public int Age { get => age; set => age = value; }
    public int FatePoint { get => fatePoint; set => fatePoint = value; }
    public int MadnessPoints { get => madnessPoints; set => madnessPoints = value; }
    public int Wounds { get => wounds; set => wounds = value; }
    public int CorruptionPoints { get => corruptionPoints; set => corruptionPoints = value; }
    public int PsyRating { get => psyRating; }
    public int HalfMove { get => halfMove;}
    public int FullMove { get => fullMove;}
    public int Natisk { get => natisk;}
    public int Fatigue { get => fatigue;}
    public float CarryWeight { get => carryWeight;}
    public float LiftWeight { get => liftWeight;}
    public float PushWeight { get => pushWeight;}
    public int ExperienceTotal { get => experienceTotal; set => experienceTotal = value; }
    public int ExperienceUnspent { get => experienceUnspent; set => experienceUnspent = value; }
    public int ExperienceSpent { get => experienceSpent; set => experienceSpent = value; }
    public List<Characteristic> Characteristics { get => characteristics; set => characteristics = value; }
    public List<GameStat.Inclinations> Inclinations { get => inclinations; }
    public List<Skill> Skills { get => skills.Concat(knowledges).ToList(); }
    public List<Talent> Talents { get => talents; }
    public List<MechImplants> Implants { get => implants; }
    public List<string> MentalDisorders { get => mentalDisorders; set => mentalDisorders = value; }
    public int Run { get => run; }
    public string BonusBack { get => bonusBack; set => bonusBack = value; }
    public List<PsyPower> PsyPowers { get => psyPowers; }
    #endregion

    public Character(List<Skill> skills, List<Knowledge> knowledges, CreatorEquipment creatorEquipment)
    {
        this.skills = new List<Skill>(skills);
        this.knowledges = new List<Knowledge>(knowledges);
        inclinations.Add(GameStat.Inclinations.General);
        this.creatorEquipment = creatorEquipment;
        CreateCharacteristics();
    }

    private void CreateCharacteristics()
    {
        characteristics.Add(new Characteristic(GameStat.CharacterName.WeaponSkill, GameStat.Inclinations.Weapon, GameStat.Inclinations.Offense)); //0
        characteristics.Add(new Characteristic(GameStat.CharacterName.BallisticSkill, GameStat.Inclinations.Ballistic, GameStat.Inclinations.Finesse)); //1
        characteristics.Add(new Characteristic(GameStat.CharacterName.Strength, GameStat.Inclinations.Strength, GameStat.Inclinations.Offense)); //2
        characteristics.Add(new Characteristic(GameStat.CharacterName.Toughness, GameStat.Inclinations.Toughness, GameStat.Inclinations.Defense)); //3
        characteristics.Add(new Characteristic(GameStat.CharacterName.Agility, GameStat.Inclinations.Agility, GameStat.Inclinations.Finesse)); //4
        characteristics.Add(new Characteristic(GameStat.CharacterName.Intelligence, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge)); //5
        characteristics.Add(new Characteristic(GameStat.CharacterName.Perception, GameStat.Inclinations.Perception, GameStat.Inclinations.Fieldcraft)); //6
        characteristics.Add(new Characteristic(GameStat.CharacterName.Willpower, GameStat.Inclinations.Willpower, GameStat.Inclinations.Psyker)); //7
        characteristics.Add(new Characteristic(GameStat.CharacterName.Fellowship, GameStat.Inclinations.Fellowship, GameStat.Inclinations.Social)); //8
        characteristics.Add(new Characteristic(GameStat.CharacterName.Influence, GameStat.Inclinations.None, GameStat.Inclinations.None)); //9
        
    }

    public void SetHomeWorld(Homeworld homeworld)
    {
        this.homeworld = homeworld;
        wounds = homeworld.Wound;
        //inclinations.Add(homeworld.Inclination);
        AddInclination(homeworld.Inclination);

        var bonusSkills = homeworld.GetSkills();
        if (bonusSkills != null)
        {
            foreach(string skill in bonusSkills)
                UpgradeSkill(null, skill);
        }
        var bonusTalents = homeworld.GetTalents();
        if (bonusTalents != null)
        {
            foreach (string talent in bonusTalents)
                talents.Add(new Talent(talent));
        }
        ageText = homeworld.Age;
        constitution = homeworld.Body;
        physFeatures = homeworld.Phys;
        memoryOfHome = homeworld.Remember;
        hair = homeworld.Hair;
        eyes = homeworld.Eyes;
        skeen = homeworld.Skeen;
        fatePoint = homeworld.Fatepoint;
        Debug.Log($"fatePoint = {fatePoint}");
        wounds = homeworld.Wound;
        age = homeworld.AgeInt;

    }

    public void SetBackground(Background background)
    {
        foreach(Skill skill in background.ChosenSkills)
        {
            UpgradeSkill(skill);
        }
        foreach(string talent in background.ChosenTalents)
        {
            talents.Add(new Talent(talent));
        }
        foreach(Equipment eq in background.ChosenEquipments)
        {
            if(eq.TypeEq != Equipment.TypeEquipment.Special)
            {
                equipments.Add(eq);
            }
            else
            {
                Special special = (Special)eq;
                equipments.Add(creatorEquipment.GetEquipment(special.FirstName));
                equipments.Add(creatorEquipment.GetEquipment(special.SecondName));
            }
            
        }
        //inclinations.Add(background.ChosenInclination);
        AddInclination(background.ChosenInclination);
        if(background.MechImplants != null)
        {
            implants.Add(background.MechImplants);
        }        
        
        this.background = background.Name;
        memoryOfBackground = background.RememberThing;
        bonusBack = background.Bonus;
    }

    public void SetRole(Role role)
    {
        foreach(GameStat.Inclinations incl in role.ChosenInclinations)
        {
            AddInclination(incl);
        }

        talents.Add(new Talent(role.ChosenTalent));
        this.role = role.Name;
        if (role.InternalName == GameStat.RoleName.Mistic)
        {
            psyRating = 1;
        }
    }

    public void UpgradeSkill(Skill newSkill, string nameSkill = "")
    {
        if(newSkill == null)
        {
            newSkill = new Skill((GameStat.SkillName)Enum.Parse(typeof(GameStat.SkillName), nameSkill), 1);
        }

        int sch = 0;
        foreach(Skill skill in skills)
        {
            if(skill.InternalName == newSkill.InternalName)
            {                
                skill.SetNewLvl();
                sch += 1;
                break;
            }
        }
        if(sch == 0)
        {
            Knowledge knowledge = (Knowledge)newSkill;
            foreach (Knowledge skill in knowledges)
            {
                if (skill.InternalNameKnowledge == knowledge.InternalNameKnowledge)
                {
                    skill.SetNewLvl();
                    break;
                }
            }
        }
    }

    public List<Characteristic> GetCharacteristicsForGenerate()
    {
        foreach(Characteristic characteristic in characteristics)
        {
            
            if(characteristic.InternalName == homeworld.AdvantageCharacteristics[0] || characteristic.InternalName == homeworld.AdvantageCharacteristics[1])
            {
                characteristic.Amount = 30;
            }
            else if (characteristic.InternalName == homeworld.DisadvantageCharacteristic)
            {
                characteristic.Amount = 20;
            }
            else
            {
                characteristic.Amount = 25;
            }

        }
        return characteristics;
    }

    public void UpdateCharacteristics(List<Characteristic> characteristics)
    {
        int i = 0;
        foreach (Characteristic characteristic in this.characteristics)
        {
            characteristic.Amount = characteristics[i].Amount;
            i++;
        }
    }

    public void AddTalent(Talent talent)
    {
        talents.Add(talent);
    }

    public void CalculatePhysAbilities()
    {
        parametrsForWeight = new List<float>();
        parametrsForWeight.Add(0.9f);
        parametrsForWeight.Add(2.25f);
        parametrsForWeight.Add(4.5f);
        parametrsForWeight.Add(9f);
        parametrsForWeight.Add(18f);
        parametrsForWeight.Add(27f);
        parametrsForWeight.Add(36f);
        parametrsForWeight.Add(45);
        parametrsForWeight.Add(56f);
        parametrsForWeight.Add(67f);
        parametrsForWeight.Add(78f);
        parametrsForWeight.Add(90f);
        parametrsForWeight.Add(112f);
        parametrsForWeight.Add(225f);
        parametrsForWeight.Add(337f);
        parametrsForWeight.Add(450f);
        parametrsForWeight.Add(675f);
        parametrsForWeight.Add(900f);
        parametrsForWeight.Add(1350f);
        parametrsForWeight.Add(1800f);
        parametrsForWeight.Add(2250f);

        int force = characteristics[2].Amount / 10 + characteristics[3].Amount / 10;
        carryWeight = parametrsForWeight[force];
        liftWeight = carryWeight * 2;
        pushWeight = liftWeight * 2;

        int speed = characteristics[4].Amount / 10;
        halfMove = speed;
        fullMove = speed * 2;
        natisk = speed * 3;
        run = speed * 6;

        fatigue = characteristics[3].Amount / 10 + characteristics[7].Amount / 10;

    }

    public void AddInclination(GameStat.Inclinations inclination)
    {
        int vh = 0;
        foreach (GameStat.Inclinations incl in inclinations)
        {
            if(incl == inclination)
            {
                vh++;
            }
        }
        if(vh == 0)
        {
            inclinations.Add(inclination);
        }
    }

    public void AddPsyPower(PsyPower psyPower)
    {
        psyPowers.Add(psyPower);
        psyPower.ActivatePower();
        experienceUnspent -= psyPower.Cost;
        experienceSpent += psyPower.Cost;
        experienceTotal += psyPower.Cost;
    }

    public bool UpgradePsyRate()
    {
        if(experienceUnspent >= (psyRating + 1) * 200)
        {
            psyRating += 1;
            experienceTotal += psyRating * 200;
            experienceSpent += psyRating * 200;
            experienceUnspent -= psyRating * 200;
            return true;
        }
        return false;
    }
}
