using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class NewRange : NewMelee
{
    public TMP_InputField inputRange, inputRoFShort, inputRoFLong, inputClip, inputReload;
    public Toggle toggleSingle;

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
                rSingle = "Î";
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

            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Range/{rangeReader.name}.JSON", rangeReader);

            Weapon weapon = new Weapon(rangeReader);
            SendEquipment(weapon);
        }
        else
            WrongInputPressed();
    }
}
