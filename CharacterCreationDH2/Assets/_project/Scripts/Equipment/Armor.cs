using System;

namespace CharacterCreation
{
    public class Armor : Equipment, ISerializableEquipment
    {
        private int defHead, defHands, defBody, defLegs, maxAgil, armorPoint, bonusStrength;
        private string placeArmor;
        public Armor(JSONArmorReader armorReader) : base(armorReader.name, armorReader.description, armorReader.rarity, armorReader.amount, armorReader.weight)
        {
            Enum.TryParse(armorReader.typeEquipment, true, out TypeEquipment equipmentType);
            typeEquipment = equipmentType;
            defHead = armorReader.head;
            defHands = armorReader.hands;
            defBody = armorReader.body;
            defLegs = armorReader.legs;
            maxAgil = armorReader.maxAgility;
            placeArmor = armorReader.descriptionArmor;
            armorPoint = armorReader.armorPoint;
            bonusStrength = armorReader.bonusStrength;
        }

        public Armor(Armor armor) : base(armor.Name, armor.Description, armor.Rarity, armor.Amount, armor.Weight)
        {
            typeEquipment = armor.typeEquipment;
            defHead = armor.DefHead;
            defHands = armor.DefHands;
            defBody = armor.DefBody;
            defLegs = armor.DefLegs;
            maxAgil = armor.MaxAgil;
            placeArmor = armor.PlaceArmor;
            armorPoint = armor.ArmorPoint;
            bonusStrength = armor.BonusStrength;
        }

        public int DefHead => defHead;
        public int DefHands => defHands;
        public int DefBody => defBody;
        public int DefLegs => defLegs;
        public int MaxAgil => maxAgil;
        public string PlaceArmor => placeArmor;
        public int ArmorPoint => armorPoint;

        public int BonusStrength => bonusStrength;

        public override object ToJsonReader()
        {
            return new JSONArmorReader
            {
                amount = Amount,
                armorPoint = ArmorPoint,
                body = DefBody,
                description = Description,
                descriptionArmor = PlaceArmor,
                hands = DefHands,
                head = DefHead,
                legs = DefLegs,
                maxAgility = MaxAgil,
                name = Name,
                typeEquipment = TypeEq.ToString(),
                weight = Weight,
                bonusStrength = BonusStrength,
                rarity = Rarity
            };
        }
    }
}

