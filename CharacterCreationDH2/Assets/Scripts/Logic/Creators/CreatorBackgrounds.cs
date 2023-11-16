using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorBackgrounds
{
    private List<Background> backgrounds = new List<Background>();
    private int id;

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
            }));

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
            }));

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
            }));

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
            }));

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
            }));

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
            }));

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
            }));

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
            }));

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
            }));

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
            }, new MechImplants("Импланты Механикус")));

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
            }));

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
            }));
    }

    public Background GetNextBack()
    {
        if (id + 1 < backgrounds.Count)
        {
            id += 1;
        }
        else
        {
            id = 0;
        }
        return backgrounds[id];
    }

    public Background GetPrevBack()
    {
        if (id - 1 < 0)
        {
            id = backgrounds.Count - 1;
        }
        else
        {
            id -= 1;
        }
        return backgrounds[id];
    }
}
