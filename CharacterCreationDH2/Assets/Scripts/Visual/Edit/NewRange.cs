using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class NewRange : NewMelee
{
    public TMP_InputField inputRange, inputRoFSingle, inputRoFShort, inputRoFLong, inputClip, inputReload;
    int clip, rofShort, rofLong, range;

    private void Start()
    {
        inputs.Add(inputName);
        inputs.Add(inputWeight);
        inputs.Add(inputClass);
        inputs.Add(inputDamage);
        inputs.Add(inputProperty);
        inputs.Add(inputPenetration);
        inputs.Add(inputRange);
        inputs.Add(inputRoFSingle);
        inputs.Add(inputRoFShort);
        inputs.Add(inputRoFLong);
        inputs.Add(inputClip);
        inputs.Add(inputReload);
    }
    public new void FinishCreating()
    {
        if (inputName.text != "" && inputClass.text.Length > 0 && inputDamage.text.Length > 0 && inputPenetration.text.Length > 0 && inputWeight.text.Length > 0 &&
            inputRange.text.Length > 0 && inputClip.text.Length > 0 && inputReload.text.Length > 0)
        {
            int.TryParse(inputRoFShort.text, out rofShort);
            int.TryParse(inputRoFLong.text, out rofLong);
            int.TryParse(inputRange.text, out range);
            int.TryParse(inputClip.text, out clip);
            int.TryParse(inputPenetration.text, out penetration);
            float.TryParse(inputWeight.text, out weight);

            JSONRangeReader rangeReader = new JSONRangeReader();
            rangeReader.clip = clip;
            rangeReader.damage = inputDamage.text;
            rangeReader.name = inputName.text;
            rangeReader.penetration = penetration;
            rangeReader.range = range;
            rangeReader.reload = inputReload.text;
            rangeReader.properties = inputProperty.text;
            string rSingle;
            string rShort;
            string rLong;
            if(inputRoFSingle.text.Length > 0)
            {
                if(inputRoFSingle.text != "-")
                {
                    rSingle = "Î";
                }
                else
                {
                    rSingle = "-";
                }
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
            createNewEq?.Invoke(weapon);
            ClearInputs();
            gameObject.SetActive(false);
        }
    }
}
