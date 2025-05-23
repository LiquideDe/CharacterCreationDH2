﻿
namespace CharacterCreation
{
    public class Equipment : INameWithDescription, ISerializableEquipment
    {
        private string _nameEquipment, _description, _rarity;
        private float _weight;
        private int _amount;
        public enum TypeEquipment
        {
            Thing, Melee, Range, Armor, Special, Grenade, Shield
        }
        protected TypeEquipment typeEquipment;
        public Equipment(string nameEquipment, string description, string rarity, int amount = 1, float weight = 0)
        {
            _nameEquipment = nameEquipment;
            _description = description;
            typeEquipment = TypeEquipment.Thing;
            _weight = weight;
            _rarity = rarity;
            _amount = amount;
        }

        public Equipment(JSONEquipmentReader reader)
        {
            _nameEquipment = reader.name;
            _description = reader.description;
            typeEquipment = TypeEquipment.Thing;
            _weight = reader.weight;
            _rarity = reader.rarity;
            _amount = reader.amount;
        }

        public Equipment(Equipment equipment)
        {
            _nameEquipment = equipment.Name;
            _description = equipment.Description;
            _rarity = equipment.Rarity;
            _weight = equipment.Weight;
            _amount = equipment.Amount;
            typeEquipment = equipment.TypeEq;
        }

        public string NameWithAmount => GetName();
        public string Name => _nameEquipment;

        public string Description => _description;
        public TypeEquipment TypeEq => typeEquipment;
        public float Weight => _weight;
        public string Rarity => _rarity;
        public int Amount { get => _amount; set => _amount = value; }

        public virtual object ToJsonReader()
        {
            return new JSONEquipmentReader
            {
                amount = Amount,
                description = Description,
                name = Name,
                rarity = Rarity,
                typeEquipment = TypeEq.ToString(),
                weight = Weight
            };
        }

        private string GetName()
        {
            if (_amount < 2)
            {
                return _nameEquipment;
            }

            return $"{_nameEquipment}-{_amount} шт.";
        }
    }
}

