using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArmorOnBody : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textTotalHead, textTotalLeftHand, textTotalRightHand, textTotalBody, textTotalLeftLeg, textTotalRightLeg,
        textArmorHead, textArmorLeftHand, textArmorRightHand, textArmorBody, textArmorLeftLeg, textArmorRightLeg;
    int bonusToughness;
    public void SetArmor(Armor armor)
    {
        SetBigger(armor.DefHead, textArmorHead, textTotalHead);
        SetBigger(armor.DefHands, textArmorLeftHand, textTotalLeftHand);
        SetBigger(armor.DefHands, textArmorRightHand, textTotalRightHand);
        SetBigger(armor.DefBody, textArmorBody, textTotalBody);
        SetBigger(armor.DefLegs, textArmorLeftLeg, textTotalLeftLeg);
        SetBigger(armor.DefLegs, textArmorRightLeg, textTotalRightLeg);
    }

    public void SetToughness(int bonusToughness)
    {
        this.bonusToughness = bonusToughness;
    }

    private void SetBigger(int armorPoint, TextMeshProUGUI textArmor, TextMeshProUGUI textTotal)
    {
        if(textArmor.text == "" && armorPoint > 0)
        {
            textArmor.text = armorPoint.ToString();
            textTotal.text = (armorPoint + bonusToughness).ToString();
        }
        else if(textArmor.text == "" && armorPoint == 0)
        {
            textTotal.text = bonusToughness.ToString();
        }
        else
        {
            int prevArmor;
            int.TryParse(textArmor.text, out prevArmor);
            if(prevArmor < armorPoint)
            {
                textArmor.text = armorPoint.ToString();
                textTotal.text = (armorPoint + bonusToughness).ToString();
            }
        }
    }
}
