using UnityEngine;
using TMPro;
using System;

namespace CharacterCreation
{
    public class CharacteristicCardInRuleBook : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputFieldRandom;
        [SerializeField] private GameObject _backgroundAmount;
        [SerializeField] private TextMeshProUGUI _textAmountRandom;
        [SerializeField] private TextMeshProUGUI _textAmount;

        public event Action InputIsEntered;
        public event Action InputError;

        private int _baseAmount;
        private int _addingAmount;

        public bool IsSetted { get; private set; }

        public int TotalAmount => _baseAmount + _addingAmount;

        private void OnEnable() => _inputFieldRandom.onDeselect.AddListener(AddAmountFromInput);

        private void OnDisable() => _inputFieldRandom.onDeselect.RemoveAllListeners();

        public void SetBaseAmount(int amount)
        {
            _baseAmount = amount;
            _textAmount.text = $"{_baseAmount}";
        }

        public void AddAmountFromRandom(int amount)
        {
            _inputFieldRandom.gameObject.SetActive(false);
            _backgroundAmount.SetActive(true);
            _addingAmount = amount;
            _textAmountRandom.text = _addingAmount.ToString();
            _textAmount.text = $"{_baseAmount + _addingAmount}";
            IsSetted = true;
        }

        public void SetAnotherTextToHolder(string text)
        {
            _inputFieldRandom.placeholder.GetComponent<TMP_Text>().text = text;
        }

        private void AddAmountFromInput(string text)
        {
            int.TryParse(text, out _addingAmount);
            if (_addingAmount > 0)
            {
                _inputFieldRandom.gameObject.SetActive(false);
                _backgroundAmount.SetActive(true);
                _textAmountRandom.text = text;
                _textAmount.text = $"{_baseAmount + _addingAmount}";
                IsSetted = true;
            }
            else
                InputError?.Invoke();
        }
    }
}

