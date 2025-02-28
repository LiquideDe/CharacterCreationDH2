using System;

namespace CharacterCreation
{
    [Serializable]
    public class JSONGrenadeReader
    {
        public string name, description, damage, rarity, weaponClass, properties, typeEquipment;
        public int penetration, amount;
        public float weight;
    }
}