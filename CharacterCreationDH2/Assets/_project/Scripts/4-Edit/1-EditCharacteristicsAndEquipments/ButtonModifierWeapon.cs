using UnityEngine;
using UnityEngine.UI;
using System;

namespace CharacterCreation
{
    public class ButtonModifierWeapon : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private RectTransform _rectTransform;
        public event Action<Weapon> ModifierThisWeapon;
        private Weapon _weapon;

        public void SetWeapon(Weapon weapon)
        {
            gameObject.SetActive(true);
            _weapon = weapon;
            _button.onClick.AddListener(SendWeapon);
            _rectTransform.anchoredPosition.Set(0, 0);
        }

        private void SendWeapon()
        {
            ModifierThisWeapon?.Invoke(_weapon);
        }
    }
}

