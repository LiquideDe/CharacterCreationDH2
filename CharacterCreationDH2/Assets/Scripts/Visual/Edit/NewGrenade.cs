using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrenade : NewMelee
{
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
            JSONGrenadeReader grenadeReader = new JSONGrenadeReader();
            grenadeReader.name = inputName.text;
            grenadeReader.penetration = penetration;
            grenadeReader.properties = inputProperty.text;
            grenadeReader.weaponClass = inputClass.text;
            grenadeReader.weight = weight;
            grenadeReader.damage = inputDamage.text;

            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Grenade/{grenadeReader.name}.JSON", grenadeReader);

            Weapon weapon = new Weapon(grenadeReader);
            createNewEq?.Invoke(weapon);
            ClearInputs();
            gameObject.SetActive(false);
        }
    }
}
