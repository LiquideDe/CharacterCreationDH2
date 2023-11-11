using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorRole 
{
    private List<Role> roles = new List<Role>();

    public CreatorRole()
    {
        roles.Add(new Role( GameStat.RoleName.Assasin,
            "Уверенное Убийство : В дополнение к обычным использованиям очков Судьбы (см. стр. 357) когда Ассасин успешно попадает атакой он может потратить очко Судьбы " +
            "на нанесение первым попаданием дополнительного урона равного количеству степеней успеха проверки атаки. ",
            new List<List<GameStat.Inclinations>>() 
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Agility
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Weapon, GameStat.Inclinations.Ballistic
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Fieldcraft
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Finesse
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Perception
                }
            },
            new List<string>() 
            {
                "Искушённый","Вскочить"
            }));

        roles.Add(new Role(GameStat.RoleName.Herurgion,
            "Преданный Целитель : В дополнение к обычным использованиям очков Судьбы (см. стр. 357) когда персонаж-Хирургеон проваливает проверку Первой Помощи, " +
            "он может потратить очко Судьбы чтобы добиться автоматического успеха; степени успеха этой «проверки» равны бонусу Интеллекта Хирургеона. ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Fieldcraft
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Intelligence
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Knowledge
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Strength
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Toughness
                }
            },
            new List<string>()
            {
                "Нокдаун","Сопротивление Холод", "Сопротивление Страх", "Сопротивление Токсины", "Сопротивление Психические Силы", "Сопротивление Радиация",
                "Сопротивление Вакуум"
            }));

        roles.Add(new Role(GameStat.RoleName.Desperado,
            "Беги и Стреляй: Однажды за раунд, после совершения действия Движения, персонаж-Десперадо может выполнить одну Стандартную Атаку с имеющимся у него оружием типа Пистолет как Свободное действие.  ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Agility
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Ballistic
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Defense
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Fellowship
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Finesse
                }
            },
            new List<string>()
            {
                "Мягкое Приземление","Выхватить Оружие"
            }));

        roles.Add(new Role(GameStat.RoleName.Ierofant,
            "Власть над Массами : В дополнение к обычным использованиям очков Судьбы " +
            "(см. стр. 357) персонаж Иерофант может потратить очко Судьбы на " +
            "автоматический успех проверки умения Обаяние, Командование или Запугивание, " +
            "степени успеха равны бонусу Силы Воли Иерофанта. ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Fellowship
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Offense
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Social
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Toughness
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Willpower
                }
            },
            new List<string>()
            {
                "Плечом к Плечу","Ненависть"
            }));

        roles.Add(new Role(GameStat.RoleName.Mistic,
            "Смотрящий в Варп : Персонаж-Мистик начинает игру с элитным улучшением " +
            "Псайкер (см. стр. 108). Желательно, чтобы Сила Воли персонажа " +
            "была не менее 35 ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Defense
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Intelligence
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Knowledge
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Perception
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Willpower
                }
            },
            new List<string>()
            {
                "Сопротивление Психические Силы","Варп-чувство","Псайкер"
            }));

        roles.Add(new Role(GameStat.RoleName.Sage,
            "Жажда Знаний : В дополнение к обычным использованиям очков Судьбы " +
            "(см. стр. 357) персонаж-Мудрец может потратить очко Судьбы " +
            "на автоматический успех проверки умения Логика или умений Знания, " +
            "степени успеха равны бонусу Интеллекта Мудреца. ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Intelligence
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Knowledge
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Perception
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Tech
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Willpower
                }
            },
            new List<string>()
            {
                "Амбидекстрия","Разговор с Толпой"
            }));

        roles.Add(new Role(GameStat.RoleName.Seeker,
            "Ничто не Ускользнёт от Меня : В дополнение к обычным использованиям очков " +
            "Судьбы (см. стр. 357) персонаж-Искатель может потратить очко Судьбы " +
            "на автоматический успех проверки умения Бдительность или Дознание, " +
            "степени успеха равны бонусу Восприятия Искателя. ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Fellowship
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Intelligence
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Perception
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Social
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Tech
                }
            },
            new List<string>()
            {
                "Чуткая Интуиция","Разоружение"
            }));

        roles.Add(new Role(GameStat.RoleName.Warrior,
            "Эксперт Насилия : В дополнение к обычным использованиям очков Судьбы " +
            "(см. стр. 357), после успешного прохождения проверки атаки, " +
            "но до определения места попаданий, персонаж-Воитель может потратить " +
            "очко Судьбы на замену полученных степеней успеха проверки на свой бонус " +
            "Навыка Стрельбы (для стрелковой атаки) или Навыка Рукопашной (для рукопашной атаки). ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Ballistic
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Defense
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Offense
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Strength
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Weapon
                }
            },
            new List<string>()
            {
                "Железная Челюсть","Быстрая Перезарядка"
            }));

        roles.Add(new Role(GameStat.RoleName.Fanatic,
            "Смерть всем несогласным!: В дополнение к обычным способам использования " +
            "очков судьбы (см. стр. 357 ОКП Dark Heresy), персонаж-фанатик может " +
            "потратить очко Судьбы и получить талант Ненависть против своего нынешнего " +
            "врага на время столкновения. Если он решит оставить битву против " +
            "ненавистного врага в этом столкновении, он получит 1 очко безумия. ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Leadership
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Offense
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Toughness
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Willpower
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Weapon
                }
            },
            new List<string>()
            {
                "Искушённый","Отринь Ведьмовство"
            }));

        roles.Add(new Role(GameStat.RoleName.Kaushisa,
            "Очищающая боль: Всякий раз, когда Кающийся получает 1 или больше очков " +
            "урона (после вычитания бонуса Выносливости и брони), он получает бонус +10 " +
            "к первой проверке, которую он сделает до конца своего следующего хода. ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Agility
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Offense
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Toughness
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Intelligence
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Fieldcraft
                }
            },
            new List<string>()
            {
                "Крепкий орешек","Флагелант"
            }));

        roles.Add(new Role(GameStat.RoleName.Crusader,
            "Сокруши Нечисть: В дополнение к обычному использованию очков Судьбы " +
            "(смотри страницу 357 ОКП Dark Heresy), персонаж-крестоносец может также " +
            "потратить очко Судьбы чтобы автоматически пройти проверку на Страх с " +
            "количеством успехов равных его бонусу Силы Воли. " +
            "В дополнение, когда он наносит удар рукопашной атакой по цели с чертой " +
            "Страх (Х), он наносит Х дополнительного урона и считает что пробиваемость " +
            "его оружия на Х выше. ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Knowledge
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Offense
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Strength
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Toughness
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Willpower
                }
            },
            new List<string>()
            {
                "Телохранитель","Отринь Ведьмовство"
            }));

        roles.Add(new Role(GameStat.RoleName.Ass,
            "Идеально: В дополнение к нормальному использованию очков Судьбы " +
            "(см. страницу 357 ОКП «Dark Heresy») персонаж-ас может потратить очко " +
            "Судьбы и автоматически пройти проверку умения Пилотирование или Выживание, " +
            "связанного с транспортными средствами или живыми скакунами, " +
            "с количеством степеней успеха, равным его бонусу Ловкости. ",
            new List<List<GameStat.Inclinations>>()
            {
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Agility
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Finesse
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Perception
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Tech
                },
                new List<GameStat.Inclinations>()
                {
                    GameStat.Inclinations.Willpower
                }
            },
            new List<string>()
            {
                "Трудная мишень","Отчаянный Пилот"
            }));
    }
}
