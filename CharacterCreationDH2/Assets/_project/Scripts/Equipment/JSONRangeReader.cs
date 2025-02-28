using System;

namespace CharacterCreation
{
    [Serializable]
    public class JSONRangeReader
    {
        public string name, description, weaponClass, rof, damage, reload, properties, rarity, typeEquipment;
        public int range, penetration, clip, amount, typeSound;
        public float weight;
    }
}


