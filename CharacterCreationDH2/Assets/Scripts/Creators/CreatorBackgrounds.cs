using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorBackgrounds
{
    private List<Background> backgrounds = new List<Background>();

    public CreatorBackgrounds()
    {
        backgrounds.Add(new Background(GameStat.BackgroundName.Administratum,
            new List<List<Skill>>() { 
                new List<Skill>() { new Skill( GameStat.SkillName.Commerce,1), new Skill(GameStat.SkillName.Medicae,1) },
                new List<Skill>(){new Knowledge( GameStat.KnowledgeName.Administratum, GameStat.SkillName.CommonLore, 1) },
                new List<Skill>(){new Knowledge(GameStat.KnowledgeName.HighGhotic, GameStat.SkillName.Linquistics, 1) },
                new List<Skill>(){new Skill( GameStat.SkillName.Logic,1)},
                new List<Skill>(){ new Knowledge(GameStat.KnowledgeName.Astromancy, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Beasts, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Burocracy, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Chemistry, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Cryptology, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Geraldica, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.ImperialPatents, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Justice, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Legends, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Numerology, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Occultism, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.Phylosophy, GameStat.SkillName.ScholasticLore, 1),
                new Knowledge(GameStat.KnowledgeName.TacticImperialis, GameStat.SkillName.ScholasticLore, 1),
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Лазерное", "Выучка с Оружием Твёрдотельное" }
            },
            new List<List<string>>() {
            new List<string>(){ "Лазпистолет", "авто-стаб" },
            new List<string>(){ "имперские мантии" },
            new List<string>(){ "автоперо" },
            new List<string>(){ "хроно" },
            new List<string>(){ "инфопланшет" },
            new List<string>(){ "медпакет" }
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Knowledge, GameStat.Inclinations.Fellowship
            },
            "Мастер Бумажной Работы : Персонаж из Адептус Администратум считает Доступность предметов на один уровень ниже (Очень Редкие становятся Редкими, Среднее становится Обычным и т.д.). "));

        backgrounds.Add(new Background(GameStat.BackgroundName.Arbitres,
            new List<List<Skill>>() {
                new List<Skill>() { 
                    new Skill( GameStat.SkillName.Awareness,1)},
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Arbitres, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Criminal, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Inquiry, 1), new Skill( GameStat.SkillName.Interrogation,1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Intimidate, 1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Scrutiny, 1)
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Шоковое", "Выучка с Оружием Твёрдотельное" }
            },
            new List<List<string>>() {
            new List<string>(){ "Дробовик", "Шоковая булава" },
            new List<string>(){ "Лёгкий панцирь силовика", "панцирный нагрудник" },
            new List<string>(){ "3 дозы стимма" },
            new List<string>(){ "наручники" },
            new List<string>(){ "12 палочек лхо" }
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Offense, GameStat.Inclinations.Defense
            },
            "Воплощение Закона: Арбитр может перебросить проверку Запугивания или Допроса, а также заменить полученные степени успеха своим бонусом Силы Воли. "));

        backgrounds.Add(new Background(GameStat.BackgroundName.AstraTelepatica,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Awareness,1)},
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.AstraTelepatica, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Deceive, 1), new Skill( GameStat.SkillName.Interrogation,1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Warp, GameStat.SkillName.ForbiddenLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Psyniscience, 1), new Skill( GameStat.SkillName.Scrutiny,1)
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Лазерное", "Выучка с Оружием Низкотехнологичное" },
            new List<string>(){"Псайкер" }
            },
            new List<List<string>>() {
            new List<string>(){ "Лазпистолет"},
            new List<string>(){ "посох", "кнут" },
            new List<string>(){ "лёгкий флак-плащ", "флак-жилет" },
            new List<string>(){ "микро-наушник", "пси-фокус" }
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Psyker, GameStat.Inclinations.Defense
            },
            "Постоянная Угроза : Когда персонаж, или союзник на расстоянии 10 метров, совершает бросок по таблице 6-2: Психические феномены (см. стр. 242) персонаж из Адептус Астра Телепатика " +
            "может уменьшить или увеличить результат на размер своего бонуса Силы Воли. Проверен Террой : Если персонаж получает элитное улучшение Псайкер во время создания персонажа, " +
            "он также получает черту Санкционированный (см. стр. 161). "));

        backgrounds.Add(new Background(GameStat.BackgroundName.Mechanicus,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Awareness,1),
                    new Skill( GameStat.SkillName.OperateAero,1),
                    new Skill( GameStat.SkillName.OperateSurf,1),
                    new Skill( GameStat.SkillName.OperateVoidship,1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Mechanicus, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Logic, 1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Security, 1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.TechUse, 1)
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Твёрдотельное" },
            new List<string>(){ "Использование Механодендритов Вспомогательные" }
            },
            new List<List<string>>() {
            new List<string>(){ "Лазпистолет"},
            new List<string>(){ "Автоган", "ручная пушка" },
            new List<string>(){ "монозадачный серво-череп", "оптический механодендрит" },
            new List<string>(){ "имперские мантии" },
            new List<string>(){ "два фиала священной смазки" },
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Knowledge, GameStat.Inclinations.Tech
            },
            "Замена Слабой Плоти : Персонаж из Адептус Механикус считает Доступность всей кибернетики на два уровня ниже (Редкая становится Средней, Очень Редкая становится Дефицитом и т.д.). ",
            new MechImplants("Имплантаты Механикус")));

        backgrounds.Add(new Background(GameStat.BackgroundName.Ministorum,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Charm,1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Ministorum, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Command, 1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Inquiry, 1),
                    new Skill( GameStat.SkillName.Scrutiny, 1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.HighGhotic, GameStat.SkillName.Linquistics,1 )
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Зажигательное", "Выучка с Оружием Твёрдотельное" }
            },
            new List<List<string>>() {
            new List<string>(){ "Ручной огнемёт", "боевой молот и стаб-револьвер"},
            new List<string>(){ "имперские мантии ", "флак-жилет" },
            new List<string>(){ "рюкзак"},
            new List<string>(){ "свето-шар" },
            new List<string>(){ "монозадачный серво-череп (громкоговоритель)" },
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Knowledge, GameStat.Inclinations.Tech
            },
            "Вера есть Всё: При трате очка Судьбы на получение бонуса +10 к любой проверке, персонаж из Адептус Министорум вместо этого получает бонус +20. "));

        backgrounds.Add(new Background(GameStat.BackgroundName.Militarum,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Athletics,1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.AstraMilitarum, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Command, 1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Medicae, 1),
                    new Skill( GameStat.SkillName.OperateSurf, 1)
                },
                new List<Skill>()
                {
                     new Skill( GameStat.SkillName.NavigateSurface, 1)
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Лазерное" },
            new List<string>(){ "Выучка с Оружием Низкотехнологичное" }
            },
            new List<List<string>>() {
            new List<string>(){ "Лазган", "лазпистолет и меч"},
            new List<string>(){ "разгрузочный жилет" },
            new List<string>(){ "флак-броня Астра Милитарум"},
            new List<string>(){ "кошка и трос" },
            new List<string>(){ "12 палочек лхо" },
            new List<string>(){ "магнокуляры" }
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Fieldcraft, GameStat.Inclinations.Leadership
            },
            "Молот Императора: при атаке гвардейцем цели, которую в прошлом ходу атаковал союзник, гвардеец может перебрасывать любые результаты 1 и 2 на броске урона. "));

        backgrounds.Add(new Background(GameStat.BackgroundName.Izgoi,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Acrobatics,1),
                    new Skill( GameStat.SkillName.SleightOfHand,1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Criminal, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Deceive, 1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Dodge, 1),
                },
                new List<Skill>()
                {
                     new Skill( GameStat.SkillName.Stealth, 1)
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Лазерное", "Выучка с Оружием Твёрдотельное" },
            new List<string>(){ "Выучка с Оружием Цепное" }
            },
            new List<List<string>>() {
            new List<string>(){ "Автопистолет", "лазпистолет"},
            new List<string>(){ "цепной меч" },
            new List<string>(){ "бронированный комбинезон", "флак-жилет"},
            new List<string>(){ "инъектор" },
            new List<string>(){ "две дозы обскуры", "две дозы забоя" }
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Fieldcraft, GameStat.Inclinations.Social
            },
            "Некогда Отдыхать: При определении Усталости персонаж-Изгой считает свой бонус Выносливости в два раза большим. "));

        backgrounds.Add(new Background(GameStat.BackgroundName.Sororitas,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Athletics,1)
                },
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Charm,1),
                    new Skill( GameStat.SkillName.Intimidate,1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Sororitas, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.HighGhotic, GameStat.SkillName.Linquistics,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Medicae, 1),
                    new Skill( GameStat.SkillName.Parry, 1)
                }
                
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Лазерное", "Выучка с Оружием Зажигательное" },
            new List<string>(){ "Выучка с Оружием Цепное" },
            new List<string>(){ "Сороритас" }
            },
            new List<List<string>>() {
            new List<string>(){ "Ручной огнемёт", "лазпистолет"},
            new List<string>(){ "цепной меч" },
            new List<string>(){ "хроно"},
            new List<string>(){ "инфопланшет" },
            new List<string>(){ "вокс бусина" },
            new List<string>(){ "фонарик" },
            new List<string>(){ "бронежилет" }
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Offense, GameStat.Inclinations.Social
            },
            "Несокрушимая Преданность: Всякий раз, когда персонаж из Адептус Сороритас получает 1 или больше очков Порчи, она получает вместо этого столько же (но минус 1) очков Безумия. "));

        backgrounds.Add(new Background(GameStat.BackgroundName.Mutant,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Athletics,1),
                    new Skill( GameStat.SkillName.Acrobatics,1)
                },
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Awareness,1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Deceive, 1),
                    new Skill( GameStat.SkillName.Intimidate, 1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Mutant, GameStat.SkillName.ForbiddenLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Survival, 1)
                }

            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Низкотехнологичное"},
            new List<string>(){ "Выучка с Оружием Твёрдотельное" },
            new List<string>(){ "Амбидекстер", "Сонар","Ночное зрение","Природное оружие", "Коренастый", "Токсичный (1)", "Сверхъестественная Сила", "Выносливость", "Ловкость" }
            },
            new List<List<string>>() {
            new List<string>(){ "Дробовик", "стаб револьвер и двуручное оружие"},
            new List<string>(){ "тросомёт" },
            new List<string>(){ "боевой жилет"},
            new List<string>(){ "2 дозы стима" },
            new List<string>(){ "тяжёлая кожаная броня" }
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Offense, GameStat.Inclinations.Fieldcraft
            },
            "Изменчивая плоть: Персонаж-Мутант всегда может по собственному желанию провалить любую проверку, связанную с сопротивлением рудиментам или мутациям. " +
            "Всякий раз, когда он получает рудимент, он может сделать бросок по Таблице 8-16: Мутации для получения мутации взамен рудимента. " +
            "Персонаж Мутант начинает игру с 10 очками Порчи. Вместо обычного броска на мутации и рудименты он делает бросок 5к10 по Таблице 8-16: Мутации (стр 356 в ОКП Dark Heresy) " +
            "для определения стартовых мутация для его персонажа. "));

        backgrounds.Add(new Background(GameStat.BackgroundName.Vichishennii,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Dodge,1)
                },
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Awareness,1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Deceive, 1),
                    new Skill( GameStat.SkillName.Inquiry, 1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Demonology, GameStat.SkillName.ForbiddenLore,1 )
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Ненависть (Демоны)"},
            new List<string>(){ "Выучка с Оружием Твёрдотельное" },
            new List<string>(){ "Выучка с Оружием Цепное" }
            },
            new List<List<string>>() {
            new List<string>(){ "Автопистолет ", "стаб револьвер"},
            new List<string>(){ "дробовик" },
            new List<string>(){ "цепное лезвие"},
            new List<string>(){ "имперские мантии" },
            new List<string>(){ "3 дозы обскуры", "3 дозы транка" },
            new List<string>(){ "маскировочный набор", "набор истязателя" },
            new List<string>(){ "противогаз" },
            new List<string>(){ "лампа", "светошар" },
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Defense, GameStat.Inclinations.Knowledge
            },
            "Все Вычищенные персонажи начинают с одним рудиментом выбранным из таблицы 8 - 15: Рудименты (смотрите страницу 355 ОКП Dark Heresy)." +
            "Затронутый Демоном: При прохождении проверок на Страх Вычищенный персонаж считает свой бонус Безумия на 2 выше (смотрите страницу 353 ОКП Dark Heresy). " +
            "Дополнительно, он никогда больше не будет одержим тем же самым демоном, который когда-то им завладевал. "));

        backgrounds.Add(new Background(GameStat.BackgroundName.Heretech,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.TechUse,1)
                },
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Awareness,1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Deceive, 1),
                    new Skill( GameStat.SkillName.Inquiry, 1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.Demonology, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.Arheotech, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.AstartesOfChaos, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.CriminalForb, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.Demonology, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.Heresy, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.HorusHeresyAndLongWar, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.Inquisition, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.Mutant, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.OficioAssasinorum, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.Pirates, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.Psykers, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.Warp, GameStat.SkillName.ForbiddenLore,1 ),
                    new Knowledge( GameStat.KnowledgeName.Xenos, GameStat.SkillName.ForbiddenLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Medicae, 1),
                    new Skill( GameStat.SkillName.Security, 1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.AustroGraphTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.AgroTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.ArcheologyTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.ChymicTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.CockTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.CryptoTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.EpistolTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.ExploratorTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.GeologyTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.GunsmithTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.IpolnitelTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.KorabelTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.LingvistTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.MortikatorTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.PredskazatelTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.PustoplavatelTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.RezchikTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.SculptureTr, GameStat.SkillName.Trade,1 ),
                    new Knowledge( GameStat.KnowledgeName.TechnomantTr, GameStat.SkillName.Trade,1 ),
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Твёрдотельное" }
            },
            new List<List<string>>() {
            new List<string>(){ "Стаб-револьвер с двумя дополнительными магазинами экспансивных пуль", "Стаб-револьвер с двумя дополнительными магазинами бронебойных пуль"},
            new List<string>(){ "одна сетевая граната" },
            new List<string>(){ "комби-инструмент"},
            new List<string>(){ "флак-плащ" },
            new List<string>(){ "фильтры-затычки"},
            new List<string>(){ "светошар/лампа"},
            new List<string>(){ "инфопланшет" }
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Finesse, GameStat.Inclinations.Tech
            },
            "Мастер сокрытых знаний: Когда Еретех совершает проверку Техпользования, чтобы понять, использовать, отремонтировать или модифицировать незнакомое устройство, " +
            "он получает бонус +20, если у него есть одна или несколько соответствующих специализаций умения Запретные Знания на уровне 1 (знает) или выше. ",
            new MechImplants("Импланты Механикус")));

        backgrounds.Add(new Background(GameStat.BackgroundName.RougeTraderFleet,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Charm,1),
                    new Skill( GameStat.SkillName.Scrutiny,1)
                },
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Commerce,1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.RougeTrader, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.EldariLingva, GameStat.SkillName.Linquistics,1 ),
                    new Knowledge( GameStat.KnowledgeName.OrcsLingva, GameStat.SkillName.Linquistics,1 ),
                    new Knowledge( GameStat.KnowledgeName.NecrontirLingva, GameStat.SkillName.Linquistics,1 ),
                    new Knowledge( GameStat.KnowledgeName.TauLingva, GameStat.SkillName.Linquistics,1 ),
                    new Knowledge( GameStat.KnowledgeName.MarkOfXenos, GameStat.SkillName.Linquistics,1 ),
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.OperateAero, 1),
                    new Skill( GameStat.SkillName.OperateSurf, 1)
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Твёрдотельное", "Выучка с Оружием Лазерное" },
            new List<string>(){ "Выучка с Оружием Шоковое" }
            },
            new List<List<string>>() {
            new List<string>(){ "Лазпистолет", "автопистолет (с модификацией Компактное)" },
            new List<string>(){ "шоковая булава" },
            new List<string>(){ "ячеистый плащ", "панцирный нагрудник"},
            new List<string>(){ "ауспекс" },
            new List<string>(){ "хроно" }
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Finesse, GameStat.Inclinations.Social
            },
            "Привыкший к ксеносам: Персонаж из флотилии вольного торговца получает +10 бонус к вызванным чужаками проверкам Страха, " +
            "и +20 бонус к проверкам умений Взаимодействия с персонажами- чужаками.  "));

        backgrounds.Add(new Background(GameStat.BackgroundName.ImperialFleet,
            new List<List<Skill>>() {
                new List<Skill>() {
                    new Skill( GameStat.SkillName.NavigateStellar,1)
                },
                new List<Skill>() {
                    new Skill( GameStat.SkillName.Athletics,1)
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.Command, 1),
                    new Skill( GameStat.SkillName.Intimidate, 1)
                },
                new List<Skill>()
                {
                    new Knowledge( GameStat.KnowledgeName.ImperialFleet, GameStat.SkillName.CommonLore,1 )
                },
                new List<Skill>()
                {
                    new Skill( GameStat.SkillName.OperateAero, 1),
                    new Skill( GameStat.SkillName.OperateVoidship, 1)
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Твёрдотельное" },
            new List<string>(){ "Выучка с Оружием Цепное", "Выучка с Оружием Шоковое" }
            },
            new List<List<string>>() {
            new List<string>(){ "Дробовик", "ручная пушка"},
            new List<string>(){ "цепной меч", "шоковый хлыст" },
            new List<string>(){ "флак-плащ"},
            new List<string>(){ "респиратор" },
            new List<string>(){ "микро-бусина"}
            },
            new List<GameStat.Inclinations>() {
            GameStat.Inclinations.Offense, GameStat.Inclinations.Tech
            },
            "Тренировка ближнего боя: Персонаж Имперского флота получает ещё одну степень успеха на успешных проверках Навыка Стрельбы, " +
            "которые он делает против целей В Упор, на Ближней Дистанции или в Ближнем Бою. "));
    }
}
