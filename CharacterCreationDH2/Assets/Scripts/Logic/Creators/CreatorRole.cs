using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorRole 
{
    private List<Role> roles = new List<Role>();
    int id;
    public CreatorRole()
    {
        roles.Add(new Role( GameStat.RoleName.Assasin,
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

        roles.Add(new Role(GameStat.RoleName.Hirurgion,
            
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

    public Role GetNextRole()
    {
        if (id + 1 < roles.Count)
        {
            id += 1;
        }
        else
        {
            id = 0;
        }
        return roles[id];
    }

    public Role GetPrevRole()
    {
        if (id - 1 < 0)
        {
            id = roles.Count - 1;
        }
        else
        {
            id -= 1;
        }
        return roles[id];
    }
}
