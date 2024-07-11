using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public static class GameStat
{
    public static Dictionary<CharacteristicName, string> characterTranslate = new Dictionary<CharacteristicName, string>()
    {
        { CharacteristicName.WeaponSkill,"Навык Рукопашной" },
        { CharacteristicName.BallisticSkill,"Навык Стрельбы" },
        { CharacteristicName.Strength,"Сила" },
        { CharacteristicName.Toughness,"Выносливость" },
        { CharacteristicName.Agility,"Ловкость" },
        { CharacteristicName.Intelligence,"Интеллект" },
        { CharacteristicName.Perception,"Восприятие" },
        { CharacteristicName.Willpower,"Сила Воли" },
        { CharacteristicName.Fellowship,"Общительность" },
        { CharacteristicName.Influence,"Влияние" }

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
        {Inclinations.Knowledge, "Познание" },
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

    public static Dictionary<string, Inclinations> inclinationReverseTranslate = new Dictionary<string, Inclinations>()
    {
        { "Ловкость", Inclinations.Agility },
        { "Стрельба", Inclinations.Ballistic },
        {     "Защита"          ,Inclinations.Defense                      },
        {     "Общительность"   ,Inclinations.Fellowship                      },
        {     "Полевое"         ,Inclinations.Fieldcraft                       },
        {     "Изящество"       ,Inclinations.Finesse                          },
        {     "Общее"           ,Inclinations.General                          },
        {     "Интеллект"       ,Inclinations.Intelligence                     },
        {     "Познание"        ,Inclinations.Knowledge                        },
        {     "Лидерство"       ,Inclinations.Leadership                       },
        {     "Нападение"       ,Inclinations.Offense                          },
        {     "Восприятие"      ,Inclinations.Perception                               },
        {     "Псайкер"         ,Inclinations.Psyker                           },
        {     "Общение"         ,Inclinations.Social                           },
        {     "Сила"            ,Inclinations.Strength                     },
        {     "Тех"             ,Inclinations.Tech                         },
        {     "Выносливость"    ,Inclinations.Toughness                                 },
        {     "Ближний бой"     ,Inclinations.Weapon                                       },
        {     "Сила Воли"       ,Inclinations.Willpower                        }
    };

    public static Dictionary<string, string> KnowledgeTranslate = new Dictionary<string, string>()
    {
        {"Trade", "Ремесло" },
        {"CommonLore", "Общие знания" },
        {"ForbiddenLore", "Запретные знания" },
        {"ScholasticLore", "Ученые знания" },
        {"Linquistics", "Лингвистика" }
    };
    
    public enum Inclinations {None, Agility, Ballistic, Defense, Fellowship,
    Fieldcraft, Finesse, General, Intelligence, Knowledge, Leadership,
    Offense, Perception, Psyker, Social, Strength, Tech, Toughness,
    Weapon, Willpower, Elite};

    public enum CharacteristicName { None, WeaponSkill, BallisticSkill, Strength, Toughness, Agility, Intelligence, Perception, Willpower, Fellowship, Influence}    
    
    public enum SkillName {None, Acrobatics, Athletics, Awareness, Charm, Command,
    Commerce, Deceive, Dodge, Inquiry, Interrogation, Intimidate, Logic,
    Medicae, NavigateSurface, NavigateStellar, NavigateWarp, OperateAero,
    OperateSurf, OperateVoidship, Parry, Psyniscience, Scrutiny, Security,
    SleightOfHand, Stealth, Survival, TechUse, CommonLore, ForbiddenLore, 
    Linquistics, ScholasticLore, Trade}

    public enum RoleName {None, Assasin, Hirurgion, Desperado, Ierofant, Mistic, Sage, Seeker, Warrior, 
    Fanatic, Kaushisa, Crusader, Ass}

    public static Dictionary<Inclinations, string> descriptionInclination = new Dictionary<Inclinations, string>()
    {
        {Inclinations.Agility, "Отображают способность персонажа повышать Ловкость, а также связанные с ней умения и таланты." },
        {Inclinations.Ballistic, "Отображают способность персонажа повышать Навык стрельбы, а также связанные с ней умения и таланты. " },
        {Inclinations.Defense, "Аколиты с этой склонностью быстро учатся выживать среди смертельного хаоса сражения. Являются ли они искусными обороняющимися или упрямыми крепышами, они выживают на полях сражений и в полных насилия подульях 41-ого тысячелетия, вымощенных костями более слабых. " },
        {Inclinations.Fellowship, "Отображают способность персонажа повышать Общительность, а также связанные с ней умения и таланты. " },
        {Inclinations.Fieldcraft, "Выжить на суровых просторах Империума порой не менее сложно чем в настоящем сражении. Аколиты со склонностью Полевое легко приспосабливаются и преуспевают в мириаде ситуаций, от душных джунглей, до унылых пустынь. " },
        {Inclinations.Finesse, "Умения и таланты со склонностью Изящество полагаются на безошибочное мастерство и тщательное планирование. Аколиты со склонностью Изящество могут стать экспертами в стрельбе на дальние дистанции или использовании экзотического оружия." },
        {Inclinations.General, "Общее" },
        {Inclinations.Intelligence, "Отображают способность персонажа повышать Интеллект, а также связанные с ней умения и таланты. " },
        {Inclinations.Knowledge, "Бесчисленные миры и колоссальные организации Империума накопили больше информации, чем возможно познать за миллион жизней. В то время как большинство подданных Императора остаются в неведении относительно великих и загадочных путей Империума, персонажи со склонностью Познание могут сравнительно легко получить доступ к информации." },
        {Inclinations.Leadership, "В Империуме живут несметные миллиарды людей, но без руководства они не более сильны, чем блеющие овцы или непослушные дети. Эффективное командование бесценно для защиты Человечества, и аколиты с этой склонностью способны превратить трясущихся от страха гражданских в мстительную армию готовую штурмовать еретическое капище или защищаться от ксеносов-налётчиков." },
        {Inclinations.Offense, "Персонажи с этой склонностью предпочитают использовать грубую силу вместо более тщательного, стратегического подхода. Эти аколиты часто бросаются в рукопашную охваченные безудержной яростью или разрывают врага превосходящей огневой мощью." },
        {Inclinations.Perception, "Отображают способность персонажа повышать Восприятие, а также связанные с ней умения и таланты. " },
        {Inclinations.Psyker, "Склонность Псайкер могут получить лишь обладающие редкой способностью владеть психическими силами. Также она указывает на способность ощущать сверхъестественные энергии, сигнализирующие о присутствии обитателей Варпа или использовании психических сил. " },
        {Inclinations.Social, "Обмен словами может быть не менее опасным, чем перестрелка, особенно для незнакомых с правилами и законами словесной войны. С этой склонностью легко выучить, как наилучшим образом использовать медоточивые речи и жёсткое запугивание для продуктивного общения с самонадеянными священниками, свободолюбивыми вольными торговцами и иными персонажами. " },
        {Inclinations.Strength, "Отображают способность персонажа повышать Силу, а также связанные с ней умения и таланты. " },
        {Inclinations.Tech, "Лишь немногие осмеливаются вмешиваться в работу мистических артефактов Тёмной Эры Технологий, и ещё меньше людей преуспевают в этом. Персонажи со склонностью Техно неспособны понять принципы работы машин, но легко общаются с их духами и способны получить результат там, где другие найдут лишь неудачу." },
        {Inclinations.Toughness, "Отображают способность персонажа повышать Выносливость, а также связанные с ней умения и таланты. " },
        {Inclinations.Weapon, "Отображают способность персонажа повышать Навык рукопашной, а также связанные с ней умения и таланты. " },
        {Inclinations.Willpower, "Отображают способность персонажа повышать Силу Воли, а также связанные с ней умения и таланты. " }
    };

    public static string ReadText(string nameFile)
    {
        string txt;
        using (StreamReader _sw = new StreamReader(nameFile, Encoding.Default))
        {
            txt = (_sw.ReadToEnd());
            _sw.Close();
        }
        return txt;
    }
}
