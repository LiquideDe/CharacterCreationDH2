using System;


namespace CharacterCreation
{
    [Serializable]
    public class JSONArmorReader
    {
        public string name, description, descriptionArmor, rarity, typeEquipment;
        public int head, hands, body, legs, maxAgility, armorPoint, amount, bonusStrength;
        public float weight;
    }
}

