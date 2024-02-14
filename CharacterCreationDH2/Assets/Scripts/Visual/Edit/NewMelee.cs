using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class NewMelee : CreatorNewEquipment
{
    public TMP_InputField inputClass, inputDamage, inputProperty, inputPenetration;
    protected int penetration;

    private void Start()
    {
        inputs.Add(inputName);
        inputs.Add(inputWeight);
        inputs.Add(inputClass);
        inputs.Add(inputDamage);
        inputs.Add(inputProperty);
        inputs.Add(inputPenetration);
    }
    public new void FinishCreating()
    {
        if (inputName.text != "" && inputClass.text.Length > 0 && inputDamage.text.Length > 0 && inputPenetration.text.Length > 0 && inputWeight.text.Length > 0)
        {
            float.TryParse(inputWeight.text, out weight);
            int.TryParse(inputPenetration.text, out penetration);
            JSONMeleeReader meleeReader = new JSONMeleeReader();
            meleeReader.name = inputName.text;
            meleeReader.penetration = penetration;
            meleeReader.properties = inputProperty.text;
            meleeReader.weaponClass = inputClass.text;
            meleeReader.weight = weight;
            meleeReader.damage = inputDamage.text;

            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Melee/{meleeReader.name}.JSON", meleeReader);

            Weapon weapon = new Weapon(meleeReader);
            createNewEq?.Invoke(weapon);
            ClearInputs();
            gameObject.SetActive(false);
        }
    }
}
