﻿using System;
using System.Collections.Generic;

namespace CharacterCreation
{
    public class CharacteristicRandomPresenter : IPresenter
    {
        public event Action<ICharacter> ReturnCharacterWithCharacteristics;
        public event Action ReturnToRole;
        private GameStat.CharacteristicName _advantageFirst, _advantageSecond, _disadvantage;
        private ICharacter _character;
        private CharacteristicRandomView _view;
        private int _baseAmount;
        private AudioManager _audioManager;

        public CharacteristicRandomPresenter(ICharacter character, CharacteristicRandomView view, int baseAmount, AudioManager audioManager)
        {
            _character = character;
            _view = view;
            _baseAmount = baseAmount;
            _audioManager = audioManager;
            Subscribe();
            SearchCharacter(_character);
            SearchChracteristics(_character);
            SetAmountCharacteristics();
        }

        private void Subscribe()
        {
            _view.ReturnToRole += ReturnToRolePressed;
            _view.ReturnCharacteristics += ReturnCharacteristics;
            _view.GenerateAmounts += GenerateAmounts;
        }

        private void Unscribe()
        {
            _view.ReturnToRole -= ReturnToRolePressed;
            _view.ReturnCharacteristics -= ReturnCharacteristics;
            _view.GenerateAmounts -= GenerateAmounts;
        }

        private void SearchCharacter(ICharacter character)
        {
            if (character is CharacterWithRole)
                _character = character;

            else
                SearchCharacter(character.GetCharacter);
        }

        private void SearchChracteristics(ICharacter character)
        {
            if (character is CharacterWithHomeworld)
            {
                CharacterWithHomeworld characterWithHomeworld = (CharacterWithHomeworld)character;
                _advantageFirst = characterWithHomeworld.AdvantageCharacteristicFirst;
                _advantageSecond = characterWithHomeworld.AdvantageCharacteristicSecond;
                _disadvantage = characterWithHomeworld.DisadvantageCharacteristic;
            }

            else
                SearchChracteristics(character.GetCharacter);
        }

        private void SetAmountCharacteristics()
        {
            _view.SetWeapon(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.WeaponSkill));
            _view.SetBallistic(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.BallisticSkill));
            _view.SetStrength(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Strength));
            _view.SetToughness(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Toughness));
            _view.SetAgility(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Agility));
            _view.SetIntelligence(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Intelligence));
            _view.SetPerception(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Perception));
            _view.SetWillPower(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Willpower));
            _view.SetSocial(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Fellowship));
            _view.SetInfluence(_baseAmount + CheckAdvantage(GameStat.CharacteristicName.Influence));
        }

        private int CheckAdvantage(GameStat.CharacteristicName characteristic)
        {
            if (characteristic == _advantageFirst || characteristic == _advantageSecond)
                return 5;

            if (characteristic == _disadvantage)
                return -5;

            return 0;
        }

        private void ReturnToRolePressed()
        {
            Unscribe();
            _view.DestroyView();
            ReturnToRole?.Invoke();
            ClearSubsribe();
        }

        private void ReturnCharacteristics(List<int> characteristics)
        {
            CharacterWithCharacteristics character = new CharacterWithCharacteristics(_character);
            character.SetCharacteristics(characteristics);
            ReturnCharacterWithCharacteristics?.Invoke(character);
            Unscribe();
            _view.DestroyView();
            ClearSubsribe();
        }

        private void GenerateAmounts()
        {
            _audioManager.PlayClick();
            int[] ints = new int[10];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = GenerateInt() + GenerateInt();
            }

            _view.SetCards(ints);
        }

        private int GenerateInt()
        {
            System.Random random = new System.Random();
            int chislo = random.Next(1, 11);
            UnityEngine.Debug.Log($"chislo = {chislo}");
            return chislo;
        }

        private void ClearSubsribe()
        {
            ReturnCharacterWithCharacteristics = null;
            ReturnToRole = null;
        }
    }
}

