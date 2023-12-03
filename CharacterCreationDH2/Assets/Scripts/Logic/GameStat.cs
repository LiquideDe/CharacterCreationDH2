using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStat
{
    public static Dictionary<CharacterName, string> characterTranslate = new Dictionary<CharacterName, string>()
    {
        { CharacterName.WeaponSkill,"����� ����������" },
        { CharacterName.BallisticSkill,"����� ��������" },
        { CharacterName.Strength,"����" },
        { CharacterName.Toughness,"������������" },
        { CharacterName.Agility,"��������" },
        { CharacterName.Intelligence,"���������" },
        { CharacterName.Perception,"����������" },
        { CharacterName.Willpower,"���� ����" },
        { CharacterName.Fellowship,"�������������" },
        { CharacterName.Influence,"�������" }

    };

    public static Dictionary<Inclinations, string> inclinationTranslate = new Dictionary<Inclinations, string>()
    {
        {Inclinations.Agility, "��������" },
        {Inclinations.Ballistic, "��������" },
        {Inclinations.Defense, "������" },
        {Inclinations.Fellowship, "�������������" },
        {Inclinations.Fieldcraft, "�������" },
        {Inclinations.Finesse, "���������" },
        {Inclinations.General, "�����" },
        {Inclinations.Intelligence, "���������" },
        {Inclinations.Knowledge, "��������" },
        {Inclinations.Leadership, "���������" },
        {Inclinations.Offense, "���������" },
        {Inclinations.Perception, "����������" },
        {Inclinations.Psyker, "�������" },
        {Inclinations.Social, "�������" },
        {Inclinations.Strength, "����" },
        {Inclinations.Tech, "���" },
        {Inclinations.Toughness, "������������" },
        {Inclinations.Weapon, "������� ���" },
        {Inclinations.Willpower, "���� ����" }
    };

    public static Dictionary<SkillName, string> skillTranslate = new Dictionary<SkillName, string>()
    {
        {SkillName.Acrobatics, "����������" },
        {SkillName.Athletics, "��������" },
        {SkillName.Awareness, "������������" },
        {SkillName.Charm, "�������" },
        {SkillName.Command, "������������" },
        {SkillName.Commerce, "���������" },
        {SkillName.Deceive, "�����" },
        {SkillName.Dodge, "���������" },
        {SkillName.Inquiry, "��������" },
        {SkillName.Interrogation, "������" },
        {SkillName.Intimidate, "�����������" },
        {SkillName.Logic, "������" },
        {SkillName.Medicae, "������" },
        {SkillName.NavigateSurface, "���������(������)" },
        {SkillName.NavigateStellar, "���������(����)" },
        {SkillName.NavigateWarp, "���������(����)" },
        {SkillName.OperateAero, "����������(����)" },
        {SkillName.OperateSurf, "����������(������)" },
        {SkillName.OperateVoidship, "����������(����)" },
        {SkillName.Parry, "�����������" },
        {SkillName.Psyniscience, "����������" },
        {SkillName.Scrutiny, "����������������" },
        {SkillName.Security, "������������" },
        {SkillName.SleightOfHand, "�������� ���" },
        {SkillName.Stealth, "����������" },
        {SkillName.Survival, "���������" },
        {SkillName.TechUse, "��������������" },
        {SkillName.CommonLore, "����� ������" },
        {SkillName.ForbiddenLore, "��������� ������" },
        {SkillName.Linquistics, "�����������" },
        {SkillName.ScholasticLore, "������ ������" },
        {SkillName.Trade, "�������" },
    };

    public static Dictionary<KnowledgeName, string> knowledgeTranslation = new Dictionary<KnowledgeName, string>()
    {
        {KnowledgeName.Arheotech, "��������" },
        {KnowledgeName.AstartesOfChaos, "��������������� �����" },
        {KnowledgeName.CriminalForb, "������������ �������" },
        {KnowledgeName.Demonology, "�����������" },
        {KnowledgeName.Heresy, "�����" },
        {KnowledgeName.HorusHeresyAndLongWar, "����� ������ � ������ �����" },
        {KnowledgeName.Inquisition, "����������" },
        {KnowledgeName.Mutant, "�������" },
        {KnowledgeName.OficioAssasinorum, "������ �����������" },
        {KnowledgeName.Pirates, "������" },
        {KnowledgeName.Psykers, "��������" },
        {KnowledgeName.Warp, "����" },
        {KnowledgeName.Xenos, "�������" },
        {KnowledgeName.RunesOfOrder, "���� ������" },
        {KnowledgeName.MarkOfChaos, "����� �����" },
        {KnowledgeName.EldariLingva, "���� ������" },
        {KnowledgeName.HighGhotic, "������� �����" },
        {KnowledgeName.ImperialCodes, "��������� ����" },
        {KnowledgeName.Jargon, "������ ��������" },
        {KnowledgeName.NecrontirLingva, "���������" },
        {KnowledgeName.OrcsLingva, "�������" },
        {KnowledgeName.LingvaTechno, "������-�����" },
        {KnowledgeName.TauLingva, "���� ���" },
        {KnowledgeName.CriminalCodes, "���������� �����" },
        {KnowledgeName.MarkOfXenos, "����� ��������" },
        {KnowledgeName.Sororitas, "������ ���������" },
        {KnowledgeName.Arbitres, "������� ��������" },
        {KnowledgeName.Astartes, "������� ��������" },
        {KnowledgeName.AstraTelepatica, "������� ����� ����������" },
        {KnowledgeName.Mechanicus, "������� ���������" },
        {KnowledgeName.Administratum, "�������������" },
        {KnowledgeName.CapitanHartisti, "��������-��������" },
        {KnowledgeName.KolegiaTitanika, "�������� ��������" },
        {KnowledgeName.Eklezarkhia, "������������" },
        {KnowledgeName.ImperialCredo, "��������� �����" },
        {KnowledgeName.AstraMilitarum, "����� ���������" },
        {KnowledgeName.ImperialFleet, "��������� ����" },
        {KnowledgeName.Imperium, "��������" },
        {KnowledgeName.Navigators, "����������" },
        {KnowledgeName.Teroborona, "���� ����������� �������" },
        {KnowledgeName.RougeTrader, "������� ��������" },
        {KnowledgeName.ScholaProgenium, "����� ���������" },
        {KnowledgeName.Techno, "�����" },
        {KnowledgeName.Criminal, "������������" },
        {KnowledgeName.War, "�����" },
        {KnowledgeName.AgroTr, "����" },
        {KnowledgeName.ArcheologyTr, "��������" },
        {KnowledgeName.GunsmithTr, "���������" },
        {KnowledgeName.AustroGraphTr, "���������" },
        {KnowledgeName.ChymicTr, "�����" },
        {KnowledgeName.CryptoTr, "����������" },
        {KnowledgeName.CockTr, "�����" },
        {KnowledgeName.ExploratorTr, "�����������" },
        {KnowledgeName.LingvistTr, "��������" },
        {KnowledgeName.EpistolTr, "�����������" },
        {KnowledgeName.MortikatorTr, "����������" },
        {KnowledgeName.IpolnitelTr, "�����������" },
        {KnowledgeName.GeologyTr, "������" },
        {KnowledgeName.RezchikTr, "������" },
        {KnowledgeName.SculptureTr, "���������" },
        {KnowledgeName.KorabelTr, "�������" },
        {KnowledgeName.PredskazatelTr, "�������������" },
        {KnowledgeName.TechnomantTr, "���������" },
        {KnowledgeName.PustoplavatelTr, "��������������" },
        {KnowledgeName.Astromancy, "�����������" },
        {KnowledgeName.Beasts, "�����" },
        {KnowledgeName.Burocracy, "����������" },
        {KnowledgeName.Chemistry, "�����" },
        {KnowledgeName.Cryptology, "�����������" },
        {KnowledgeName.Geraldica, "����������" },
        {KnowledgeName.ImperialPatents, "��������� �������" },
        {KnowledgeName.Justice, "����������" },
        {KnowledgeName.Legends, "�������" },
        {KnowledgeName.Numerology, "�����������" },
        {KnowledgeName.Occultism, "����������" },
        {KnowledgeName.Phylosophy, "���������" },
        {KnowledgeName.TacticImperialis, "������� ����������" },
        {KnowledgeName.Askelon, "�������" }
    };
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

    public enum RoleName {None, Assasin, Hirurgion, Desperado, Ierofant, Mistic, Sage, Seeker, Warrior, 
    Fanatic, Kaushisa, Crusader, Ass}

    public static Dictionary<BackgroundName, string> backstoryTranslation = new Dictionary<BackgroundName, string>()
    {
        {BackgroundName.Administratum, "������� �������������" },
        {BackgroundName.Arbitres, "������� ��������" },
        {BackgroundName.AstraTelepatica, "������� ����� ����������" },
        {BackgroundName.Mechanicus, "������� ���������" },
        {BackgroundName.Ministorum, "������� ����������" },
        {BackgroundName.Militarum, "������� ���������" },
        {BackgroundName.Izgoi, "�����" },
        {BackgroundName.Sororitas, "������� ���������" },
        {BackgroundName.Mutant, "������" },
        {BackgroundName.Heretech, "������" },
        {BackgroundName.ImperialFleet, "��������� ����" },
        {BackgroundName.RougeTraderFleet, "���� �������� ��������" }
    };

    public static Dictionary<RoleName, string> roleTranslation = new Dictionary<RoleName, string>()
    {
        {RoleName.Assasin, "�������"},
        {RoleName.Hirurgion, "���������"},
        {RoleName.Desperado, "���������"},
        {RoleName.Ierofant, "��������"},
        {RoleName.Mistic, "������"},
        {RoleName.Sage, "������"},
        {RoleName.Seeker, "��������"},
        {RoleName.Warrior, "�������"},
        {RoleName.Fanatic, "�������"},
        {RoleName.Kaushisa, "��������"},
        {RoleName.Crusader, "�����������"},
        {RoleName.Ass, "��"},
    };

    public static Dictionary<Inclinations, string> descriptionInclination = new Dictionary<Inclinations, string>()
    {
        {Inclinations.Agility, "���������� ����������� ��������� �������� ��������, � ����� ��������� � ��� ������ � �������." },
        {Inclinations.Ballistic, "���������� ����������� ��������� �������� ����� ��������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Defense, "������� � ���� ����������� ������ ������ �������� ����� ������������ ����� ��������. �������� �� ��� ��������� �������������� ��� �������� ���������, ��� �������� �� ����� �������� � � ������ ������� �������� 41-��� �����������, ���������� ������� ����� ������. " },
        {Inclinations.Fellowship, "���������� ����������� ��������� �������� �������������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Fieldcraft, "������ �� ������� ��������� ��������� ����� �� ����� ������ ��� � ��������� ��������. ������� �� ����������� ������� ����� ����������������� � ����������� � ������� ��������, �� ������ ��������, �� ������ �������. " },
        {Inclinations.Finesse, "������ � ������� �� ����������� ��������� ���������� �� ������������ ���������� � ���������� ������������. ������� �� ����������� ��������� ����� ����� ���������� � �������� �� ������� ��������� ��� ������������� ������������� ������." },
        {Inclinations.General, "�����" },
        {Inclinations.Intelligence, "���������� ����������� ��������� �������� ���������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Knowledge, "������������ ���� � ������������ ����������� ��������� �������� ������ ����������, ��� �������� ������� �� ������� ������. � �� ����� ��� ����������� ��������� ���������� �������� � ��������� ������������ ������� � ���������� ����� ���������, ��������� �� ����������� �������� ����� ������������ ����� �������� ������ � ����������." },
        {Inclinations.Leadership, "� ��������� ����� ��������� ��������� �����, �� ��� ����������� ��� �� ����� ������, ��� ������� ���� ��� ����������� ����. ����������� ������������ �������� ��� ������ ������������, � ������� � ���� ����������� �������� ���������� ���������� �� ������ ����������� � ����������� ����� ������� ���������� ����������� ������ ��� ���������� �� ��������-���������." },
        {Inclinations.Offense, "��������� � ���� ����������� ������������ ������������ ������ ���� ������ ����� �����������, ��������������� �������. ��� ������� ����� ��������� � ���������� ���������� ����������� ������� ��� ��������� ����� ������������� ������� �����." },
        {Inclinations.Perception, "���������� ����������� ��������� �������� ����������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Psyker, "���������� ������� ����� �������� ���� ���������� ������ ������������ ������� ������������ ������. ����� ��� ��������� �� ����������� ������� ������������������ �������, ��������������� � ����������� ���������� ����� ��� ������������� ����������� ���. " },
        {Inclinations.Social, "����� ������� ����� ���� �� ����� �������, ��� �����������, �������� ��� ���������� � ��������� � �������� ��������� �����. � ���� ����������� ����� �������, ��� ��������� ������� ������������ ����������� ���� � ������ ����������� ��� ������������� ������� � �������������� ������������, ��������������� �������� ���������� � ����� �����������. " },
        {Inclinations.Strength, "���������� ����������� ��������� �������� ����, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Tech, "���� �������� ������������ ����������� � ������ ����������� ���������� Ҹ���� ��� ����������, � ��� ������ ����� ����������� � ����. ��������� �� ����������� ����� ���������� ������ �������� ������ �����, �� ����� �������� � �� ������ � �������� �������� ��������� ���, ��� ������ ������ ���� �������." },
        {Inclinations.Toughness, "���������� ����������� ��������� �������� ������������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Weapon, "���������� ����������� ��������� �������� ����� ����������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Willpower, "���������� ����������� ��������� �������� ���� ����, � ����� ��������� � ��� ������ � �������. " }
    };
}
