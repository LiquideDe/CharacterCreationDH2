using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorRole 
{
    private List<Role> roles = new List<Role>();

    public CreatorRole()
    {
        roles.Add(new Role( GameStat.RoleName.Assasin,
            "��������� �������� : � ���������� � ������� �������������� ����� ������ (��. ���. 357) ����� ������� ������� �������� ������ �� ����� ��������� ���� ������ " +
            "�� ��������� ������ ���������� ��������������� ����� ������� ���������� �������� ������ �������� �����. ",
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

        roles.Add(new Role(GameStat.RoleName.Herurgion,
            "��������� �������� : � ���������� � ������� �������������� ����� ������ (��. ���. 357) ����� ��������-��������� ����������� �������� ������ ������, " +
            "�� ����� ��������� ���� ������ ����� �������� ��������������� ������; ������� ������ ���� ��������� ����� ������ ���������� ����������. ",
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
            "���� � �������: ������� �� �����, ����� ���������� �������� ��������, ��������-��������� ����� ��������� ���� ����������� ����� � ��������� � ���� ������� ���� �������� ��� ��������� ��������.  ",
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
            "������ ��� ������� : � ���������� � ������� �������������� ����� ������ " +
            "(��. ���. 357) �������� �������� ����� ��������� ���� ������ �� " +
            "�������������� ����� �������� ������ �������, ������������ ��� �����������, " +
            "������� ������ ����� ������ ���� ���� ���������. ",
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
            "��������� � ���� : ��������-������ �������� ���� � ������� ���������� " +
            "������� (��. ���. 108). ����������, ����� ���� ���� ��������� " +
            "���� �� ����� 35 ",
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
            "����� ������ : � ���������� � ������� �������������� ����� ������ " +
            "(��. ���. 357) ��������-������ ����� ��������� ���� ������ " +
            "�� �������������� ����� �������� ������ ������ ��� ������ ������, " +
            "������� ������ ����� ������ ���������� �������. ",
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
            "����� �� ��������� �� ���� : � ���������� � ������� �������������� ����� " +
            "������ (��. ���. 357) ��������-�������� ����� ��������� ���� ������ " +
            "�� �������������� ����� �������� ������ ������������ ��� ��������, " +
            "������� ������ ����� ������ ���������� ��������. ",
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
            "������� ������� : � ���������� � ������� �������������� ����� ������ " +
            "(��. ���. 357), ����� ��������� ����������� �������� �����, " +
            "�� �� ����������� ����� ���������, ��������-������� ����� ��������� " +
            "���� ������ �� ������ ���������� �������� ������ �������� �� ���� ����� " +
            "������ �������� (��� ���������� �����) ��� ������ ���������� (��� ���������� �����). ",
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
            "������ ���� �����������!: � ���������� � ������� �������� ������������� " +
            "����� ������ (��. ���. 357 ��� Dark Heresy), ��������-������� ����� " +
            "��������� ���� ������ � �������� ������ ��������� ������ ������ ��������� " +
            "����� �� ����� ������������. ���� �� ����� �������� ����� ������ " +
            "������������ ����� � ���� ������������, �� ������� 1 ���� �������. ",
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
            "��������� ����: ������ ���, ����� �������� �������� 1 ��� ������ ����� " +
            "����� (����� ��������� ������ ������������ � �����), �� �������� ����� +10 " +
            "� ������ ��������, ������� �� ������� �� ����� ������ ���������� ����. ",
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
            "������� �������: � ���������� � �������� ������������� ����� ������ " +
            "(������ �������� 357 ��� Dark Heresy), ��������-����������� ����� ����� " +
            "��������� ���� ������ ����� ������������� ������ �������� �� ����� � " +
            "����������� ������� ������ ��� ������ ���� ����. " +
            "� ����������, ����� �� ������� ���� ���������� ������ �� ���� � ������ " +
            "����� (�), �� ������� � ��������������� ����� � ������� ��� ������������� " +
            "��� ������ �� � ����. ",
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
            "��������: � ���������� � ����������� ������������� ����� ������ " +
            "(��. �������� 357 ��� �Dark Heresy�) ��������-�� ����� ��������� ���� " +
            "������ � ������������� ������ �������� ������ ������������� ��� ���������, " +
            "���������� � ������������� ���������� ��� ������ ���������, " +
            "� ����������� �������� ������, ������ ��� ������ ��������. ",
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
}
