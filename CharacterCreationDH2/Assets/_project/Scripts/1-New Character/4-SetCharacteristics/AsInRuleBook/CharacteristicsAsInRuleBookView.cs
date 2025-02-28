using UnityEngine;
using UnityEngine.UI;
using System;

namespace CharacterCreation
{
    public class CharacteristicsAsInRuleBookView : AnimateShowAndHideView
    {
        [SerializeField] private CharacteristicCardInRuleBook[] _characteristicCards;
        [SerializeField] private Button _buttonCancel, _buttonDone, _buttonGenerate;

        public event Action Cancel, Generate;
        public event Action<int[]> Done;

        private void OnEnable()
        {
            _buttonCancel.onClick.AddListener(CancelPressed);
            _buttonDone.onClick.AddListener(DonePressed);
            _buttonGenerate.onClick.AddListener(GeneratePressed);
        }
        private void OnDisable()
        {
            _buttonCancel.onClick.RemoveAllListeners();
            _buttonDone.onClick.RemoveAllListeners();
            _buttonGenerate.onClick.RemoveAllListeners();
        }

        public void Initialize(int baseAmount)
        {
            foreach (var item in _characteristicCards)
            {
                item.SetBaseAmount(baseAmount);
                item.InputError += _audio.PlayWarning;
                item.InputIsEntered += _audio.PlayClick;
            }
        }

        public void SetAnotherTextTo(string text, int id) => _characteristicCards[id].SetAnotherTextToHolder(text);

        public void SetAmountFromGenerator(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                _characteristicCards[i].AddAmountFromRandom(ints[i]);
            }
        }

        private void GeneratePressed() => Generate?.Invoke();

        private void DonePressed()
        {
            bool isAllDone = true;

            foreach (var item in _characteristicCards)
            {
                if (item.IsSetted == false)
                {
                    isAllDone = false;
                    break;
                }
            }

            if (isAllDone == false)
            {
                _audio.PlayWarning();
                return;
            }

            int[] characteristics = new int[10]
            {
            _characteristicCards[0].TotalAmount,
            _characteristicCards[1].TotalAmount,
            _characteristicCards[2].TotalAmount,
            _characteristicCards[3].TotalAmount,
            _characteristicCards[4].TotalAmount,
            _characteristicCards[5].TotalAmount,
            _characteristicCards[6].TotalAmount,
            _characteristicCards[7].TotalAmount,
            _characteristicCards[8].TotalAmount,
            _characteristicCards[9].TotalAmount
            };

            Done?.Invoke(characteristics);
        }

        private void CancelPressed() => Cancel?.Invoke();
    }
}


