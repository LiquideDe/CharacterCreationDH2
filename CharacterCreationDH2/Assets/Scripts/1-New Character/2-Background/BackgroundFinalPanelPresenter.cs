using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BackgroundFinalPanelPresenter : IPresenter
{
    public event Action<ICharacter> CharacterIsChosen;
    public event Action CancelChoice;

    private CreatorTogglesForFinalPanel _creatorToggles;
    private BackgroundFinalPanelView _view;
    private AudioManager _audioManager;
    private ICharacter _character;
    private Background _background;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;
    

    public void Initialize(GameObject finalPanelView, ICharacter character, Background background)
    {
        _creatorToggles = finalPanelView.GetComponent<CreatorTogglesForFinalPanel>();
        _view = finalPanelView.GetComponent<BackgroundFinalPanelView>();
        _character = character;
        _background = background;
        Subscribe();
        CreateToggles();
    }

    private void CreateToggles()
    {
        if(_background.Skills.Count > 0)
            _creatorToggles.CreateTogglesSkill(_background.Skills);
        

        if(_background.Talents.Count > 0)       
            _creatorToggles.CreateTogglesTalent(_background.Talents);
        

        if(_background.Equipments.Count > 0)
            _creatorToggles.CreateToggleEquipments(_background.Equipments);
        

        if (_background.MechImplants.Count > 0)
            _creatorToggles.CreateToggleImplants(_background.MechImplants);

        if(_background.Inclinations.Count > 0)
        {
            List<List<GameStat.Inclinations>> inclinationList = new List<List<GameStat.Inclinations>>();
            inclinationList.Add(new List<GameStat.Inclinations>());
            inclinationList[0].AddRange(_background.Inclinations);
            _creatorToggles.CreateToggleInclinations(inclinationList);
        }
            

        _creatorToggles.FinalResize();
    }

    private void Subscribe()
    {
        _view.Done += DoneDown;
        _view.Cancel += CancelDown;
    }

    private void Unsubscribe()
    {
        _view.Done -= DoneDown;
        _view.Cancel -= CancelDown;
    }

    private void CancelDown(CanDestroyView view)
    {
        _audioManager.PlayCancel();
        CancelChoice?.Invoke();
        Unsubscribe();
        view.DestroyView();
    }

    private void DoneDown()
    {
        _audioManager.PlayDone();
        List<ToggleGroup> toggleGroups = _view.GetToggles();
        Unsubscribe();
        _view.DestroyView();
        ConfigForCharacterFromBackground config = new ConfigForCharacterFromBackground();
        config.Bonus = _background.BonusText;
        config.Name = _background.Name;

        int sch = 0;
        List<Skill> skills = new List<Skill>();
        foreach (List<Skill> sk in _background.Skills)
        {
            if (sk.Count > 1)
            {
                skills.Add(sk[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
            }
            else
            {
                skills.Add(sk[0]);
            }
            sch++;
        }

        List<Talent> talents = new List<Talent>();
        foreach (List<Talent> tal in _background.Talents)
        {
            if (tal.Count > 1)
            {
                talents.Add(tal[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
            }
            else
            {
                talents.Add(tal[0]);
            }
            sch++;
        }

        List<Equipment> equipment = new List<Equipment>();
        foreach (List<Equipment> eq in _background.Equipments)
        {
            if (eq.Count > 1)
            {
                equipment.Add(eq[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
            }
            else
            {
                equipment.Add(eq[0]);
            }
            sch++;
        }

        List<MechImplant> implants = new List<MechImplant>();
        foreach(MechImplant implant in _background.MechImplants)
        {
            implants.Add(implant);
            sch++;
        }

        config.Inclination = _background.Inclinations[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id];

        config.RememberThing = PoleChudes.GetVariantFrom(_background.RememberThings, PoleChudes.GenerateIntValue(100));

        config.SetSkills(skills);
        config.SetTalents(talents);
        config.SetEquipment(equipment);
        config.SetImplants(implants);

        CharacterWithBackground character = new CharacterWithBackground(_character);
        character.SetBackground(config);

        CharacterIsChosen?.Invoke(character);
    }
}
