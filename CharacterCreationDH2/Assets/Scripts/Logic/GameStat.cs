using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public static class GameStat
{
    public static Dictionary<CharacterName, string> characterTranslate = new Dictionary<CharacterName, string>()
    {
        { CharacterName.WeaponSkill,"����� ����������" },
        { CharacterName.BallisticSkill,"����� ��������" },
        { CharacterName.Strength,"����" },
        { CharacterName.Toughness,"������������" },
        { CharacterName.Agility,"��������" },
        { CharacterName.Intelligence,"���������" },
        { CharacterName.Perception,"����������" },
        { CharacterName.Willpower,"���� ����" },
        { CharacterName.Fellowship,"�������������" },
        { CharacterName.Influence,"�������" }

    };

    public static Dictionary<Inclinations, string> inclinationTranslate = new Dictionary<Inclinations, string>()
    {
        {Inclinations.Agility, "��������" },
        {Inclinations.Ballistic, "��������" },
        {Inclinations.Defense, "������" },
        {Inclinations.Fellowship, "�������������" },
        {Inclinations.Fieldcraft, "�������" },
        {Inclinations.Finesse, "���������" },
        {Inclinations.General, "�����" },
        {Inclinations.Intelligence, "���������" },
        {Inclinations.Knowledge, "��������" },
        {Inclinations.Leadership, "���������" },
        {Inclinations.Offense, "���������" },
        {Inclinations.Perception, "����������" },
        {Inclinations.Psyker, "�������" },
        {Inclinations.Social, "�������" },
        {Inclinations.Strength, "����" },
        {Inclinations.Tech, "���" },
        {Inclinations.Toughness, "������������" },
        {Inclinations.Weapon, "������� ���" },
        {Inclinations.Willpower, "���� ����" }
    };
    
    public enum Inclinations {None, Agility, Ballistic, Defense, Fellowship,
    Fieldcraft, Finesse, General, Intelligence, Knowledge, Leadership,
    Offense, Perception, Psyker, Social, Strength, Tech, Toughness,
    Weapon, Willpower, Elite};

    public enum CharacterName { None, WeaponSkill, BallisticSkill, Strength, Toughness, Agility, Intelligence, Perception, Willpower, Fellowship, Influence}    
    
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
        {Inclinations.Agility, "���������� ����������� ��������� �������� ��������, � ����� ��������� � ��� ������ � �������." },
        {Inclinations.Ballistic, "���������� ����������� ��������� �������� ����� ��������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Defense, "������� � ���� ����������� ������ ������ �������� ����� ������������ ����� ��������. �������� �� ��� ��������� �������������� ��� �������� ���������, ��� �������� �� ����� �������� � � ������ ������� �������� 41-��� �����������, ���������� ������� ����� ������. " },
        {Inclinations.Fellowship, "���������� ����������� ��������� �������� �������������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Fieldcraft, "������ �� ������� ��������� ��������� ����� �� ����� ������ ��� � ��������� ��������. ������� �� ����������� ������� ����� ����������������� � ����������� � ������� ��������, �� ������ ��������, �� ������ �������. " },
        {Inclinations.Finesse, "������ � ������� �� ����������� ��������� ���������� �� ������������ ���������� � ���������� ������������. ������� �� ����������� ��������� ����� ����� ���������� � �������� �� ������� ��������� ��� ������������� ������������� ������." },
        {Inclinations.General, "�����" },
        {Inclinations.Intelligence, "���������� ����������� ��������� �������� ���������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Knowledge, "������������ ���� � ������������ ����������� ��������� �������� ������ ����������, ��� �������� ������� �� ������� ������. � �� ����� ��� ����������� ��������� ���������� �������� � ��������� ������������ ������� � ���������� ����� ���������, ��������� �� ����������� �������� ����� ������������ ����� �������� ������ � ����������." },
        {Inclinations.Leadership, "� ��������� ����� ��������� ��������� �����, �� ��� ����������� ��� �� ����� ������, ��� ������� ���� ��� ����������� ����. ����������� ������������ �������� ��� ������ ������������, � ������� � ���� ����������� �������� ���������� ���������� �� ������ ����������� � ����������� ����� ������� ���������� ����������� ������ ��� ���������� �� ��������-���������." },
        {Inclinations.Offense, "��������� � ���� ����������� ������������ ������������ ������ ���� ������ ����� �����������, ��������������� �������. ��� ������� ����� ��������� � ���������� ���������� ����������� ������� ��� ��������� ����� ������������� ������� �����." },
        {Inclinations.Perception, "���������� ����������� ��������� �������� ����������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Psyker, "���������� ������� ����� �������� ���� ���������� ������ ������������ ������� ������������ ������. ����� ��� ��������� �� ����������� ������� ������������������ �������, ��������������� � ����������� ���������� ����� ��� ������������� ����������� ���. " },
        {Inclinations.Social, "����� ������� ����� ���� �� ����� �������, ��� �����������, �������� ��� ���������� � ��������� � �������� ��������� �����. � ���� ����������� ����� �������, ��� ��������� ������� ������������ ����������� ���� � ������ ����������� ��� ������������� ������� � �������������� ������������, ��������������� �������� ���������� � ����� �����������. " },
        {Inclinations.Strength, "���������� ����������� ��������� �������� ����, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Tech, "���� �������� ������������ ����������� � ������ ����������� ���������� Ҹ���� ��� ����������, � ��� ������ ����� ����������� � ����. ��������� �� ����������� ����� ���������� ������ �������� ������ �����, �� ����� �������� � �� ������ � �������� �������� ��������� ���, ��� ������ ������ ���� �������." },
        {Inclinations.Toughness, "���������� ����������� ��������� �������� ������������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Weapon, "���������� ����������� ��������� �������� ����� ����������, � ����� ��������� � ��� ������ � �������. " },
        {Inclinations.Willpower, "���������� ����������� ��������� �������� ���� ����, � ����� ��������� � ��� ������ � �������. " }
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
