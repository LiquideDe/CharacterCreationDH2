using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class UpgradeSkillPresenter : IPresenter
{
    public event Action<ICharacter> GoToTalent;
    public event Action<ICharacter> ReturnToCharacteristics;

    private UpgradeSkillCreatorView _creatorView;
    private UpgradeSkillView _view;
    private ICharacter _character;
    private AudioManager _audioManager;
    private bool _isEdit = false;
    private enum TypeSkill {Skill, CommonLore, ForbiddenLore, Linguistics, ScholasticLore, Trade }
    private TypeSkill _currentScene = TypeSkill.Skill;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void Initialize(UpgradeSkillView view, UpgradeSkillCreatorView creatorView, ICharacter character)
    {
        _character = character;
        _view = view;
        _creatorView = creatorView;
        Subscribe();
        ShowSkills();
        _view.UpgradeExpireinceText($"{_character.ExperienceUnspent} нн");
    }

    public void SetEdit() => _isEdit = true;

    private void Subscribe()
    {
        _view.CancelUpgrade += CancelUpgrade;
        _view.NextWindow += NextWindowPressed;
        _view.PrevWindow += PrevWindowPressed;
        _view.UpgradeSkill += UpgradeSkill;
        _view.ShowSkill += ShowSkillsDown;
        _view.ShowCommonLore += ShowCommonLoreDown;
        _view.ShowForbiddenlore += ShowForbiddenLoreDown;
        _view.ShowLuingva += ShowLingvaDown;
        _view.ShowSciense += ShowScienseDown;
        _view.ShowTrade += ShowTradeDown;
    }

    private void Unscribe()
    {
        _view.CancelUpgrade -= CancelUpgrade;
        _view.NextWindow -= NextWindowPressed;
        _view.PrevWindow -= PrevWindowPressed;
        _view.UpgradeSkill -= UpgradeSkill;
        _view.ShowSkill -= ShowSkillsDown;
        _view.ShowCommonLore -= ShowCommonLoreDown;
        _view.ShowForbiddenlore -= ShowForbiddenLoreDown;
        _view.ShowLuingva -= ShowLingvaDown;
        _view.ShowSciense -= ShowScienseDown;
        _view.ShowTrade -= ShowTradeDown;
    }

    private void NextWindowPressed()
    {
        _audioManager.PlayClick();
        Unscribe();
        _view.DestroyView();
        GoToTalent?.Invoke(_character);
    }

    private void PrevWindowPressed()
    {
        _audioManager.PlayClick();
        Unscribe();
        _view.DestroyView();
        ReturnToCharacteristics?.Invoke(_character);
    }

    private void UpgradeSkill(Skill skill, int cost)
    {
        if (cost <= _character.ExperienceUnspent || _isEdit)
        {
            _audioManager.PlayDone();
            CharacterWithUpgrade character = new CharacterWithUpgrade(_character);

            if(_isEdit)
                character.UpgradeSkill(skill, 0);
            else
                character.UpgradeSkill(skill, cost);

            _character = character;
            ShowSkills();
            _view.UpgradeExpireinceText($"{_character.ExperienceUnspent} нн");
        }
        else
            _audioManager.PlayWarning();
    }

    private void CancelUpgrade()
    {
        if (_character.GetCharacter is CharacterWithUpgrade)
        {
            _audioManager.PlayCancel();
            _character = _character.GetCharacter;
            ShowSkills();
            _view.UpgradeExpireinceText($"{_character.ExperienceUnspent} нн");
        }
        else
            _audioManager.PlayWarning();
    }

    private void ShowSkillsDown()
    {
        _audioManager.PlayClick();
        _currentScene = TypeSkill.Skill;
        ShowSkills();
    }

    private void ShowCommonLoreDown() 
    {
        _audioManager.PlayClick();
        _currentScene = TypeSkill.CommonLore;
        ShowSkills();
    } 

    private void ShowForbiddenLoreDown()
    {
        _audioManager.PlayClick();
        _currentScene = TypeSkill.ForbiddenLore;
        ShowSkills();
    }

    private void ShowLingvaDown() 
    {
        _audioManager.PlayClick();
        _currentScene = TypeSkill.Linguistics;
        ShowSkills();
    }

    private void ShowScienseDown()
    {
        _audioManager.PlayClick();
        _currentScene = TypeSkill.ScholasticLore;
        ShowSkills();
    }

    private void ShowTradeDown()
    {
        _audioManager.PlayClick();
        _currentScene = TypeSkill.Trade;
        ShowSkills();
    }

    private void ShowSkills()
    {
        if (_currentScene == TypeSkill.Skill)
            ShowAverageSkill();
        else
            ShowLoreSkills(_currentScene.ToString());
    }

    private void ShowAverageSkill()
    {
        List<Skill> skills = new List<Skill>();
        foreach (Skill skill in _character.Skills)
        {
            if (skill is Knowledge)
            {

            }
            else
                skills.Add(skill);
        }

        skills.Sort(
            delegate (Skill skill1, Skill skill2)
            {
                return skill1.Name.CompareTo(skill2.Name);
            });

        _creatorView.Initialize(skills, _character.Inclinations);
    }


    private void ShowLoreSkills(string internalKnowledgeName)
    {
        List<Skill> skills = new List<Skill>();
        foreach (Skill skill in _character.Skills)
        {
            if (skill is Knowledge)
            {
                Knowledge knowledge = (Knowledge)skill;
                if (knowledge.TypeSkill == internalKnowledgeName)
                    skills.Add(skill);
            }

        }

        skills.Sort(
            delegate (Skill skill1, Skill skill2)
            {
                return skill1.Name.CompareTo(skill2.Name);
            });
        _creatorView.Initialize(skills, _character.Inclinations);
    }
}
