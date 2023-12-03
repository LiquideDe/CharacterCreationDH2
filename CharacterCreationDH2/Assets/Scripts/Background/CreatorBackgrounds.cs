using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorBackgrounds
{
    private List<Background> backgrounds = new List<Background>();
    private int id;

    public CreatorBackgrounds(CreatorEquipment equipment)
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
                new Knowledge(GameStat.KnowledgeName.TacticImperialis, GameStat.SkillName.ScholasticLore, 1)                
                }
            },
            new List<List<string>>() {
            new List<string>(){ "Выучка с Оружием Лазерное", "Выучка с Оружием Твёрдотельное" }
            },
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Лазпистолет"), equipment.GetEquipment("Авто-стаб") },
            new List<Equipment>(){ equipment.GetEquipment("Имперские мантии") },
            new List<Equipment>(){ equipment.GetEquipment("Автоперо") },
            new List<Equipment>(){ equipment.GetEquipment("Хроно") },
            new List<Equipment>(){ equipment.GetEquipment("Инфопланшет") },
            new List<Equipment>(){ equipment.GetEquipment("Медпакет") }
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Дробовик"), equipment.GetEquipment("Шоковая булава") },
            new List<Equipment>(){ equipment.GetEquipment("Лёгкий панцирь силовика"), equipment.GetEquipment("Панцирный нагрудник") },
            new List<Equipment>(){ equipment.GetEquipment("Три дозы стимма") },
            new List<Equipment>(){ equipment.GetEquipment("наручники") },
            new List<Equipment>(){ equipment.GetEquipment("12 палочек лхо") }
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Лазпистолет")},
            new List<Equipment>(){ equipment.GetEquipment("Посох"), equipment.GetEquipment("Кнут") },
            new List<Equipment>(){ equipment.GetEquipment("Лёгкий флак-плащ"), equipment.GetEquipment("Флак-жилет") },
            new List<Equipment>(){ equipment.GetEquipment("Микро-наушник"), equipment.GetEquipment("Пси-фокус") }
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Лазпистолет")},
            new List<Equipment>(){ equipment.GetEquipment("Автоган"), equipment.GetEquipment("Ручная пушка") },
            new List<Equipment>(){ equipment.GetEquipment("Монозадачный серво-череп"), equipment.GetEquipment("Оптический механодендрит") },
            new List<Equipment>(){ equipment.GetEquipment("Имперские мантии") },
            new List<Equipment>(){ equipment.GetEquipment("Два фиала священной смазки") },
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Ручной огнемёт"), equipment.GetEquipment("Боевой молот и стаб-револьвер")},
            new List<Equipment>(){ equipment.GetEquipment("Имперские мантии"), equipment.GetEquipment("флак-жилет") },
            new List<Equipment>(){ equipment.GetEquipment("рюкзак")},
            new List<Equipment>(){ equipment.GetEquipment("Свето-шар") },
            new List<Equipment>(){ equipment.GetEquipment("Монозадачный серво-череп") },
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Лазган"), equipment.GetEquipment("Лазпистолет и меч")},
            new List<Equipment>(){ equipment.GetEquipment("Разгрузочный жилет") },
            new List<Equipment>(){ equipment.GetEquipment("Флак-броня Астра Милитарум")},
            new List<Equipment>(){ equipment.GetEquipment("Тросомёт") },
            new List<Equipment>(){ equipment.GetEquipment("12 палочек лхо") },
            new List<Equipment>(){ equipment.GetEquipment("Магнокуляры") }
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Автопистолет"), equipment.GetEquipment("Лазпистолет")},
            new List<Equipment>(){ equipment.GetEquipment("Цепной меч") },
            new List<Equipment>(){ equipment.GetEquipment("Бронированный комбинезон"), equipment.GetEquipment("Флак-жилет")},
            new List<Equipment>(){ equipment.GetEquipment("Инъектор") },
            new List<Equipment>(){ equipment.GetEquipment("Две дозы обскуры"), equipment.GetEquipment("Две дозы забоя") }
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Ручной огнемёт"), equipment.GetEquipment("Лазпистолет")},
            new List<Equipment>(){ equipment.GetEquipment("Цепной меч") },
            new List<Equipment>(){ equipment.GetEquipment("Хроно")},
            new List<Equipment>(){ equipment.GetEquipment("Инфопланшет") },
            new List<Equipment>(){ equipment.GetEquipment("Микро-наушник") },
            new List<Equipment>(){ equipment.GetEquipment("Лампа") },
            new List<Equipment>(){ equipment.GetEquipment("Флак-жилет") }
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Дробовик"), equipment.GetEquipment("Боевой молот и стаб-револьвер") },
            new List<Equipment>(){ equipment.GetEquipment("Тросомёт") },
            new List<Equipment>(){ equipment.GetEquipment("Флак-жилет") },
            new List<Equipment>(){ equipment.GetEquipment("Две дозы стима") },
            new List<Equipment>(){ equipment.GetEquipment("Тяжёлая кожаная броня") }
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Автопистолет"), equipment.GetEquipment("Стаб-револьвер")},
            new List<Equipment>(){ equipment.GetEquipment("Дробовик") },
            new List<Equipment>(){ equipment.GetEquipment("Цепной клинок")},
            new List<Equipment>(){ equipment.GetEquipment("Имперские мантии") },
            new List<Equipment>(){ equipment.GetEquipment("Три дозы обскуры"), equipment.GetEquipment("Три дозы транка") },
            new List<Equipment>(){ equipment.GetEquipment("Маскировочный набор"), equipment.GetEquipment("Набор истязателя") },
            new List<Equipment>(){ equipment.GetEquipment("Противогаз") },
            new List<Equipment>(){ equipment.GetEquipment("Лампа"), equipment.GetEquipment("Свето-шар") },
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Стаб-револьвер с двумя дополнительными магазинами экспансивных пуль"), 
                equipment.GetEquipment("Стаб-револьвер с двумя дополнительными магазинами бронебойных пуль")},
            new List<Equipment>(){ equipment.GetEquipment("Сетевая граната") },
            new List<Equipment>(){ equipment.GetEquipment("Комби-инструмент")},
            new List<Equipment>(){ equipment.GetEquipment("Флак-плащ") },
            new List<Equipment>(){ equipment.GetEquipment("Фильтры-затычки")},
            new List<Equipment>(){ equipment.GetEquipment("Лампа"), equipment.GetEquipment("Свето-шар") },
            new List<Equipment>(){ equipment.GetEquipment("Инфопланшет") }
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Лазпистолет"), equipment.GetEquipment("Автопистолет (с мод. Компактное)") },
            new List<Equipment>(){ equipment.GetEquipment("Шоковая булава") },
            new List<Equipment>(){ equipment.GetEquipment("Ячеистый плащ"), equipment.GetEquipment("Панцирный нагрудник")},
            new List<Equipment>(){ equipment.GetEquipment("Ауспекс") },
            new List<Equipment>(){ equipment.GetEquipment("Хроно") }
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
            new List<List<Equipment>>() {
            new List<Equipment>(){ equipment.GetEquipment("Дробовик"), equipment.GetEquipment("Ручная пушка")},
            new List<Equipment>(){ equipment.GetEquipment("Цепной меч"), equipment.GetEquipment("Шоковый хлыст") },
            new List<Equipment>(){ equipment.GetEquipment("Флак-плащ")},
            new List<Equipment>(){ equipment.GetEquipment("Респиратор") },
            new List<Equipment>(){ equipment.GetEquipment("Микро-наушник") }
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
