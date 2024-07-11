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
        prophecies.Add("Мутация снаружи, порча внутри.");
        prophecies.Add("Верь своему страху.");
        prophecies.Add("Для выживания Человечества люди должны умирать.");
        prophecies.Add("В сравнении с проклятьем боль есть экстаз.");
        prophecies.Add("Будь благом друзей и бичом врагов.");
        prophecies.Add("Мудрые учатся на чужих смертях.");
        prophecies.Add("Убей чужака прежде чем он солжёт.");
        prophecies.Add("Истина субъективна.");
        prophecies.Add("Раздумья порождают ересь.");
        prophecies.Add("Ересь порождает возмездие.");
        prophecies.Add("Разум без цели блуждает во тьме.");
        prophecies.Add("Если работа важна за неё можно умереть.");
        prophecies.Add("Тёмные мечты лежат на сердце.");
        prophecies.Add("Насилию подвластно всё.");
        prophecies.Add("Невежество суть лучшая мудрость.");
        prophecies.Add("Лишь безумцы достаточно сильны для процветания.");
        prophecies.Add("Подозрительный разум — здоровый разум.");
        prophecies.Add("Страдание — безжалостный учитель.");
        prophecies.Add("Есть лишь один истинный страх — умереть не исполнив долг.");
        prophecies.Add("Лишь со смертью завершается долг.");
        prophecies.Add("Невинность есть иллюзия.");
        prophecies.Add("Человек рождён для войны.");
        prophecies.Add("Нет замены рвению.");
        prophecies.Add("Даже не имеющий ничего может отдать свою жизнь.");
        prophecies.Add("Не спрашивай почему ты служишь. Спрашивай, как.");
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
            case "Мутация снаружи, порча внутри.":

                break;

            case "Верь своему страху.":
                character.Characteristics[6].Amount += 5;
                character.MentalDisorders.Add("Фобия");
                break;

            case "Для выживания Человечества люди должны умирать.":
                var tal = new Talent("Искушённый");
                if (tal.CheckTalentRepeat(character.Talents))
                {
                    character.UpgradeTalent(tal, 0);
                }
                else
                {
                    character.Characteristics[7].Amount += 2;
                }
                break;

            case "В сравнении с проклятьем боль есть экстаз.":
                character.Characteristics[4].Amount -= 3;
                break;

            case "Будь благом друзей и бичом врагов.":
                character.Characteristics[2].Amount += 2;
                break;

            case "Мудрые учатся на чужих смертях.":
                character.Characteristics[4].Amount += 3;
                character.Characteristics[0].Amount -= 3;
                break;

            case "Убей чужака прежде чем он солжёт.":
                var tal1 = new Talent("Выхватить Оружие");
                if (tal1.CheckTalentRepeat(character.Talents))
                {
                    character.UpgradeTalent(tal1, 0);
                }
                else
                {
                    character.Characteristics[4].Amount += 2;
                }
                break;

            case "Истина субъективна.":
                character.Characteristics[6].Amount += 3;                
                break;

            case "Раздумья порождают ересь.":
                character.Characteristics[5].Amount -= 3;
                break;

            case "Ересь порождает возмездие.":
                character.Characteristics[8].Amount += 3;
                character.Characteristics[3].Amount -= 3;
                break;

            case "Разум без цели блуждает во тьме.":

                break;

            case "Если работа важна за неё можно умереть.":
                character.Characteristics[3].Amount += 3;
                character.Characteristics[8].Amount -= 3;

                break;

            case "Тёмные мечты лежат на сердце.":

                break;

            case "Насилию подвластно всё.":
                character.Characteristics[0].Amount += 3;
                character.Characteristics[4].Amount -= 3;           
                break;

            case "Невежество суть лучшая мудрость.":
                character.Characteristics[6].Amount -= 3;
                break;

            case "Лишь безумцы достаточно сильны для процветания.":
                character.Characteristics[7].Amount += 3;
                break;

            case "Подозрительный разум — здоровый разум.":
                character.Characteristics[6].Amount += 2;
                break;

            case "Страдание — безжалостный учитель.":
                character.Characteristics[3].Amount -= 3;
                break;

            case "Есть лишь один истинный страх — умереть не исполнив долг.":
                var tal2 = new Talent("Сопротивление Холод");
                if (tal2.CheckTalentRepeat(character.Talents))
                {
                    character.UpgradeTalent(tal2, 0);
                }
                else
                {
                    character.Characteristics[3].Amount += 2;
                }
                break;

            case "Лишь со смертью завершается долг.":

                break;

            case "Невинность есть иллюзия.":
                var tal3 = new Talent("Чуткая Интуиция");
                if (tal3.CheckTalentRepeat(character.Talents))
                {
                    character.UpgradeTalent(tal3, 0);
                }
                else
                {
                    character.Characteristics[5].Amount += 2;
                }
                break;

            case "Человек рождён для войны.":
                if(character.Skills[7].LvlLearned < 1)
                {
                    character.Skills[7].SetNewLvl();
                }
                else
                {
                    character.Characteristics[4].Amount += 2;
                }
                break;

            case "Нет замены рвению.":
                var tal4 = new Talent("Разговор с Толпой");
                if (tal4.CheckTalentRepeat(character.Talents))
                {
                    character.UpgradeTalent(tal4, 0);
                }
                else
                {
                    character.Characteristics[8].Amount += 2;
                }
                break;

            case "Даже не имеющий ничего может отдать свою жизнь.":

                break;

            case "Не спрашивай почему ты служишь. Спрашивай, как.":
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
