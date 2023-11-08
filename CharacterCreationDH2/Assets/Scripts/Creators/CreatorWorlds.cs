using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorWorlds
{
    private List<Homeworld> homeworlds = new List<Homeworld>();

    public CreatorWorlds()
    {
        homeworlds.Add(new Homeworld(GameStat.WorldName.WildWorld, GameStat.CharacterName.Strength, GameStat.CharacterName.Toughness, GameStat.CharacterName.Influence, 2,
            "������ ����: � ����� ������� � ������ ���� ����� ������������������ ������ ������ �������� ����������� (���� ����� ���) � �������� �������� �����������(3).", GameStat.Inclinations.Toughness, 9));

        homeworlds.Add(new Homeworld(GameStat.WorldName.ForgeWorld, GameStat.CharacterName.Intelligence, GameStat.CharacterName.Toughness, GameStat.CharacterName.Fellowship, 3,
            "��������� ��������: ������� � ����-������� �������� ���� � �������� �������� ���� ��� ����� ��������.", GameStat.Inclinations.Intelligence, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.HighBorn, GameStat.CharacterName.Fellowship, GameStat.CharacterName.Influence, GameStat.CharacterName.Toughness, 4,
            "���������� ���������: ������ ���, ����� ������� ��������� �����������, ��� ����������� �� 1 ���� ������ ��� ������ ���� �� (�� �������� � 1).", GameStat.Inclinations.Fellowship, 9));

        homeworlds.Add(new Homeworld(GameStat.WorldName.HiveWorld, GameStat.CharacterName.Agility, GameStat.CharacterName.Perception, GameStat.CharacterName.Willpower, 2,
            "������������ ����� � ������������� �����: ��������� � ����-���� ���������� ����� ��� ��������, ������ �� �� �������� ���������. ����� ����, ����� �������� ��������� � �������� ���������, �� �������� ����� +20 � ��������� ��������� (��������).", 
            GameStat.Inclinations.Perception, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.TempleWorld, GameStat.CharacterName.Fellowship, GameStat.CharacterName.Willpower, GameStat.CharacterName.Perception, 3,
            "���� � �����: ������ ��� ����� �������� � ����-����� ������ ���� ������, ����� ������� 1�10. ��� ��������� 1 ����� ���������� ����� ������ ��������� �� �����������.", GameStat.Inclinations.Willpower, 7));

        homeworlds.Add(new Homeworld(GameStat.WorldName.VoidBorn, GameStat.CharacterName.Intelligence, GameStat.CharacterName.Willpower, GameStat.CharacterName.Strength, 3,
            "���� �������: ��������������� �������� �������� ���� � �������� ������������ � � �������� ������� ���������� �������� ����� +30 � ��������� �����������.", GameStat.Inclinations.Intelligence, 7));
        homeworlds[^1].AddTalent("������������");

        homeworlds.Add(new Homeworld(GameStat.WorldName.AgroWorld, GameStat.CharacterName.Strength, GameStat.CharacterName.Agility, GameStat.CharacterName.Fellowship, 2,
            "���� �����: ��������� � ����-����� �������� � ������ �������� ������ (2).", GameStat.Inclinations.Strength, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.FeodalWorld, GameStat.CharacterName.Perception, GameStat.CharacterName.WeaponSkill, GameStat.CharacterName.Intelligence, 3,
            "��� ����� � ����� ����: �������� � ����������� ���� ���������� ����������� �� �������� ��������, ���������� ����� �����, ������� �� �����.", GameStat.Inclinations.Weapon, 9));

        homeworlds.Add(new Homeworld(GameStat.WorldName.FrontWorld, GameStat.CharacterName.Perception, GameStat.CharacterName.BallisticSkill, GameStat.CharacterName.Fellowship, 3,
            "��������� ������ �� ����: ��������� � ������������ ���� �������� ����� +20 � ������ �������������� ����� ������������ ��� ������ � +10 ����� ����� ��������.", GameStat.Inclinations.Ballistic, 7));

        homeworlds.Add(new Homeworld(GameStat.WorldName.DemonWorld, GameStat.CharacterName.Perception, GameStat.CharacterName.Willpower, GameStat.CharacterName.Fellowship, 3,
            "������� �����: �������� � ������������� ���� �������� � ����� ������ � ������ ����������. " +
            "���� �� ������� ��� ������ ����� �� ��������� ����� ��������� ���������, �� ������ �������� ���� �������������� ���� ����� ������. " +
            "������, ��� �� �� ����� �������� ������ ������ � ���� ������, ���� ������ �� �� ������� ���������� �������. ���� �������� ����� �������� � 1�10+5 ����� �����.", 
            GameStat.Inclinations.Willpower, 7));
        homeworlds[^1].AddSkill(GameStat.SkillName.Psyniscience.ToString());

        homeworlds.Add(new Homeworld(GameStat.WorldName.PrisonWorld, GameStat.CharacterName.Toughness, GameStat.CharacterName.Perception, GameStat.CharacterName.Influence, 3,
            "���� �� ������: �� ����-������ �������� ���, ��� ������������ ����� ��� ����� ���� ���������� � ��� ������������ ������. " +
            "�������� � ����-������ �������� � ����� ������� � ������� ����� ������ (������������) � ����������������, � ����� �������� ����� (������������ �������).", GameStat.Inclinations.Toughness, 10));
        homeworlds[^1].AddSkill(GameStat.SkillName.Awareness.ToString());
        homeworlds[^1].AddSkill(GameStat.KnowledgeName.Criminal.ToString());
        homeworlds[^1].AddTalent("����� (������������ �������)");

        homeworlds.Add(new Homeworld(GameStat.WorldName.QuarantineWorld, GameStat.CharacterName.BallisticSkill, GameStat.CharacterName.Intelligence, GameStat.CharacterName.Strength, 3,
            "�������� �� ������: ��, ��� ���������� �������� ����������� ���, ������ ������ ������� �������. " +
            "����� ����������� ������ ������ �����������, ��� ���������� �� ��� ������� ������ (�� ������������ ���������� � 1).", GameStat.Inclinations.Fieldcraft, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.GardenWorld, GameStat.CharacterName.Fellowship, GameStat.CharacterName.Agility, GameStat.CharacterName.Toughness, 2,
            "������������� ������: ��������� � ����-���� ����� (�������� � ������� �������) ��������� ����������������� ������ ���������� " +
            "��� ���������� ������, � ����� ������� ���� ������� �� 50 ����� �����, � �� ������� 100.", GameStat.Inclinations.Fellowship, 7));

        homeworlds.Add(new Homeworld(GameStat.WorldName.ScienseStation, GameStat.CharacterName.Intelligence, GameStat.CharacterName.Perception, GameStat.CharacterName.Fellowship, 3,
            "����� �� �����������: ������ ���, ����� �������� � ����������������� ������� ��������� ������ 2 (������) � ������ ������ ������, �� ����� �������� ������� 1 (�����) " +
            "� ����� �� ��������� ��� ���������� ������������� ������ ��������� ������ �� ������ ������.", GameStat.Inclinations.Knowledge, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.FeodalWorld, GameStat.CharacterName.Perception, GameStat.CharacterName.WeaponSkill, GameStat.CharacterName.Intelligence, 3,
            "��� ����� � ����� ����: �������� � ����������� ���� ���������� ����������� �� �������� ��������, ���������� ����� �����, ������� �� �����.", GameStat.Inclinations.Weapon, 9));
    }

    public Homeworld GetHomeworld(string worldName)
    {
        foreach(Homeworld homeworld in homeworlds)
        {
            if (homeworld.Name == worldName)
            {
                return homeworld;
            }
        }
        return null;
    }
}
