using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArmorOnBody : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textTotalHead, textTotalLeftHand, textTotalRightHand, textTotalBody, textTotalLeftLeg, textTotalRightLeg,
        textArmorHead, textArmorLeftHand, textArmorRightHand, textArmorBody, textArmorLeftLeg, textArmorRightLeg;

    [SerializeField] private RawImage _rawImage;
    private int bonusToughness, _bonusWillpower;
    private int _shieldHead, _shieldBody, _shieldLeftHand, _shieldLegs;
    private int _bonusArmorFromTrait;
    private List<MechImplant> implants = new List<MechImplant>();
    public void SetArmor(Armor armor, List<MechImplant> mechImplants, List<Trait> traits)
    {
        implants = mechImplants;
        FindBonusArmorFromTraits(traits);
        if (armor.TypeEq == Equipment.TypeEquipment.Shield) 
        {
            if (_shieldBody == 0)
                SetShield(armor);
            else if (_shieldBody < armor.DefBody)
                    SetShield(armor);            
        }
        else
        {
            SetBigger(armor.DefHead, textArmorHead, textTotalHead, MechImplant.PartsOfBody.Head);
            SetBigger(armor.DefHands, textArmorLeftHand, textTotalLeftHand, MechImplant.PartsOfBody.LeftHand);
            SetBigger(armor.DefHands, textArmorRightHand, textTotalRightHand, MechImplant.PartsOfBody.RightHand);
            SetBigger(armor.DefBody, textArmorBody, textTotalBody, MechImplant.PartsOfBody.Body);
            SetBigger(armor.DefLegs, textArmorLeftLeg, textTotalLeftLeg, MechImplant.PartsOfBody.LeftLeg);
            SetBigger(armor.DefLegs, textArmorRightLeg, textTotalRightLeg, MechImplant.PartsOfBody.RightLeg);
        }        
    }

    public void SetToughness(int bonusToughness, int bonusWillpower)
    {
        this.bonusToughness = bonusToughness;
        _bonusWillpower = bonusWillpower;
    }

    public void GenerateQr()
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

    private void SetBigger(int armorPoint, TextMeshProUGUI textArmor, TextMeshProUGUI textTotal, MechImplant.PartsOfBody partOfBody)
    {
        
        int armorFromImplant = CalculateArmorFromImplant(partOfBody);
        int additionalBonusToughness = AdditionalBonusToughnessFromImplant(partOfBody);
        int armorFromShield = ArmorPointFromShield(partOfBody);
        if(textArmor.text.Length == 0 && armorPoint > 0)
        {
            textArmor.text = (armorPoint + armorFromImplant + armorFromShield).ToString();
            textTotal.text = (armorPoint + bonusToughness + armorFromImplant + additionalBonusToughness + armorFromShield).ToString();
        }
        else if(textArmor.text.Length == 0 && armorPoint == 0 && armorFromShield == 0)
        {
            textTotal.text = (bonusToughness + additionalBonusToughness).ToString();
        }
        else
        {
            int.TryParse(textArmor.text, out int prevArmor);
            prevArmor -= (CalculateArmorFromImplant(partOfBody)+ armorFromShield);

            if (prevArmor < armorPoint)
            {
                textArmor.text = (armorPoint + armorFromImplant + armorFromShield).ToString();
                textTotal.text = (armorPoint + bonusToughness + armorFromImplant + additionalBonusToughness + armorFromShield).ToString();
            }            
        }
        if(armorPoint == 0 && textArmor.text.Length == 0)
        {
            textArmor.text = (armorFromImplant + armorFromShield).ToString();
            textTotal.text = (bonusToughness + armorFromImplant + additionalBonusToughness + armorFromShield).ToString();
        }
    }

    private int CalculateArmorFromImplant(MechImplant.PartsOfBody partOfBody)
    {
        int addingArmor = 0;
        foreach(MechImplant implant in implants)
        {
            if(implant.Place == partOfBody || implant.Place == MechImplant.PartsOfBody.All)
            {
                addingArmor += implant.Armor;
            }
        }
        return addingArmor;
    }

    private int AdditionalBonusToughnessFromImplant(MechImplant.PartsOfBody partOfBody)
    {
        int addingToughness = 0;
        foreach (MechImplant implant in implants)
        {
            if (implant.Place == partOfBody || implant.Place == MechImplant.PartsOfBody.All)
            {
                addingToughness += implant.BonusToughness;
            }
        }
        return addingToughness;
    }

    private void SetShield(Armor armor)
    {
        _shieldHead = armor.DefHead;
        _shieldBody = armor.DefBody;
        _shieldLeftHand = armor.DefHands;
        _shieldLegs = armor.DefLegs;
    }

    private int ArmorPointFromShield(MechImplant.PartsOfBody partOfBody)
    {
        switch (partOfBody)
        {
            case MechImplant.PartsOfBody.Head:
                return _shieldHead;

            case MechImplant.PartsOfBody.Body:
                return _shieldBody;

            case MechImplant.PartsOfBody.LeftHand:
                return _shieldLeftHand;

            case MechImplant.PartsOfBody.RightLeg:
                return _shieldLegs;

            case MechImplant.PartsOfBody.LeftLeg:
                return _shieldLegs;

            default:
                return 0;
        }
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
}
