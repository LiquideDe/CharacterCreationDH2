using UnityEngine;

public class NewGrenade : NewMelee
{
    public override void FinishCreating()
    {
        if (_inputName.text != "" && inputClass.text.Length > 0 && inputPenetration.text.Length > 0 && _inputWeight.text.Length > 0)
        {
            float.TryParse(_inputWeight.text, out float weight);
            int.TryParse(inputPenetration.text, out int penetration);
            JSONGrenadeReader grenadeReader = new JSONGrenadeReader();
            grenadeReader.name = _inputName.text;
            grenadeReader.penetration = penetration;
            grenadeReader.properties = TranslatePropertiesToText();
            grenadeReader.weaponClass = inputClass.text;
            grenadeReader.weight = weight;
            grenadeReader.damage = MakeDamageText();
            grenadeReader.typeEquipment = Equipment.TypeEquipment.Grenade.ToString();
            grenadeReader.amount = 1;

            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Grenade/{grenadeReader.name}.JSON", grenadeReader);

            Weapon weapon = new Weapon(grenadeReader);
            SendEquipment(weapon);
            Destroy(gameObject);
        }
        else
            WrongInputPressed();
    }
}
