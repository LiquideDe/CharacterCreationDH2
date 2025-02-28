using System.Collections.Generic;
using System;
using System.Linq;

namespace CharacterCreation
{
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
        private bool _isHideTooExpensive = false;
        private GameStat.Inclinations _inclination;
        private LvlFactory _lvlFactory;
        private List<IName> _someToAdding = new List<IName>();

        public UpgradeTalentPresenter(ICharacter character, UpgradeTalentView view, AudioManager audioManager, CreatorTalents creatorTalents, LvlFactory lvlFactory)
        {
            _character = character;
            _view = view;
            _audioManager = audioManager;
            _creatorTalents = creatorTalents;
            _lvlFactory = lvlFactory;
            Subscribe();
            ShowTalents();
            _view.UpdateExperience($"{_character.ExperienceUnspent} ОО");
        }

        public void SetEdit()
        {
            _isEdit = true;
            ShowTalents();
        }

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
            _view.ShowWhenExp += ShowTooExpensive;
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
            _view.ShowWhenExp -= ShowTooExpensive;
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

                if (_talent.GetEquipments.Count > 0)
                {
                    foreach (var listEquipments in _talent.GetEquipments)
                    {
                        if (listEquipments.Count == 1)
                            character.AddEquipment(listEquipments[0]);
                        else
                        {
                            List<string> names = new List<string>();
                            foreach (var item in listEquipments)
                            {
                                names.Add(item.Name);
                                _someToAdding.Add(item);
                            }

                            ShowListForChoose(names, "Выберите экипировку", AddEquipment);
                        }
                    }
                }

                if (_talent.GetInclinations.Count > 0)
                {
                    foreach (var listInclinations in _talent.GetInclinations)
                    {
                        if (listInclinations.Count == 1)
                            character.AddInclination(listInclinations[0]);
                    }
                }

                if (_talent.GetSkills.Count > 0)
                    foreach (var listSkills in _talent.GetSkills)
                    {
                        if (listSkills.Count == 1)
                            character.UpgradeSkill(listSkills[0], 0);
                        else
                        {
                            List<string> names = new List<string>();
                            foreach (var item in listSkills)
                            {
                                names.Add(item.Name);
                                _someToAdding.Add(item);
                            }

                            ShowListForChoose(names, "Выберите навык", AddSkill);
                        }
                    }

                if (_talent.GetTalents.Count > 0)
                    foreach (var listTalents in _talent.GetTalents)
                    {
                        if (listTalents.Count == 1)
                            character.UpgradeTalent(listTalents[0], 0);
                        else
                        {
                            List<string> names = new List<string>();
                            foreach (var item in listTalents)
                            {
                                names.Add(item.Name);
                                _someToAdding.Add(item);
                            }

                            ShowListForChoose(names, "Выберите талант", AddTalent);
                        }
                    }

                if (_talent.GetTraits.Count > 0)
                    foreach (var listTraits in _talent.GetTraits)
                    {
                        if (listTraits.Count == 1)
                            character.AddTrait(listTraits[0]);
                        else
                        {
                            List<string> names = new List<string>();
                            foreach (var item in listTraits)
                            {
                                names.Add(item.Name);
                                _someToAdding.Add(item);
                            }

                            ShowListForChoose(names, "Выберите черту", AddTrait);
                        }
                    }

