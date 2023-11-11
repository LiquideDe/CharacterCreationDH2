using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStat
{
    public enum Inclinations {None, Agility, Ballistic, Defense, Fellowship,
    Fieldcraft, Finesse, General, Intelligence, Knowledge, Leadership,
    Offense, Perception, Psyker, Social, Strength, Tech, Toughness,
    Weapon, Willpower};

    public enum CharacterName { None, WeaponSkill, BallisticSkill, Strength, Toughness, Agility, Intelligence, Perception, Willpower, Fellowship, Influence}

    public enum SkillName {None, Acrobatics, Athletics, Awareness, Charm, Command,
    Commerce, Deceive, Dodge, Inquiry, Interrogation, Intimidate, Logic,
    Medicae, NavigateSurface, NavigateStellar, NavigateWarp, OperateAero,
    OperateSurf, OperateVoidship, Parry, Psyniscience, Scrutiny, Security,
    SleightOfHand, Stealth, Survival, TechUse, CommonLore, ForbiddenLore, 
    Linquistics, ScholasticLore, Trade}

    public enum KnowledgeName {None, Arheotech, AstartesOfChaos, CriminalForb, Demonology,
    Heresy, HorusHeresyAndLongWar, Inquisition, Mutant, OficioAssasinorum, 
    Pirates, Psykers, Warp, Xenos, RunesOfOrder, MarkOfChaos, EldariLingva, HighGhotic, 
    ImperialCodes, NecrontirLingva, Jargon, OrcsLingva, LingvaTechno, TauLingva,
    CriminalCodes, MarkOfXenos, AgroTr, ArcheologyTr, GunsmithTr, AustroGraphTr,
    ChymicTr, CryptoTr, CockTr, ExploratorTr, LingvistTr, EpistolTr, MortikatorTr,
    IpolnitelTr, GeologyTr, RezchikTr, SculptureTr, KorabelTr, PredskazatelTr, 
    TechnomantTr, PustoplavatelTr, Astromancy, Beasts, Burocracy, Chemistry, Cryptology,
    Geraldica, ImperialPatents, Justice, Legends, Numerology, Occultism, Phylosophy,
    TacticImperialis, Sororitas, Arbitres, Astartes, AstraTelepatica, Mechanicus, Administratum, 
    Askelon, CapitanHartisti, KolegiaTitanika, Eklezarkhia, ImperialCredo, AstraMilitarum, 
    ImperialFleet, Imperium, Navigators, Teroborona, RougeTrader, ScholaProgenium, Techno, 
    Criminal, War, Ministorum
    }

    public enum WorldName {None, FeralWorld, ForgeWorld, HighBorn, HiveWorld, TempleWorld, VoidBorn, 
    AgroWorld, FeodalWorld, FrontWorld, DaemonWorld, PrisonWorld, QuarantineWorld, GardenWorld,
    ScienseStation }

    public enum BackgroundName {None, Administratum, Arbitres, AstraTelepatica, Mechanicus, Ministorum,
    Militarum, Izgoi, Sororitas, Mutant, Vichishennii, Heretech, ImperialFleet, RougeTraderFleet }

    public enum RoleName {None, Assasin, Herurgion, Desperado, Ierofant, Mistic, Sage, Seeker, Warrior, 
    Fanatic, Kaushisa, Crusader, Ass}

}
