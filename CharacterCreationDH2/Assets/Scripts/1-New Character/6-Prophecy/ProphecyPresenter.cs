using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class ProphecyPresenter : IPresenter
{
    public event Action<ICharacter> GoNext;
    private List<string> prophecies = new List<string>();
    private AudioManager _audioManager;
    private ProphecyView _view;
    private ICharacter _character;
    private bool isProphecied;

    public ProphecyPresenter()
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

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void Initialize(ProphecyView view, ICharacter character)
    {
        _view = view;
        _character = character;
        Subscribe();
    }

    private void Subscribe()
    {
        _view.Done += GoNextDown;
        _view.GenerateNumber += GenerateNumber;
        _view.InputNumber += SetNumberFromInput;
    }

    private void Unscribe()
    {
        _view.Done -= GoNextDown;
        _view.GenerateNumber -= GenerateNumber;
        _view.InputNumber -= SetNumberFromInput;
    }

    private void GenerateNumber()
    {
        _audioManager.PlayClick();
        int number = PoleChudes.GenerateIntValue(100);
        GenerateProphecy(number);
    }

    private void SetNumberFromInput(string value)
    {
        int.TryParse(value, out int kubik);
        if (kubik > 0)
        {
            _audioManager.PlayClick();
            GenerateProphecy(kubik);
        }
        else
            _audioManager.PlayWarning();
    }

    private void GenerateProphecy(int kubik)
    {
        string choice = PoleChudes.GetVariantFrom(prophecies, kubik);
        CharacterWithUpgrade character = new CharacterWithUpgrade(_character);
        int bonusfate = 0;

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
                    character.UpgradeTalent(tal, 0);
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
                    character.UpgradeTalent(tal1, 0);
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
                    character.UpgradeTalent(tal2, 0);
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
                    character.UpgradeTalent(tal3, 0);
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
                    character.UpgradeTalent(tal4, 0);
                }
                else
                {
                    character.Characteristics[8].Amount += 2;
                }
                break;

            case "���� �� ������� ������ ����� ������ ���� �����.":

                break;

            case "�� ��������� ������ �� �������. ���������, ���.":
                bonusfate++;
                break;
        }
        isProphecied = true;

        CharacterWithNameAndProphecy characterWithName = new CharacterWithNameAndProphecy(character);
        characterWithName.SetProphecy(choice);
        characterWithName.IncreaseFatePoint(bonusfate);
        _character = characterWithName;
        _view.SetText(choice);
    }

    private void GoNextDown()
    {
        if (isProphecied)
        {
            _audioManager.PlayDone();
            GoNext?.Invoke(_character);
            Unscribe();
            _view.DestroyView();
        }
        else
            _audioManager.PlayWarning();
        
    }
}
