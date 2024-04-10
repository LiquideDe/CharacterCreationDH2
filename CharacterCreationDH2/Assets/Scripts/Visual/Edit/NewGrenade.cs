using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrenade : NewMelee
{
    public new void FinishCreating()
    {
        if (inputName.text != "" && inputClass.text.Length > 0 && inputPenetration.text.Length > 0 && inputWeight.text.Length > 0)
        {
            audioWork.PlayDone();
            float.TryParse(inputWeight.text, out weight);
            int.TryParse(inputPenetration.text, out int penetration);
            JSONGrenadeReader grenadeReader = new JSONGrenadeReader();
            grenadeReader.name = inputName.text;
            grenadeReader.penetration = penetration;
            grenadeReader.properties = MakePropertiesText();
            grenadeReader.weaponClass = inputClass.text;
            grenadeReader.weight = weight;
            grenadeReader.damage = MakeDamageText();
            grenadeReader.typeEquipment = Equipment.TypeEquipment.Grenade.ToString();
            grenadeReader.amount = 1;

            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Grenade/{grenadeReader.name}.JSON", grenadeReader);

            Weapon weapon = new Weapon(grenadeReader);
            createNewEq?.Invoke(weapon);
            Destroy(gameObject);
        }
        else
        {
            audioWork.PlayWarning();
        }
    }
}
