using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlerEquipmentsAndImplants : MonoBehaviour
{
    private Character character;
    private CreatorEquipment creatorEquipment;
    private CreatorImplant creatorImplant;
    [SerializeField] ItemWithAmount itemInListExample;
    [SerializeField] Transform contentListEq;
    [SerializeField] CreatorNewEquipment creatorNewEquipment;
    [SerializeField] NewMelee newMelee;
    [SerializeField] NewRange newRange;
    [SerializeField] NewArmor newArmor;
    [SerializeField] NewGrenade newGrenade;
    [SerializeField] PanelWithInputText panelWithInputTextExample;
    [SerializeField] ListWithEquipments listWithEquipmentsExample;
    [SerializeField] ListWithImplants listWithImplantsExample;
    AudioWork audioWork;

    public void SetParams(Character character, CreatorEquipment creatorEquipment, CreatorImplant creatorImplant, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        this.character = character;
        this.creatorEquipment = creatorEquipment;
        this.creatorImplant = creatorImplant;

        foreach (Equipment equipment in character.Equipments)
        {
            ItemWithAmount itemInList = Instantiate(itemInListExample, contentListEq);
            itemInList.SetParams(equipment.Name, DeleteEquipment, audioWork);
            itemInList.SetAmountAndDelegate(equipment.Amount, ChangeAmount);
        }

        foreach (MechImplant implant in character.Implants)
        {
            ItemInList itemInList = Instantiate(itemInListExample, contentListEq);
            itemInList.SetParams(implant.Name, DeleteImplant, audioWork);
        }
    }

    private void ChangeAmount(string name, int amount)
    {
        audioWork.PlayClick();
        foreach (Equipment eq in character.Equipments)
        {
            if (string.Compare(eq.Name, name, true) == 0)
            {
                eq.Amount = amount;
                break;
            }
        }
    }

    public void ShowMeleeWeapon()
    {
        audioWork.PlayClick();
        ShowEquipment(newMelee, SearchEquipmentByType(Equipment.TypeEquipment.Melee));
    }

    public void ShowRangeWeapon()
    {
        audioWork.PlayClick();
        ShowEquipment(newRange, SearchEquipmentByType(Equipment.TypeEquipment.Range));
    }

    public void ShowArmor()
    {
        audioWork.PlayClick();
        ShowEquipment(newArmor, SearchEquipmentByType(Equipment.TypeEquipment.Armor));
    }

    public void ShowEquipmentThing()
    {
        audioWork.PlayClick();
        ShowEquipment(creatorNewEquipment, SearchEquipmentByType(Equipment.TypeEquipment.Thing));
    }

    public void ShowGrenade()
    {
        audioWork.PlayClick();
        ShowEquipment(newGrenade, SearchEquipmentByType(Equipment.TypeEquipment.Grenade));
    }

    private List<Equipment> SearchEquipmentByType(Equipment.TypeEquipment type)
    {
        List<Equipment> equipments = new List<Equipment>();
        foreach (Equipment equipment in creatorEquipment.Equipments)
        {
            if (equipment.TypeEq == type)
            {
                equipments.Add(equipment);
            }
        }
        return equipments;
    }
    private void ShowEquipment(CreatorNewEquipment creatorPanelExample, List<Equipment> equipments)
    {
        var listWithEquipments = Instantiate(listWithEquipmentsExample, transform);
        listWithEquipments.SetParams(creatorPanelExample, equipments, CreateNewEquipment,audioWork);
    }

    private void CreateNewEquipment(Equipment equipment)
    {
        int sch = 0;
        foreach(Equipment eq in creatorEquipment.Equipments)
        {
            if(eq == equipment)
            {
                sch++;
                break;
            }
        }

        if(sch < 1)
        {
            creatorEquipment.Equipments.Add(equipment);
        }
        character.Equipments.Add(equipment);
        ItemInList itemInList = Instantiate(itemInListExample, contentListEq);
        itemInList.SetParams(equipment.Name, DeleteEquipment, audioWork);

    }
    public void ShowImplants()
    {
        audioWork.PlayClick();
        Canvas canvas = GetComponentInParent<Canvas>();
        var ListWithImplants = Instantiate(listWithImplantsExample, canvas.transform);
        ListWithImplants.SetParams(creatorImplant.Implants, SetImplant, audioWork);
    }

    private void SetImplant(MechImplant mechImplant)
    {
        character.Implants.Add(mechImplant);
        ItemInList itemInList = Instantiate(itemInListExample, contentListEq);
        itemInList.SetParams(mechImplant.Name, DeleteImplant, audioWork);
    }
    private void DeleteEquipment(string name)
    {
        foreach (Equipment eq in character.Equipments)
        {
            
            if (string.Compare(eq.Name, name, true) == 0)
            {
                audioWork.PlayCancel();
                character.Equipments.Remove(eq);
                break;
            }
        }
    }

    private void DeleteImplant(string name)
    {
        foreach (MechImplant im in character.Implants)
        {
            if (string.Compare(im.Name, name, true) == 0)
            {
                audioWork.PlayCancel();
                character.Implants.Remove(im);
                break;
            }
        }
    }
    
}
