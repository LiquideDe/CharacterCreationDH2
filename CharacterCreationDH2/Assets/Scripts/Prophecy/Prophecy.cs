using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prophecy
{
    private List<string> prophecies = new List<string>();

    public Prophecy()
    {
        prophecies.Add("������� �������, ����� ������.");
        prophecies.Add("���� ������ ������.");
        prophecies.Add("��� ��������� ������������ ���� ������ �������.");
        prophecies.Add("� ��������� � ���������� ���� ���� ������.");
        prophecies.Add("���� ������ ������ � ����� ������.");
        prophecies.Add("������ ������ �� ����� �������.");
        prophecies.Add("���� ������ ������ ��� �� �����.");
        prophecies.Add("������ �����������.");
        prophecies.Add("�������� ��������� �����.");
        prophecies.Add("����� ��������� ���������.");
        prophecies.Add("����� ��� ���� �������� �� ����.");
        prophecies.Add("���� ������ ����� �� �� ����� �������.");
        prophecies.Add("Ҹ���� ����� ����� �� ������.");
        prophecies.Add("������� ���������� ��.");
        prophecies.Add("���������� ���� ������ ��������.");
        prophecies.Add("���� ������� ���������� ������ ��� �����������.");
        prophecies.Add("�������������� ����� � �������� �����.");
        prophecies.Add("��������� � ������������ �������.");
        prophecies.Add("���� ���� ���� �������� ����� � ������� �� �������� ����.");
        prophecies.Add("���� �� ������� ����������� ����.");
        prophecies.Add("���������� ���� �������.");
        prophecies.Add("������� ����� ��� �����.");
        prophecies.Add("��� ������ ������.");
        prophecies.Add("���� �� ������� ������ ����� ������ ���� �����.");
        prophecies.Add("�� ��������� ������ �� �������. ���������, ���.");
    }

    private int GenerateValue(int max)
    {
        //return UnityEngine.Random.Range(1, max);
        System.Random random = new System.Random();
        return random.Next(3, max);
    }

    private string PoleChudes(List<string> baraban, int naBarabane = 0)
    {
        int variants = 100 / baraban.Count;
        if (naBarabane == 0)
        {
            naBarabane = GenerateValue(100);
        }

        int id = (int)(naBarabane / variants);
        if (id >= baraban.Count)
        {
            id = baraban.Count - 1;
        }
        return baraban[id];
    }

    public string GenerateProphecy(Character character, int kubik = 0)
    {
        string choice = PoleChudes(prophecies, kubik);
        switch (choice)
        {
            case "������� �������, ����� ������.":

                break;

            case "���� ������ ������.":
                character.Characteristics[6].Amount += 5;
                character.MentalDisorders.Add("�����");
                break;

            case "��� ��������� ������������ ���� ������ �������.":
                var tal = new Talent("����������");
                if (tal.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal);
                }
                else
                {
                    character.Characteristics[7].Amount += 2;
                }
                break;

            case "� ��������� � ���������� ���� ���� ������.":
                character.Characteristics[4].Amount -= 3;
                break;

            case "���� ������ ������ � ����� ������.":
                character.Characteristics[2].Amount += 2;
                break;

            case "������ ������ �� ����� �������.":
                character.Characteristics[4].Amount += 3;
                character.Characteristics[0].Amount -= 3;
                break;

            case "���� ������ ������ ��� �� �����.":
                var tal1 = new Talent("��������� ������");
                if (tal1.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal1);
                }
                else
                {
                    character.Characteristics[4].Amount += 2;
                }
                break;

            case "������ �����������.":
                character.Characteristics[6].Amount += 3;
                
                break;

            case "�������� ��������� �����.":
                character.Characteristics[5].Amount -= 3;
                break;

            case "����� ��������� ���������.":
                character.Characteristics[8].Amount += 3;
                character.Characteristics[3].Amount -= 3;
                break;

            case "����� ��� ���� �������� �� ����.":

                break;

            case "���� ������ ����� �� �� ����� �������.":
                character.Characteristics[3].Amount += 3;
                character.Characteristics[8].Amount -= 3;

                break;

            case "Ҹ���� ����� ����� �� ������.":

                break;

            case "������� ���������� ��.":
                character.Characteristics[0].Amount += 3;
                character.Characteristics[4].Amount -= 3;           
                break;

            case "���������� ���� ������ ��������.":
                character.Characteristics[6].Amount -= 3;
                break;

            case "���� ������� ���������� ������ ��� �����������.":
                character.Characteristics[7].Amount += 3;
                break;

            case "�������������� ����� � �������� �����.":
                character.Characteristics[6].Amount += 2;
                break;

            case "��������� � ������������ �������.":
                character.Characteristics[3].Amount -= 3;
                break;

            case "���� ���� ���� �������� ����� � ������� �� �������� ����.":
                var tal2 = new Talent("������������� �����");
                if (tal2.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal2);
                }
                else
                {
                    character.Characteristics[3].Amount += 2;
                }
                break;

            case "���� �� ������� ����������� ����.":

                break;

            case "���������� ���� �������.":
                var tal3 = new Talent("������ ��������");
                if (tal3.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal3);
                }
                else
                {
                    character.Characteristics[5].Amount += 2;
                }
                break;

            case "������� ����� ��� �����.":
                if(character.Skills[7].LvlLearned < 1)
                {
                    character.Skills[7].SetNewLvl();
                }
                else
                {
                    character.Characteristics[4].Amount += 2;
                }
                break;

            case "��� ������ ������.":
                var tal4 = new Talent("�������� � ������");
                if (tal4.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal4);
                }
                else
                {
                    character.Characteristics[8].Amount += 2;
                }
                break;

            case "���� �� ������� ������ ����� ������ ���� �����.":

                break;

            case "�� ��������� ������ �� �������. ���������, ���.":
                character.FatePoint += 1;
                break;
        }
        return choice;
    }
}
