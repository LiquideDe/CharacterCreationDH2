using System.Collections.Generic;
using System;

public class UpgradeSkillPresenter : IPresenter
{
    public event Action<ICharacter> GoToTalent;
    public event Action<ICharacter> ReturnToCharacteristics;
    public event Action<Skill> ShowInformationPanel;

    private UpgradeSkillCreatorView _creatorView;
    private UpgradeSkillView _view;
    private ICharacter _character;
    private AudioManager _audioManager;
    private bool _isEdit = false;
    private enum TypeSkill {Skill, CommonLore, ForbiddenLore, Linguistics, ScholasticLore, Trade }
    private TypeSkill _currentScene = TypeSkill.Skill;

    public UpgradeSkillPresenter(UpgradeSkillCreatorView creatorView, UpgradeSkillView view, ICharacter character, AudioManager audioManager)
    {
        _creatorView = creatorView;
        _view = view;
        _character = character;
        _audioManager = audioManager;
        Subscribe();
        ShowSkills();
        _view.UpgradeExpireinceText($"{_character.ExperienceUnspent} ОО");
    }

    public void SetEdit() 
    {
        _isEdit = true;
        _view.UpgradeExpireinceText($" ОО");
    }

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
        _view.ShowThisSkillInfo += ShowInformationSkillPanel;
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
        _view.ShowThisSkillInfo -= ShowInformationSkillPanel;
    }

    private void ShowInformationSkillPanel(Skill skill) 
    {
        _audioManager.PlayClick();
        ShowInformationPanel?.Invoke(skill); 
    }

    private void NextWindowPressed()
    {
        //_audioManager.PlayClick();
        Unscribe();
        _view.DestroyView();
        GoToTalent?.Invoke(_character);
    }

    private void PrevWindowPressed()
    {
        //_audioManager.PlayClick();
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
            _view.UpgradeExpireinceText($"{_character.ExperienceUnspent} ОО");
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
            _view.UpgradeExpireinceText($"{_character.ExperienceUnspent} ОО");
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
