using System.Collections.Generic;
using System;
using UnityEngine;

namespace CharacterCreation
{
    public class CharacteristicsAsInRuleBookPresenter
    {
        public event Action<ICharacter> GoNext;
        public event Action GoPrev;

        private AudioManager _audioManager;
        private CharacteristicsAsInRuleBookView _view;
        private ICharacter _character;
        private int _baseAmount = 15;
        private int _advantageFirst, _advantageSecond, _disadvantage;

        public CharacteristicsAsInRuleBookPresenter(AudioManager audioManager, CharacteristicsAsInRuleBookView view, ICharacter character, int baseAmount)
        {
            _audioManager = audioManager;
            _view = view;
            SearchCharacter(character);
            _baseAmount = baseAmount;
            SearchChracteristics(character);
            SetBaseToView();
            Subscribe();
        }

        private void Subscribe()
        {
            _view.Cancel += Cancel;
            _view.Done += Done;
            _view.Generate += Generate;
        }

        private void Unscribe()
        {
            _view.Cancel -= Cancel;
            _view.Done -= Done;
            _view.Generate -= Generate;
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
                _advantageFirst = GameStat.CharacteristicToInt[
                    GameStat.characterTranslate[characterWithHomeworld.AdvantageCharacteristicFirst]];
                _advantageSecond = GameStat.CharacteristicToInt[
                    GameStat.characterTranslate[characterWithHomeworld.AdvantageCharacteristicSecond]];
                _disadvantage = GameStat.CharacteristicToInt[GameStat.characterTranslate[characterWithHomeworld.DisadvantageCharacteristic]];
            }

            else
                SearchChracteristics(character.GetCharacter);
        }

        private void SetBaseToView()
        {
            _view.SetAnotherTextTo("Бросьте 3к10 и сложите 2 лучших", _advantageFirst);
            _view.SetAnotherTextTo("Бросьте 3к10 и сложите 2 лучших", _advantageSecond);
            _view.SetAnotherTextTo("Бросьте 3к10 и сложите 2 худших", _disadvantage);
            _view.Initialize(_baseAmount);
        }

        private void Generate()
        {
            int[] ints = new int[10];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = RollDices(2);
            }
            ints[_advantageFirst] = RollDices(3);
            ints[_advantageSecond] = RollDices(3);
            ints[_disadvantage] = RollDices(3, false);

            _view.SetAmountFromGenerator(ints);
        }

        private int RollDices(int amountDice, bool isBest = true)
        {
            int[] ints = new int[amountDice];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = GenerateInt();
            }
            if (isBest)
            {
                Array.Sort(ints);
                Array.Reverse(ints);
            }
            else
                Array.Sort(ints);

            return ints[0] + ints[1];
        }

        private void Done(int[] characteristics)
        {
            _audioManager.PlayDone();
            CharacterWithCharacteristics character = new CharacterWithCharacteristics(_character);
            List<int> ints = new List<int>();
            ints.AddRange(characteristics);
            character.SetCharacteristics(ints);
            _view.Hide(_view.DestroyView);
            GoNext?.Invoke(character);
            GoNext = null;
            GoPrev = null;
        }

        private void Cancel()
        {
            _audioManager.PlayCancel();
            _view.HideRight(_view.DestroyView);
            Unscribe();
            GoPrev?.Invoke();
            GoPrev = null;
            GoNext = null;
        }

        private int GenerateInt()
        {
            System.Random random = new System.Random();
            int chislo = random.Next(1, 11);
            return chislo;
        }
    }
}

