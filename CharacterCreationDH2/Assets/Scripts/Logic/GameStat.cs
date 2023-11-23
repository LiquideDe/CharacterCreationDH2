using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStat
{
    public static Dictionary<CharacterName, string> characterTranslate = new Dictionary<CharacterName, string>()
    {
        { CharacterName.WeaponSkill,"Навык Рукопашной" },
        { CharacterName.BallisticSkill,"Навык Стрельбы" },
        { CharacterName.Strength,"Сила" },
        { CharacterName.Toughness,"Выносливость" },
        { CharacterName.Agility,"Ловкость" },
        { CharacterName.Intelligence,"Интеллект" },
        { CharacterName.Perception,"Восприятие" },
        { CharacterName.Willpower,"Сила Воли" },
        { CharacterName.Fellowship,"Общительность" },
        { CharacterName.Influence,"Влияние" }

    };

    public static Dictionary<Inclinations, string> inclinationTranslate = new Dictionary<Inclinations, string>()
    {
        {Inclinations.Agility, "Ловкость" },
        {Inclinations.Ballistic, "Стрельба" },
        {Inclinations.Defense, "Защита" },
        {Inclinations.Fellowship, "Общительность" },
        {Inclinations.Fieldcraft, "Полевое" },
        {Inclinations.Finesse, "Изящество" },
        {Inclinations.General, "Общее" },
        {Inclinations.Intelligence, "Интеллект" },
        {Inclinations.Knowledge, "Знания" },
        {Inclinations.Leadership, "Лидерство" },
        {Inclinations.Offense, "Нападение" },
        {Inclinations.Perception, "Восприятие" },
        {Inclinations.Psyker, "Псайкер" },
        {Inclinations.Social, "Общение" },
        {Inclinations.Strength, "Сила" },
        {Inclinations.Tech, "Тех" },
        {Inclinations.Toughness, "Выносливость" },
        {Inclinations.Weapon, "Ближний бой" },
        {Inclinations.Willpower, "Сила Воли" }
    };

    public static Dictionary<SkillName, string> skillTranslate = new Dictionary<SkillName, string>()
    {
        {SkillName.Acrobatics, "Акробатика" },
        {SkillName.Athletics, "Атлетика" },
        {SkillName.Awareness, "Бдительность" },
        {SkillName.Charm, "Обаяние" },
        {SkillName.Command, "Командование" },
        {SkillName.Commerce, "Коммерция" },
        {SkillName.Deceive, "Обман" },
        {SkillName.Dodge, "Уклонение" },
        {SkillName.Inquiry, "Дознание" },
        {SkillName.Interrogation, "Допрос" },
        {SkillName.Intimidate, "Запугивание" },
        {SkillName.Logic, "Логика" },
        {SkillName.Medicae, "Медика" },
        {SkillName.NavigateSurface, "Навигация(наземн)" },
        {SkillName.NavigateStellar, "Навигация(косм)" },
        {SkillName.NavigateWarp, "Навигация(варп)" },
        {SkillName.OperateAero, "Управление(аэро)" },
        {SkillName.OperateSurf, "Управление(наземн)" },
        {SkillName.OperateVoidship, "Управление(косм)" },
        {SkillName.Parry, "Парирование" },
        {SkillName.Psyniscience, "Психонаука" },
        {SkillName.Scrutiny, "Проницательность" },
        {SkillName.Security, "Безопасность" },
        {SkillName.SleightOfHand, "Ловкость рук" },
        {SkillName.Stealth, "Скрытность" },
        {SkillName.Survival, "Выживание" },
        {SkillName.TechUse, "Техпользование" },
        {SkillName.CommonLore, "Общие знания" },
        {SkillName.ForbiddenLore, "Запретные знания" },
        {SkillName.Linquistics, "Лингвистика" },
        {SkillName.ScholasticLore, "Ученые знания" },
        {SkillName.Trade, "Ремесло" },
    };

    public static Dictionary<KnowledgeName, string> knowledgeTranslation = new Dictionary<KnowledgeName, string>()
    {
        {KnowledgeName.Arheotech, "Археотех" },
        {KnowledgeName.AstartesOfChaos, "Космодесантники хаоса" },
        {KnowledgeName.CriminalForb, "Криминальные картели" },
        {KnowledgeName.Demonology, "Демонология" },
        {KnowledgeName.Heresy, "Ересь" },
        {KnowledgeName.HorusHeresyAndLongWar, "Ересь Хоруса и Долгая Война" },
        {KnowledgeName.Inquisition, "Инквизиция" },
        {KnowledgeName.Mutant, "Мутанты" },
        {KnowledgeName.OficioAssasinorum, "Официо Ассасинорум" },
        {KnowledgeName.Pirates, "Пираты" },
        {KnowledgeName.Psykers, "Псайкеры" },
        {KnowledgeName.Warp, "Варп" },
        {KnowledgeName.Xenos, "Ксеносы" },
        {KnowledgeName.RunesOfOrder, "Руны Ордена" },
        {KnowledgeName.MarkOfChaos, "Знаки Хаоса" },
        {KnowledgeName.EldariLingva, "Язык Эльдар" },
        {KnowledgeName.HighGhotic, "Высокий Готик" },
        {KnowledgeName.ImperialCodes, "Имперские Коды" },
        {KnowledgeName.Jargon, "Жаргон Наёмников" },
        {KnowledgeName.NecrontirLingva, "Некронтир" },
        {KnowledgeName.OrcsLingva, "Оркский" },
        {KnowledgeName.LingvaTechno, "Лингва-Техно" },
        {KnowledgeName.TauLingva, "Язык Тау" },
        {KnowledgeName.CriminalCodes, "Преступные шифры" },
        {KnowledgeName.MarkOfXenos, "Метки Ксеносов" },
        {KnowledgeName.Sororitas, "Адепта Сороритас" },
        {KnowledgeName.Arbitres, "Адептус Арбитрес" },
        {KnowledgeName.Astartes, "Адептус Астартес" },
        {KnowledgeName.AstraTelepatica, "Адептус Астра Телепатика" },
        {KnowledgeName.Mechanicus, "Адептус Механикус" },
        {KnowledgeName.Administratum, "Администратум" },
        {KnowledgeName.CapitanHartisti, "Капитаны-хартисты" },
        {KnowledgeName.KolegiaTitanika, "Коллегия Титаника" },
        {KnowledgeName.Eklezarkhia, "Экклезиархия" },
        {KnowledgeName.ImperialCredo, "Имперское Кредо" },
        {KnowledgeName.AstraMilitarum, "Астра Милитарум" },
        {KnowledgeName.ImperialFleet, "Имперский Флот" },
        {KnowledgeName.Imperium, "Империум" },
        {KnowledgeName.Navigators, "Навигаторы" },
        {KnowledgeName.Teroborona, "Силы Планетарной Обороны" },
        {KnowledgeName.RougeTrader, "Вольные Торговцы" },
        {KnowledgeName.ScholaProgenium, "Схола Прогениум" },
        {KnowledgeName.Techno, "Техно" },
        {KnowledgeName.Criminal, "Преступность" },
        {KnowledgeName.War, "Война" },
        {KnowledgeName.AgroTr, "Агро" },
        {KnowledgeName.ArcheologyTr, "Археолог" },
        {KnowledgeName.GunsmithTr, "Оружейник" },
        {KnowledgeName.AustroGraphTr, "Астрограф" },
        {KnowledgeName.ChymicTr, "Химик" },
        {KnowledgeName.CryptoTr, "Криптограф" },
        {KnowledgeName.CockTr, "Повар" },
        {KnowledgeName.ExploratorTr, "Эксплоратор" },
        {KnowledgeName.LingvistTr, "Лингвист" },
        {KnowledgeName.EpistolTr, "Эпистолярий" },
        {KnowledgeName.MortikatorTr, "Мортикатор" },
        {KnowledgeName.IpolnitelTr, "Исполнитель" },
        {KnowledgeName.GeologyTr, "Геолог" },
        {KnowledgeName.RezchikTr, "Резчик" },
        {KnowledgeName.SculptureTr, "Скульптор" },
        {KnowledgeName.KorabelTr, "Корабел" },
        {KnowledgeName.PredskazatelTr, "Предсказатель" },
        {KnowledgeName.TechnomantTr, "Техномант" },
        {KnowledgeName.PustoplavatelTr, "Пустоплаватель" },
        {KnowledgeName.Astromancy, "Астромансия" },
        {KnowledgeName.Beasts, "Звери" },
        {KnowledgeName.Burocracy, "Бюрократия" },
        {KnowledgeName.Chemistry, "Химия" },
        {KnowledgeName.Cryptology, "Криптология" },
        {KnowledgeName.Geraldica, "Геральдика" },
        {KnowledgeName.ImperialPatents, "Имперские Патенты" },
        {KnowledgeName.Justice, "Правосудие" },
        {KnowledgeName.Legends, "Легенды" },
        {KnowledgeName.Numerology, "Нумерология" },
        {KnowledgeName.Occultism, "Оккультизм" },
        {KnowledgeName.Phylosophy, "Философия" },
        {KnowledgeName.TacticImperialis, "Тактика Империалис" },
        {KnowledgeName.Askelon, "Аскелон" }
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
        {BackgroundName.Administratum, "Адептус Администратум" },
        {BackgroundName.Arbitres, "Адептус Арбитрес" },
        {BackgroundName.AstraTelepatica, "Адептус Астра Телепатика" },
        {BackgroundName.Mechanicus, "Адептус Механикус" },
        {BackgroundName.Ministorum, "Адептус Министорум" },
        {BackgroundName.Militarum, "Адептус Милитарум" },
        {BackgroundName.Izgoi, "Изгой" },
        {BackgroundName.Sororitas, "Адептус Сороритас" },
        {BackgroundName.Mutant, "Мутант" },
        {BackgroundName.Heretech, "Еретех" },
        {BackgroundName.ImperialFleet, "Имперский флот" },
        {BackgroundName.RougeTraderFleet, "Флот вольного торговца" }
    };

    public static Dictionary<RoleName, string> roleTranslation = new Dictionary<RoleName, string>()
    {
        {RoleName.Assasin, "Ассасин"},
        {RoleName.Hirurgion, "Хирургеон"},
        {RoleName.Desperado, "Десперадо"},
        {RoleName.Ierofant, "Иерофант"},
        {RoleName.Mistic, "Мистик"},
        {RoleName.Sage, "Мудрец"},
        {RoleName.Seeker, "Искатель"},
        {RoleName.Warrior, "Воитель"},
        {RoleName.Fanatic, "Фанатик"},
        {RoleName.Kaushisa, "Кающийся"},
        {RoleName.Crusader, "Крестоносец"},
        {RoleName.Ass, "Ас"},
    };
}
