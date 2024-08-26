using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class UpgradeTalentPresenter : IPresenter
{
    public event Action<ICharacter> ReturnToSkill;
    public event Action<ICharacter> GoNext;
    private ICharacter _character;
    private UpgradeTalentView _view;
    private AudioManager _audioManager;
    private CreatorTalents _creatorTalents;
    private Talent _talent;
    private bool _isHideUnavailable = true;
    private bool _isEdit = false;
    private int _cost;
    private GameStat.Inclinations _inclination;

    [Inject]
    private void Construct(AudioManager audioManager, CreatorTalents creatorTalents)
    {
        _audioManager = audioManager;
        _creatorTalents = creatorTalents;
    }

    public void Initialize(UpgradeTalentView view, ICharacter character)
    {
        _view = view;
        _character = character;
        Subscribe();
        ShowTalents();
        _view.UpdateExperience($"{_character.ExperienceUnspent} ОО");
    }

    public void SetEdit() => _isEdit = true;

    private void Subscribe()
    {
        _view.Cancel += CancelDown;
        _view.LearnTalent += LearnTalentDown;
        _view.Next += NextDown;
        _view.Prev += PrevDown;
        _view.ShowAllTalents += ShowHideUnavailableTalents;
        _view.ShowAsDefault += ShowTalents;
        _view.ShowTalentsWithInclination += ShowTalents;
        _view.ShowThisTalent += ShowThisTalent;
    }

    private void Unscribe()
    {
        _view.Cancel -= CancelDown;
        _view.LearnTalent -= LearnTalentDown;
        _view.Next -= NextDown;
        _view.Prev -= PrevDown;
        _view.ShowAllTalents -= ShowHideUnavailableTalents;
        _view.ShowAsDefault -= ShowTalents;
        _view.ShowTalentsWithInclination -= ShowTalents;
        _view.ShowThisTalent -= ShowThisTalent;
    }

    private void CancelDown()
    {
        if (_character.GetCharacter is CharacterWithUpgrade)
        {
            _audioManager.PlayCancel();
            _character = _character.GetCharacter;
            _view.UpdateExperience($"{_character.ExperienceUnspent} ОО");
        }
        else
            _audioManager.PlayWarning();
    }

    private void LearnTalentDown()
    {
        if (_character.ExperienceUnspent >= _cost)
        {
            _audioManager.PlayDone();
            CharacterWithUpgrade character = new CharacterWithUpgrade(_character);
            character.UpgradeTalent(_talent, _cost);
            _view.CleanTalent();
            _character = character;
            _view.UpdateExperience($"{_character.ExperienceUnspent} ОО");
            ShowTalents(_inclination);
        }
        else
            _audioManager.PlayWarning();
    }

    private void NextDown()
    {
        _audioManager.PlayClick();
        GoNext?.Invoke(_character);
        Unscribe();
        _view.DestroyView();
    }

    private void PrevDown()
    {
        _audioManager.PlayClick();
        ReturnToSkill?.Invoke(_character);
        Unscribe();
        _view.DestroyView();
    }

    private void ShowHideUnavailableTalents()
    {
        if (_isHideUnavailable)
        {
            _isHideUnavailable = false;
            _view.SetButtonShowAllDeactive();
        }
        else
        {
            _isHideUnavailable = true;
            _view.SetButtonShowAllActive();
        }

        ShowTalents(_inclination);
    }

    private void ShowTalents(GameStat.Inclinations inclination = GameStat.Inclinations.None)
    {
        List<Talent> talents = new List<Talent>();
        List<int> costs = new List<int>();
        List<bool> isCanTaken = new List<bool>();
        _inclination = inclination;
        _audioManager.PlayClick();
        foreach(Talent talent in _creatorTalents.Talents)
        {
            if (talent.IsCanTaken || _isEdit)
            {
                if(TryDontDouble(talent) || talent.IsRepeatable)
                {
                    if(inclination == GameStat.Inclinations.None)
                    {
                        if (_isEdit)
                        {
                            talents.Add(talent);
                            costs.Add(CalculateCostTalent(talent));
                            isCanTaken.Add(true);
                        }
                        else if (!IsCanTaken(talent) && !_isHideUnavailable)
                        {
                            talents.Add(talent);
                            costs.Add(CalculateCostTalent(talent));
                            isCanTaken.Add(false);
                        }
                        else if (IsCanTaken(talent))
                        {
                            talents.Add(talent);
                            costs.Add(CalculateCostTalent(talent));
                            isCanTaken.Add(true);
                        }
                    }
                    else
                    {
                        if (_isEdit)
                        {
                            talents.Add(talent);
                            costs.Add(CalculateCostTalent(talent));
                            isCanTaken.Add(true);
                        }
                        else if (!IsCanTaken(talent) && !_isHideUnavailable && TryTalentForInclination(talent, inclination))
                        {
                            talents.Add(talent);
                            costs.Add(CalculateCostTalent(talent));
                            isCanTaken.Add(false);
                        }
                        else if (IsCanTaken(talent) && TryTalentForInclination(talent, inclination))
                        {
                            talents.Add(talent);
                            costs.Add(CalculateCostTalent(talent));
                            isCanTaken.Add(true);
                        }
                    }
                }                
            }
        }

        _view.Initialize(talents, costs, isCanTaken);
    }

    private bool TryDontDouble(Talent talent)
    {
        foreach(Talent talentInCharacter in _character.Talents)
        {
            if (string.Compare(talent.Name, talentInCharacter.Name, true) == 0)
                return false;
        }
        return true;
    }

    private int CalculateCostTalent(Talent talent)
    {
        if(_isEdit)
            return 0;
        int sum = 0;
        foreach (GameStat.Inclinations incl in _character.Inclinations)
        {
            if (incl == talent.Inclinations[0] || incl == talent.Inclinations[1])
            {
                sum++;
            }
        }
        
        return 300 * (1 + talent.Rank) - 150 * (talent.Rank + sum);        
    }

    private bool IsCanTaken(Talent talent)
    {
        if (TryFindRequireCharacteristic(_character.Characteristics, talent) && TryFindRequireSkill(_character.Skills, talent) && TryFindRequireImplant(_character.Implants, talent) && 
            TryFindRequireTalents(_character.Talents, talent) && _character.InsanityPoints >= talent.RequirementInsanity && 
            _character.CorruptionPoints >= talent.RequirementCorruption && _character.PsyRating >= talent.RequirementPsyRate)
        {
            return true;
        }
        
        return false;        
    }

    private bool TryFindRequireCharacteristic(List<Characteristic> characteristicsOfCharacter, Talent talent)
    {
        int amountReq = talent.RequirementCharacteristics.Count;
        if (amountReq == 0)
            return true;

        for (int i = 0; i < amountReq; i++)
        {
            for (int j = 0; j < characteristicsOfCharacter.Count; j++)
            {
                if (talent.RequirementCharacteristics[i].InternalName == characteristicsOfCharacter[j].InternalName)
                {
                    if (talent.RequirementCharacteristics[i].Amount > characteristicsOfCharacter[j].Amount)
                    {
                        return false;
                    }
                    break;
                }
            }

        }
        return true;
    }

    private bool TryFindRequireSkill(List<Skill> skillsOfCharacter, Talent talent)
    {
        int amountReq = talent.RequirementSkills.Count;
        if (amountReq == 0)        
            return true;
        
        for (int i = 0; i < amountReq; i++)
        {
            for (int j = 0; j < skillsOfCharacter.Count; j++)
            {
                if (string.Compare(talent.RequirementSkills[i].Name, skillsOfCharacter[j].Name, true) == 0)
                {
                    if (talent.RequirementSkills[i].LvlLearned > skillsOfCharacter[j].LvlLearned)
                    {
                        return false;
                    }
                    break;
                }
            }
        }
        return true;
    }

    private bool TryFindRequireImplant(List<MechImplant> implantsOfCharacter, Talent talent)
    {

        int amountReq = talent.RequirementImplants.Count;
        if (amountReq == 0)        
            return true;
        

        int sum = 0;
        for (int i = 0; i < amountReq; i++)
        {
            for (int j = 0; j < implantsOfCharacter.Count; j++)
            {
                if (talent.Name == "Использование Механодендритов Боевые")
                    Debug.Log($"implantCharacter = {implantsOfCharacter.Count}");
                if (string.Compare(talent.RequirementImplants[i].Name, implantsOfCharacter[j].Name, true) == 0)
                {
                    sum += 1;
                    break;
                }
            }
        }

        if (sum == amountReq)        
            return true;
        
        return false;
        
    }

    private bool TryFindRequireTalents(List<Talent> talentsOfCharacter, Talent talent)
    {
        int amountReq = talent.RequirementTalents.Count;
        if (amountReq == 0)
        {
            return true;
        }
        int sum = 0;
        for (int i = 0; i < amountReq; i++)
        {
            for (int j = 0; j < talentsOfCharacter.Count; j++)
            {
                if (string.Compare(talent.RequirementTalents[i].Name, talentsOfCharacter[j].Name, true) == 0)
                {
                    sum += 1;
                }
            }
        }

        if (sum == amountReq)        
            return true;
        
        return false;
        
    }

    private bool TryTalentForInclination(Talent talent, GameStat.Inclinations inclination)
    {
        if (talent.Inclinations[0] == inclination || talent.Inclinations[1] == inclination)
            return true;

        return false;
    }
    
    private void ShowThisTalent(Talent talent)
    {
        _audioManager.PlayClick();
        _talent = talent;
        _cost = CalculateCostTalent(talent);
        _view.ShowTalent(talent, IsCanTaken(talent), _cost);
    } 
}
