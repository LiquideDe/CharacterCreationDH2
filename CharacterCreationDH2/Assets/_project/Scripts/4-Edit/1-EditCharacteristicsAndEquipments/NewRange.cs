using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

namespace CharacterCreation
{
    public class NewRange : NewMelee
    {
        public TMP_InputField inputRange, inputRoFShort, inputRoFLong, inputClip, inputReload;
        public Toggle toggleSingle;
        public MyDropDown _dropdownSounds;

        public override void Initialize()
        {
            base.Initialize();
            List<string> options = new List<string>() {"Револьвер", "Автомат", "Дробовик", "Лазерное", "Болтерное", "Огнемет", "Пистолет", "Плазменное",
            "Мельта", "Грав", "Электро", "Радиационное" };
            _dropdownSounds.AddOptions(options);
        }

        public override void SetWeapon(Weapon weapon)
        {
            base.SetWeapon(weapon);
            inputRange.text = weapon.Range.ToString();
            var rof = weapon.Rof.Split(new char[] { '/' }).ToList();
            inputRoFShort.text = rof[1];
            inputRoFLong.text = rof[2];
            if (string.Compare(rof[0], "-", true) == 0)
                toggleSingle.isOn = false;
            else toggleSingle.isOn = true;
            inputClip.text = weapon.Clip.ToString();
            inputReload.text = weapon.Reload.ToString();
            _dropdownSounds.Value = weapon.TypeSound;
        }

        public override void FinishCreating()
        {
            if (_inputName.text != "" && inputClass.text.Length > 0 && inputPenetration.text.Length > 0 && _inputWeight.text.Length > 0 &&
                inputRange.text.Length > 0 && inputClip.text.Length > 0 && inputReload.text.Length > 0)
            {
                int.TryParse(inputRoFShort.text, out int rofShort);
                int.TryParse(inputRoFLong.text, out int rofLong);
                int.TryParse(inputRange.text, out int range);
                int.TryParse(inputClip.text, out int clip);
                int.TryParse(inputPenetration.text, out int penetration);
                float.TryParse(_inputWeight.text, out float weight);

                JSONRangeReader rangeReader = new JSONRangeReader();
                rangeReader.clip = clip;
                rangeReader.damage = MakeDamageText();
                rangeReader.name = _inputName.text;
                rangeReader.penetration = penetration;
                rangeReader.range = range;
                rangeReader.reload = inputReload.text;
                rangeReader.properties = TranslatePropertiesToText();
                rangeReader.typeEquipment = Equipment.TypeEquipment.Range.ToString();
                rangeReader.amount = 1;
                string rSingle;
                string rShort;
                string rLong;

                if (toggleSingle.isOn)
                {
                    rSingle = "О";
                }
                else
                {
                    rSingle = "-";
                }


                rShort = rofShort == 0 ? "-" : rofShort.ToString();
                rLong = rofLong == 0 ? "-" : rofLong.ToString();

                rangeReader.rof = $"{rSingle}/{rShort}/{rLong}";
                rangeReader.weaponClass = inputClass.text;
                rangeReader.weight = weight;
                rangeReader.typeSound = _dropdownSounds.Value;
                rangeReader.rarity = _inputRarity.text;
                rangeReader.description = _inputDescription.text;

                if (_isNewWeapon)
                    SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/{rangeReader.name}.JSON", rangeReader);

                Weapon weapon = new Weapon(rangeReader);
                SendEquipment(weapon);
            }
            else
                WrongInputPressed();
        }
    }
}

