﻿
using System;

namespace CharacterCreation
{
    public class Weapon : Equipment, ISerializableEquipment
    {
        private string classWeapon, rof, damage, reload, properties;
        private int range, penetration, clip, typeSound;

        public Weapon(JSONRangeReader rangeReader) : base(rangeReader.name, rangeReader.description, rangeReader.rarity, rangeReader.amount, rangeReader.weight)
        {
            typeEquipment = TypeEquipment.Range;
            classWeapon = rangeReader.weaponClass;
            range = rangeReader.range;
            rof = rangeReader.rof;
            damage = rangeReader.damage;
            penetration = rangeReader.penetration;
            clip = rangeReader.clip;
            reload = rangeReader.reload;
            properties = rangeReader.properties;
            typeSound = rangeReader.typeSound;
        }

        public Weapon(JSONMeleeReader meleeReader) : base(meleeReader.name, meleeReader.description, meleeReader.rarity, meleeReader.amount, meleeReader.weight)
        {
            typeEquipment = TypeEquipment.Melee;
            classWeapon = meleeReader.weaponClass;
            damage = meleeReader.damage;
            penetration = meleeReader.penetration;
            properties = meleeReader.properties;
            rof = "";
        }

        public Weapon(JSONGrenadeReader grenadeReader) : base(grenadeReader.name, grenadeReader.description, grenadeReader.rarity, grenadeReader.amount, grenadeReader.weight)
        {
            typeEquipment = TypeEquipment.Grenade;
            classWeapon = grenadeReader.weaponClass;
            damage = grenadeReader.damage;
            penetration = grenadeReader.penetration;
            properties = grenadeReader.properties;
            rof = "";
        }

        public Weapon(Weapon weapon) : base(weapon.Name, weapon.Description, weapon.Rarity, weapon.Amount, weapon.Weight)
        {
            typeEquipment = weapon.TypeEq;
            classWeapon = weapon.ClassWeapon;
            range = weapon.Range;
            rof = weapon.Rof;
            damage = weapon.Damage;
            penetration = weapon.Penetration;
            clip = weapon.Clip;
            reload = weapon.Reload;
            properties = weapon.Properties;
            typeSound = weapon.TypeSound;
        }

        public string ClassWeapon { get => classWeapon; }
        public int Range { get => range; }
        public string Rof { get => rof; }
        public string Damage { get => damage; }
        public int Penetration { get => penetration; }
        public int Clip { get => clip; }
        public string Reload { get => reload; }
        public string Properties { get => properties; }
        public int TypeSound => typeSound;

        public override object ToJsonReader()
        {
            switch (TypeEq)
            {
                case TypeEquipment.Melee:
                    return new JSONMeleeReader
                    {
                        amount = Amount,
                        damage = Damage,
                        description = Description,
                        name = Name,
                        penetration = Penetration,
                        properties = Properties,
                        rarity = Rarity,
                        typeEquipment = TypeEq.ToString(),
                        weaponClass = ClassWeapon,
                        weight = Weight
                    };

                case TypeEquipment.Range:
                    return new JSONRangeReader
                    {
                        amount = Amount,
                        damage = Damage,
                        description = Description,
                        name = Name,
                        penetration = Penetration,
                        properties = Properties,
                        rarity = Rarity,
                        typeEquipment = TypeEq.ToString(),
                        weaponClass = ClassWeapon,
                        weight = Weight,
                        clip = Clip,
                        range = Range,
                        reload = Reload,
                        rof = Rof,
                        typeSound = TypeSound
                    };

                case TypeEquipment.Grenade:
                    return new JSONGrenadeReader
                    {
                        amount = Amount,
                        damage = Damage,
                        description = Description,
                        name = Name,
                        penetration = Penetration,
                        properties = Properties,
                        rarity = Rarity,
                        typeEquipment = TypeEq.ToString(),
                        weaponClass = ClassWeapon,
                        weight = Weight
                    };

                default:
                    throw new NotSupportedException($"Unsupported weapon type: {TypeEq}");
            }
        }
    }
}

