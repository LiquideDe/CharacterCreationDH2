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
                "����������","��������"
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
                "�������","������������� �����", "������������� �����", "������������� �������", "������������� ����������� ����", "������������� ��������",
                "������������� ������"
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
                "������ �����������","��������� ������"
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
                "������ � �����","���������"
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
                "������������� ����������� ����","����-�������","�������"
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
                "������������","�������� � ������"
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
                "������ ��������","�����������"
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
                "�������� �������","������� �����������"
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
                "����������","������ �����������"
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
                "������� ������","���������"
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
                "�������������","������ �����������"
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
                "������� ������","��������� �����"
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
