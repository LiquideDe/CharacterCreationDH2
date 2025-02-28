using UnityEngine;

namespace CharacterCreation
{
    public class NewGrenade : NewMelee
    {
        public override void FinishCreating()
        {
            if (_inputName.text != "" && inputClass.text.Length > 0 && inputPenetration.text.Length > 0 && _inputWeight.text.Length > 0)
            {
                float.TryParse(_inputWeight.text, out float weight);
                int.TryParse(inputPenetration.text, out int penetration);
                JSONGrenadeReader grenadeReader = new JSONGrenadeReader
                {
                    name = _inputName.text,
                    penetration = penetration,
                    properties = TranslatePropertiesToText(),
                    weaponClass = inputClass.text,
                    weight = weight,
                    damage = MakeDamageText(),
                    typeEquipment = Equipment.TypeEquipment.Grenade.ToString(),
                    amount = 1,
                    description = _inputDescription.text
                };

                SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Grenade/{grenadeReader.name}.JSON", grenadeReader);

                Weapon weapon = new Weapon(grenadeReader);
                SendEquipment(weapon);
                Destroy(gameObject);
            }
            else
                WrongInputPressed();
        }
    }
}

