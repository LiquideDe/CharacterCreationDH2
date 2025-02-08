using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ArmorOnBody : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textTotalHead, textTotalLeftHand, textTotalRightHand, textTotalBody, textTotalLeftLeg, textTotalRightLeg,
        textArmorHead, textArmorLeftHand, textArmorRightHand, textArmorBody, textArmorLeftLeg, textArmorRightLeg;

    [SerializeField] private RawImage _rawImage;
    private int _bonusToughness, _bonusWillpower;
    private int _bestShieldHead, _bestShieldBody, _bestShieldLeftHand, _bestShieldLegs;
    private int _bonusArmorFromTrait;
    private int _bonusArmorFromImplantHead, _bonusArmorFromImplantBody, _bonusArmorFromImplantRightHand, _bonusArmorFromImplantLeftHand, _bonusArmorFromImplantRightLeg, _bonusArmorFromImplantLeftLeg;
    private int _bonusToughnessFromImplantHead, _bonusToughnessFromImplantBody, _bonusToughnessFromImplantRightHand, _bonusToughnessFromImplantLeftHand, _bonusToughnessFromImplantRightLeg, _bonusToughnessFromImplantLeftLeg;
    private int _bestArmorHead, _bestArmorBody, _bestArmorHands, _bestArmorLegs;
    private int _bonusToughnessFromTrait;
    
    public void SetArmor(ICharacter character)
    {
        _bonusToughness = character.Characteristics[GameStat.CharacteristicToInt["Выносливость"]].Amount / 10;
        _bonusWillpower = character.Characteristics[GameStat.CharacteristicToInt["Сила Воли"]].Amount / 10;
        CalculateArmorAndToughnessFromImplant(character.Implants);

        foreach (var item in character.Equipments)
        {
            if (item.TypeEq == Equipment.TypeEquipment.Armor)
                SetArmor(item);
            else if(item.TypeEq == Equipment.TypeEquipment.Shield)
                SetShield(item);
        }

        FindBonusArmorFromTraits(character.Traits);
        FindBonusToughnessFromTraits(character.Traits);
        FillTexts();
    }       

    private void CalculateArmorAndToughnessFromImplant(List<MechImplant> implants)
    {
        foreach(MechImplant implant in implants)
        {
            if(implant.Place == MechImplant.PartsOfBody.Head)
            {
                _bonusArmorFromImplantHead += implant.Armor;
                _bonusToughnessFromImplantHead += implant.BonusToughness;
            }

            else if(implant.Place == MechImplant.PartsOfBody.Body)
            {
                _bonusArmorFromImplantBody += implant.Armor;
                _bonusToughnessFromImplantBody += implant.BonusToughness;
            }

            else if(implant.Place == MechImplant.PartsOfBody.RightHand)
            {
                _bonusArmorFromImplantRightHand += implant.Armor;
                _bonusToughnessFromImplantRightHand += implant.BonusToughness;
            }

            else if (implant.Place == MechImplant.PartsOfBody.LeftHand)
            {
                _bonusArmorFromImplantLeftHand += implant.Armor;
                _bonusToughnessFromImplantLeftHand += implant.BonusToughness;
            }

            else if (implant.Place == MechImplant.PartsOfBody.RightLeg)
            {
                _bonusArmorFromImplantRightLeg += implant.Armor;
                _bonusToughnessFromImplantRightLeg += implant.BonusToughness;
            }

            else if (implant.Place == MechImplant.PartsOfBody.LeftLeg)
            {
                _bonusArmorFromImplantLeftLeg += implant.Armor;
                _bonusToughnessFromImplantLeftLeg += implant.BonusToughness;
            }

            else if(implant.Place == MechImplant.PartsOfBody.All)
            {
                _bonusArmorFromImplantHead += implant.Armor;
                _bonusToughnessFromImplantHead += implant.BonusToughness;
                _bonusArmorFromImplantBody += implant.Armor;
                _bonusToughnessFromImplantBody += implant.BonusToughness;
                _bonusArmorFromImplantRightHand += implant.Armor;
                _bonusToughnessFromImplantRightHand += implant.BonusToughness;
                _bonusArmorFromImplantLeftHand += implant.Armor;
                _bonusToughnessFromImplantLeftHand += implant.BonusToughness;
                _bonusArmorFromImplantRightLeg += implant.Armor;
                _bonusToughnessFromImplantRightLeg += implant.BonusToughness;
                _bonusArmorFromImplantLeftLeg += implant.Armor;
                _bonusToughnessFromImplantLeftLeg += implant.BonusToughness;
            }
        }
    }

    private void SetShield(Equipment equipment)
    {
        Armor armor = (Armor)equipment;
        if(armor.DefBody > _bestShieldBody)
        {
            _bestShieldHead = armor.DefHead;
            _bestShieldBody = armor.DefBody;
            _bestShieldLeftHand = armor.DefHands;
            _bestShieldLegs = armor.DefLegs;
        }
    }

    private void SetArmor(Equipment equipment)
    {
        Armor armor = (Armor)equipment;
        if(armor.DefHead > _bestArmorHead)
            _bestArmorHead = armor.DefHead;

        if(armor.DefHands > _bestArmorHands)
            _bestArmorHands = armor.DefHands;

        if(armor.DefBody > _bestArmorBody)
            _bestArmorBody = armor.DefBody;

        if(armor.DefLegs > _bestArmorLegs)
            _bestArmorLegs = armor.DefLegs;
    }


    private void FindBonusArmorFromTraits(List<Trait> traits)
    {
        foreach (var item in traits)
        {
            if (string.Compare(item.Name, "Машина", true) == 0)
                _bonusArmorFromTrait += item.Lvl;
            else if (string.Compare(item.Name, "Природная броня", true) == 0)
                _bonusArmorFromTrait += item.Lvl;
        }
    }

    private void FindBonusToughnessFromTraits(List<Trait> traits)
    {
        foreach (var item in traits)
        {
            if(string.Compare(item.Name, "Сверхъестественная Выносливость", true) == 0)
                _bonusToughnessFromTrait += item.Lvl;
            else if(string.Compare(item.Name, "Демонический", true) == 0)
                _bonusToughnessFromTrait += item.Lvl;
        }
    }

    private void FillTexts()
    {
        int armor = _bestShieldHead + _bonusArmorFromTrait + _bonusArmorFromImplantHead + _bestArmorHead;
        int toughnessPlusArmor = armor + _bonusToughness + _bonusToughnessFromImplantHead + _bonusToughnessFromTrait;
        textArmorHead.text = $"{armor}";
        textTotalHead.text = $"{toughnessPlusArmor}";

        armor = _bestShieldBody + _bonusArmorFromTrait + _bonusArmorFromImplantBody + _bestArmorBody;
        toughnessPlusArmor = armor + _bonusToughness + _bonusToughnessFromImplantBody + _bonusToughnessFromTrait;
        textArmorBody.text = $"{armor}";
        textTotalBody.text = $"{toughnessPlusArmor}";

        armor = _bonusArmorFromTrait + _bonusArmorFromImplantRightHand + _bestArmorHands;
        toughnessPlusArmor = armor + _bonusToughness + _bonusToughnessFromImplantRightHand + _bonusToughnessFromTrait;
        textArmorRightHand.text = $"{armor}";
        textTotalRightHand.text = $"{toughnessPlusArmor}";

        armor = _bestShieldLeftHand + _bonusArmorFromTrait + _bonusArmorFromImplantLeftHand + _bestArmorHands;
        toughnessPlusArmor = armor + _bonusToughness + _bonusToughnessFromImplantLeftHand + _bonusToughnessFromTrait;
        textArmorLeftHand.text = $"{armor}";
        textTotalLeftHand.text = $"{toughnessPlusArmor}";

        armor = _bestShieldLegs + _bonusArmorFromTrait + _bonusArmorFromImplantRightLeg + _bestArmorLegs;
        toughnessPlusArmor = armor + _bonusToughness + _bonusToughnessFromImplantRightLeg + _bonusToughnessFromTrait;
        textArmorRightLeg.text = $"{armor}";
        textTotalRightLeg.text = $"{toughnessPlusArmor}";

        armor = _bestShieldLegs + _bonusArmorFromTrait + _bonusArmorFromImplantLeftLeg + _bestArmorLegs;
        toughnessPlusArmor = armor + _bonusToughness + _bonusToughnessFromImplantLeftLeg + _bonusToughnessFromTrait;
        textArmorLeftLeg.text = $"{armor}";
        textTotalLeftLeg.text = $"{toughnessPlusArmor}";

        GenerateQr();
    }

    private void GenerateQr()
    {
        //Пример бонус вынослоивости = 4, бонус СВ = 3, броня Легкий панцирь.
        //A/3/0/4/6/10/4/8/4/8/4/8/4/8
        //A - Armor/3 - бонус СВ/Броня голова/Общая броня головы/Броня тела/Общая броня тела/Броня правой руки/Общая броня правой руки/Броня левой руки/Общая броня левой руки/Броня правой ноги/Общая броня правой ноги/Броня левой ноги/Общая броня левой ноги
        string textToCode = $"A/{_bonusWillpower}/{textArmorHead.text}/{textTotalHead.text}/" +
            $"{textArmorBody.text}/{textTotalBody.text}/" +
            $"{textArmorRightHand.text}/{textTotalRightHand.text}/" +
            $"{textArmorLeftHand.text}/{textTotalLeftHand.text}/" +
            $"{textArmorRightLeg.text}/{textTotalRightLeg.text}/" +
            $"{textArmorLeftLeg.text}/{textTotalLeftLeg.text}";

        _rawImage.texture = new GeneratorQRCode().EncodeTextToQrCode(textToCode);
    }
}
