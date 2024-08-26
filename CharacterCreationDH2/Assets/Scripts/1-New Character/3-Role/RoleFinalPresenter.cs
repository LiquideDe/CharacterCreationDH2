using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RoleFinalPresenter : IPresenter
{
    public event Action<ICharacter> CharacterIsChosen;
    public event Action CancelChoice;

    private CreatorTogglesForFinalPanel _creatorToggles;
    private BackgroundFinalPanelView _view;
    private AudioManager _audioManager;
    private ICharacter _character;
    private Role _role;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;


    public void Initialize(GameObject finalPanelView, ICharacter character, Role role)
    {
        _creatorToggles = finalPanelView.GetComponent<CreatorTogglesForFinalPanel>();
        _view = finalPanelView.GetComponent<BackgroundFinalPanelView>();
        _character = character;
        _role = role;
        Subscribe();
        CreateToggles();
    }

    private void CreateToggles()
    {
        if (_role.Talents.Count > 0)
        {
            List<List<Talent>> talentList = new List<List<Talent>>();
            talentList.Add(new List<Talent>());
            talentList[0].AddRange(_role.Talents);
            _creatorToggles.CreateTogglesTalent(talentList);
        }
            


        if (_role.Inclinations.Count > 0)
            _creatorToggles.CreateToggleInclinations(_role.Inclinations);

        _creatorToggles.FinalResize();
    }

    private void Subscribe()
    {
        _view.Done += DoneDown;
        _view.Cancel += CancelDown;
    }

    private void Unscribe()
    {
        _view.Done -= DoneDown;
        _view.Cancel -= CancelDown;
    }

    private void CancelDown(CanDestroyView view)
    {
        _audioManager.PlayCancel();
        CancelChoice?.Invoke();
        Unscribe();
        view.DestroyView();
    }

    private void DoneDown()
    {
        _audioManager.PlayDone();
        List<ToggleGroup> toggleGroups = _view.GetToggles();
        Unscribe();
        _view.DestroyView();
        ConfigForCharacterFromRole config = new ConfigForCharacterFromRole();
        config.BonusRole = _role.BonusText;
        config.NameRole = _role.Name;

        int sch = 0;

        List<Talent> talents = new List<Talent>();
        talents.Add(_role.Talents[toggleGroups[0].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);

        if (_role.BonusTalent.Length > 1)
            talents.Add(new Talent("Псайкер"));

        sch++;

        List<GameStat.Inclinations> inclinations = new List<GameStat.Inclinations>();
        foreach (List<GameStat.Inclinations> inclinationsList in _role.Inclinations)
        {
            if (inclinationsList.Count > 1)
            {
                inclinations.Add(inclinationsList[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
            }
            else
            {
                inclinations.Add(inclinationsList[0]);
            }
            sch++;
        }

        config.SetTalents(talents);
        config.SetInclinations(inclinations);

        CharacterWithRole character = new CharacterWithRole(_character);
        character.SetRole(config);

        CharacterIsChosen?.Invoke(character);
    }
}