                if (_talent.GetWounds > 0)
                    character.AddWound();
            }
            else
                _audioManager.PlayWarning();
        }

        private void ShowListForChoose(List<string> names, string text, Action<string, ListWithNewItems> action)
        {
            ListWithNewItems list = _lvlFactory.Get(TypeScene.ListWithNewItems).GetComponent<ListWithNewItems>();
            list.ChooseThisAndClose += action;
            list.Initialize(names, text);
        }

        private void AddEquipment(string name, ListWithNewItems list)
        {
            CharacterWithUpgrade character = (CharacterWithUpgrade)_character;
            foreach (var item in _someToAdding)
            {
                if (string.Compare(item.Name, name, true) == 0)
                {
                    character.AddEquipment((Equipment)item);
                    break;
                }
            }
            list.HideRight(list.DestroyView);
        }

        private void AddSkill(string name, ListWithNewItems list)
        {
            CharacterWithUpgrade character = (CharacterWithUpgrade)_character;
            foreach (var item in _someToAdding)
            {
                if (string.Compare(item.Name, name, true) == 0)
                {
                    character.UpgradeSkill((Skill)item, 0);
                    break;
                }
            }
            list.HideRight(list.DestroyView);
        }

        private void AddTalent(string name, ListWithNewItems list)
        {
            CharacterWithUpgrade character = (CharacterWithUpgrade)_character;
            foreach (var item in _someToAdding)
            {
                if (string.Compare(item.Name, name, true) == 0)
                {
                    character.UpgradeTalent((Talent)item, 0);
                    break;
                }
            }
            list.HideRight(list.DestroyView);
        }

        private void AddTrait(string name, ListWithNewItems list)
        {
            CharacterWithUpgrade character = (CharacterWithUpgrade)_character;
            foreach (var item in _someToAdding)
            {
                if (string.Compare(item.Name, name, true) == 0)
                {
                    character.AddTrait((Trait)item);
                    break;
                }
            }
            list.HideRight(list.DestroyView);
        }

        private void NextDown()
        {
            //_audioManager.PlayClick();
            GoNext?.Invoke(_character);
            Unscribe();
            _view.DestroyView();
        }

        private void PrevDown()
        {
            //_audioManager.PlayClick();
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

            foreach (var talent in _creatorTalents.Talents.Where(t => t.IsCanTaken || _isEdit))
            {
                int cost = CalculateCostTalent(talent);

                if (!TryDontDouble(talent) && !talent.IsRepeatable)
                    continue;

                bool canBeTaken = IsCanTaken(talent);
                bool expEnough = TryExpEnough(cost);
                bool matchesInclination = inclination == GameStat.Inclinations.None || TryTalentForInclination(talent, inclination);

                if (!matchesInclination)
                    continue;

                if (_isEdit || (canBeTaken && expEnough) || (!_isHideUnavailable && expEnough))
                {
                    talents.Add(talent);
                    costs.Add(cost);
                    isCanTaken.Add(_isEdit || canBeTaken);
                }
            }


            _view.Initialize(talents, costs, isCanTaken);
        }

        private bool TryExpEnough(int cost)
        {
            if (!_isHideTooExpensive)
                return true;

            if (_character.ExperienceUnspent >= cost)
                return true;
            return false;
        }

        private bool TryDontDouble(Talent talent)
        {
            foreach (Talent talentInCharacter in _character.Talents)
            {
                if (string.Compare(talent.Name, talentInCharacter.Name, true) == 0)
                    return false;
            }
            return true;
        }

        private int CalculateCostTalent(Talent talent)
        {
            if (_isEdit)
                return 0;
            int sum = 0;

            if (talent.Rank > 3)
                return talent.Rank;

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
            if (_isEdit)
                return true;

            if (TryFindRequireCharacteristic(_character.Characteristics, talent) && TryFindRequireSkill(_character.Skills, talent) &&
                TryFindRequireSome(_character.Implants, talent.RequirementImplants) && TryFindRequireSome(_character.Talents, talent.RequirementTalents) &&
                _character.InsanityPoints >= talent.RequirementInsanity && _character.CorruptionPoints >= talent.RequirementCorruption &&
                _character.PsyRating >= talent.RequirementPsyRate && TryFindRequireSome(_character.Traits, talent.RequirementTraits) &&
                TryFindConflict(talent) == false && TryFindBackground(talent))
            {
                return true;
            }

            return false;
        }

        private bool TryFindConflict(Talent talent)
        {
            if (talent.ConflictTalent.Count == 0)
                return false;

            foreach (var item in talent.ConflictTalent)
            {
                for (int i = 0; i < _character.Talents.Count; i++)
                {
                    if (string.Compare(item.Name, _character.Talents[i].Name, true) == 0)
                        return true;
                }
            }

            return false;
        }

        private bool TryFindBackground(Talent talent)
        {
            if (talent.RequirementBackground.Length == 0)
                return true;

            if (string.Compare(talent.RequirementBackground, _character.Background, true) == 0)
                return true;

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

        private bool TryFindRequireSome<T>(List<T> traitsOfCharacter, List<T> requireSome) where T : IName
        {
            int amountRequired = requireSome.Count;
            if (amountRequired == 0)
            {
                return true;
            }
            int sum = 0;
            for (int i = 0; i < amountRequired; i++)
            {
                for (int j = 0; j < traitsOfCharacter.Count; j++)
                {
                    if (string.Compare(requireSome[i].Name, traitsOfCharacter[j].Name, true) == 0)
                    {
                        sum += 1;
                    }
                }
            }

            if (sum == amountRequired)
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

        private void ShowTooExpensive()
        {
            _audioManager.PlayClick();
            if (_isHideTooExpensive)
            {
                _isHideTooExpensive = false;
                _view.SetButtonShowWhenExpFalse();
            }
            else
            {
                _isHideTooExpensive = true;
                _view.SetButtonShowWhenExpTrue();
            }
            ShowTalents(_inclination);
        }
    }
}

