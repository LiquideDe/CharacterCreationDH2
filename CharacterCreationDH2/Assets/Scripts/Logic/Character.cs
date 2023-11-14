using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    private string name, background, role, ageText, prophecy, constitution, hair, eyes, skeen, physFeatures, memoryOfHome, memoryOfBackground, equipment;
    private int age, fatePoint, madnessPoints, corruptionPoints, wounds, psyRating, halfMove, fullMove, natisk, fatigue, carryWeight, liftWeight, pushWeight,
        experienceTotal, experienceUnspent, experienceSpent;
    private List<Characteristic> characteristics = new List<Characteristic>();
    private List<GameStat.Inclinations> inclinations = new List<GameStat.Inclinations>();
    private List<Talent> talents = new List<Talent>();
    private List<Skill> skills = new List<Skill>();
    private List<Knowledge> knowledges = new List<Knowledge>();
    private List<string> mentalDisorders = new List<string>();
    private List<string> mutation = new List<string>();
    private List<PsyDisciplence> psyDisciplences = new List<PsyDisciplence>();
    private Homeworld homeworld;

    #region Свойства
    public string Name { get { return name; } }
    public Homeworld HomeWorld { get { return homeworld; } }
    public string Background { get { return background; } }
    public string Role { get { return role; } }
    public string AgeText { get => ageText; }
    public string Prophecy { get => prophecy;}
    public string Constitution { get => constitution;}
    public string Hair { get => hair; }
    public string Eyes { get => eyes; }
    public string Skeen { get => skeen; }
    public string PhysFeatures { get => physFeatures;}
    public string MemoryOfHome { get => memoryOfHome;}
    public string MemoryOfBackground { get => memoryOfBackground;}
    public string Equipment { get => equipment;}
    public int Age { get => age; set => age = value; }
    public int FatePoint { get => fatePoint; set => fatePoint = value; }
    public int MadnessPoints { get => madnessPoints; set => madnessPoints = value; }
    public int Wounds { get => wounds; set => wounds = value; }
    public int CorruptionPoints { get => corruptionPoints; set => corruptionPoints = value; }
    public int PsyRating { get => psyRating; set => psyRating = value; }
    public int HalfMove { get => halfMove;}
    public int FullMove { get => fullMove;}
    public int Natisk { get => natisk;}
    public int Fatigue { get => fatigue;}
    public int CarryWeight { get => carryWeight;}
    public int LiftWeight { get => liftWeight;}
    public int PushWeight { get => pushWeight;}
    public int ExperienceTotal { get => experienceTotal; set => experienceTotal = value; }
    public int ExperienceUnspent { get => experienceUnspent; set => experienceUnspent = value; }
    public int ExperienceSpent { get => experienceSpent; set => experienceSpent = value; }
    #endregion

    public Character()
    {
        CreateCharacteristics();
    }

    private void CreateCharacteristics()
    {
        characteristics.Add(new Characteristic(GameStat.CharacterName.WeaponSkill, GameStat.Inclinations.Weapon, GameStat.Inclinations.Offense));
        characteristics.Add(new Characteristic(GameStat.CharacterName.BallisticSkill, GameStat.Inclinations.Ballistic, GameStat.Inclinations.Finesse));
        characteristics.Add(new Characteristic(GameStat.CharacterName.Strength, GameStat.Inclinations.Strength, GameStat.Inclinations.Offense));
        characteristics.Add(new Characteristic(GameStat.CharacterName.Toughness, GameStat.Inclinations.Toughness, GameStat.Inclinations.Defense));
        characteristics.Add(new Characteristic(GameStat.CharacterName.Agility, GameStat.Inclinations.Agility, GameStat.Inclinations.Finesse));
        characteristics.Add(new Characteristic(GameStat.CharacterName.Intelligence, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        characteristics.Add(new Characteristic(GameStat.CharacterName.Perception, GameStat.Inclinations.Perception, GameStat.Inclinations.Fieldcraft));
        characteristics.Add(new Characteristic(GameStat.CharacterName.Willpower, GameStat.Inclinations.Willpower, GameStat.Inclinations.Psyker));
        characteristics.Add(new Characteristic(GameStat.CharacterName.Fellowship, GameStat.Inclinations.Fellowship, GameStat.Inclinations.Social));

        skills.Add(new Skill(GameStat.SkillName.Acrobatics, GameStat.Inclinations.Agility, GameStat.Inclinations.General));
        skills.Add(new Skill(GameStat.SkillName.Athletics, GameStat.Inclinations.Strength, GameStat.Inclinations.General));
        skills.Add(new Skill(GameStat.SkillName.Awareness, GameStat.Inclinations.Perception, GameStat.Inclinations.Fieldcraft));
        skills.Add(new Skill(GameStat.SkillName.Charm, GameStat.Inclinations.Fellowship, GameStat.Inclinations.Social));
        skills.Add(new Skill(GameStat.SkillName.Command, GameStat.Inclinations.Fellowship, GameStat.Inclinations.Leadership));
        skills.Add(new Skill(GameStat.SkillName.Commerce, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        skills.Add(new Skill(GameStat.SkillName.Deceive, GameStat.Inclinations.Fellowship, GameStat.Inclinations.Social));
        skills.Add(new Skill(GameStat.SkillName.Dodge, GameStat.Inclinations.Agility, GameStat.Inclinations.Defense));
        skills.Add(new Skill(GameStat.SkillName.Inquiry, GameStat.Inclinations.Fellowship, GameStat.Inclinations.Social));
        skills.Add(new Skill(GameStat.SkillName.Interrogation, GameStat.Inclinations.Willpower, GameStat.Inclinations.Social));
        skills.Add(new Skill(GameStat.SkillName.Intimidate, GameStat.Inclinations.Strength, GameStat.Inclinations.Social));
        skills.Add(new Skill(GameStat.SkillName.Logic, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        skills.Add(new Skill(GameStat.SkillName.Medicae, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Fieldcraft));
        skills.Add(new Skill(GameStat.SkillName.NavigateStellar, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Fieldcraft));
        skills.Add(new Skill(GameStat.SkillName.NavigateSurface, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Fieldcraft));
        skills.Add(new Skill(GameStat.SkillName.NavigateWarp, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Fieldcraft));
        skills.Add(new Skill(GameStat.SkillName.OperateAero, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Tech));
        skills.Add(new Skill(GameStat.SkillName.OperateSurf, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Tech));
        skills.Add(new Skill(GameStat.SkillName.OperateVoidship, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Tech));
        skills.Add(new Skill(GameStat.SkillName.Parry, GameStat.Inclinations.Weapon, GameStat.Inclinations.Defense));
        skills.Add(new Skill(GameStat.SkillName.Psyniscience, GameStat.Inclinations.Perception, GameStat.Inclinations.Psyker));
        skills.Add(new Skill(GameStat.SkillName.Scrutiny, GameStat.Inclinations.Perception, GameStat.Inclinations.General));
        skills.Add(new Skill(GameStat.SkillName.Security, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Tech));
        skills.Add(new Skill(GameStat.SkillName.SleightOfHand, GameStat.Inclinations.Agility, GameStat.Inclinations.Knowledge));
        skills.Add(new Skill(GameStat.SkillName.Stealth, GameStat.Inclinations.Agility, GameStat.Inclinations.Fieldcraft));
        skills.Add(new Skill(GameStat.SkillName.Survival, GameStat.Inclinations.Perception, GameStat.Inclinations.Fieldcraft));
        skills.Add(new Skill(GameStat.SkillName.TechUse, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Tech));

        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Arheotech, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.AstartesOfChaos, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Criminal, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Demonology, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Heresy, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.HorusHeresyAndLongWar, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Inquisition, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Mutant, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.OficioAssasinorum, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Pirates, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Psykers, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Warp, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Xenos, GameStat.SkillName.ForbiddenLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.ImperialCodes, GameStat.SkillName.Linquistics, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Jargon, GameStat.SkillName.Linquistics, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.NecrontirLingva, GameStat.SkillName.Linquistics, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.OrcsLingva, GameStat.SkillName.Linquistics, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.LingvaTechno, GameStat.SkillName.Linquistics, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.TauLingva, GameStat.SkillName.Linquistics, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.CriminalCodes, GameStat.SkillName.Linquistics, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.MarkOfXenos, GameStat.SkillName.Linquistics, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.AustroGraphTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.AgroTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.ArcheologyTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.ChymicTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.CockTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.CryptoTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.EpistolTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.ExploratorTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.GeologyTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.GunsmithTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.IpolnitelTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.KorabelTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.LingvistTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.MortikatorTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.PredskazatelTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.PustoplavatelTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.RezchikTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.SculptureTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.TechnomantTr, GameStat.SkillName.Trade, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Astromancy, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Beasts, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Burocracy, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Chemistry, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Cryptology, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Geraldica, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.ImperialPatents, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Justice, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Legends, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Numerology, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Occultism, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Phylosophy, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.TacticImperialis, GameStat.SkillName.ScholasticLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.Knowledge));

        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Sororitas, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Arbitres, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Astartes, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.AstraTelepatica, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Mechanicus, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Administratum, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Askelon, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.CapitanHartisti, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.KolegiaTitanika, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Eklezarkhia, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.ImperialCredo, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.AstraMilitarum, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.ImperialFleet, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Imperium, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Navigators, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Teroborona, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.RougeTrader, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.ScholaProgenium, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Techno, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.Criminal, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
        knowledges.Add(new Knowledge(GameStat.KnowledgeName.War, GameStat.SkillName.CommonLore, GameStat.Inclinations.Intelligence, GameStat.Inclinations.General));
    }

    public void SetHomeWorld(Homeworld homeworld, int bonusFatePoint = 0, int bonusWound = 0)
    {
        this.homeworld = homeworld;
        fatePoint = homeworld.Fatepoint;
        wounds = homeworld.Wound + bonusWound;
        Debug.Log($"Теперь у нас {wounds} ран");
        inclinations.Add(homeworld.Inclination);

        var bonusSkills = homeworld.GetSkills();
        if (bonusSkills != null)
        {
            foreach(string skill in bonusSkills)
                UpgradeSkill(skill);
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
        wounds = homeworld.Wound;

    }

    private void UpgradeSkill(string skillName)
    {
        int sch = 0;
        foreach(Skill skill in skills)
        {
            if(skill.Name == skillName)
            {
                skill.SetNewLvl();
                sch += 1;
                break;
            }
        }
        if(sch == 0)
        {
            foreach (Knowledge skill in knowledges)
            {
                if (skill.NameKnowledge == skillName)
                {
                    skill.SetNewLvl();
                    break;
                }
            }
        }
    }
}
