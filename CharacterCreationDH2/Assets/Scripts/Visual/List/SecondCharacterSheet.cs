using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondCharacterSheet : TakeScreenshot
{
    [SerializeField] TextMeshProUGUI textWound, textEquipments, textExpTotal, textExpUnspent, textExpSpent, textMoveHalf, textMoveFull, textNatisk, textRun, 
        textFatigue, textWeight, textWeightUp, textWeightPush, textBonus, textPsyRate, textPsyPowers, textEquipmentWeight;
    [SerializeField] WeaponBlock[] weaponBlocks;
    [SerializeField] ArmorBlock[] armorBlocks;
    [SerializeField] ArmorOnBody onBody;

    public void OpenSecondSheet(Character character)
    {
        gameObject.SetActive(true);
        this.character = character;
        onBody.SetToughness(character.Characteristics[3].Amount/10);
        textWound.text = character.Wounds.ToString();
        foreach(Equipment eq in character.Equipments)
        {
            textEquipments.text += eq.Name + "\n";
            textEquipmentWeight.text += eq.Weight + "\n";
        }
        textExpTotal.text = character.ExperienceTotal.ToString();
        textExpSpent.text = character.ExperienceSpent.ToString();
        textExpUnspent.text = character.ExperienceUnspent.ToString();
        textMoveHalf.text = character.HalfMove.ToString();
        textMoveFull.text = character.FullMove.ToString();
        textNatisk.text = character.Natisk.ToString();
        textRun.text = character.Run.ToString();
        textFatigue.text = character.Fatigue.ToString();
        textWeight.text = character.CarryWeight.ToString();
        textWeightPush.text = character.PushWeight.ToString();
        textWeightUp.text = character.LiftWeight.ToString();
        textBonus.text = character.BonusBack;
        foreach(Equipment equipment in character.Equipments)
        {
            if(equipment.TypeEq == Equipment.TypeEquipment.Melee || equipment.TypeEq == Equipment.TypeEquipment.Range)
            {
                foreach (WeaponBlock block in weaponBlocks)
                {
                    if (block.IsEmpty)
                    {
                        Weapon weapon = (Weapon)equipment;
                        block.FillBlock(weapon);
                        break;
                    }
                }
            }
            else if (equipment.TypeEq == Equipment.TypeEquipment.Armor)
            {
                foreach (ArmorBlock armorBlock in armorBlocks)
                {
                    if (armorBlock.IsEmpty)
                    {
                        Armor armor = (Armor)equipment;
                        armorBlock.FillBlock(armor);
                        break;
                    }
                }
            }
        }

        foreach(MechImplants implant in character.Implants)
        {
            textEquipments.text += implant.Name + "\n";
        }

        if(character.PsyRating > 0)
        {
            textPsyRate.text = character.PsyRating.ToString();

            foreach(PsyPower psyPower in character.PsyPowers)
            {
                textPsyPowers.text += psyPower.NamePower + "\n";
            }
        }
        else
        {
            textPsyRate.text = "";
        }
        StartScreenshot();

    }

    
}
