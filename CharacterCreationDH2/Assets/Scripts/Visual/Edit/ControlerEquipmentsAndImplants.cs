using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlerEquipmentsAndImplants : MonoBehaviour
{
    private Character character;
    private CreatorEquipment creatorEquipment;
    [SerializeField] ItemInList itemInListExample;
    [SerializeField] Transform contentListEq;
    [SerializeField] CreatorNewEquipment creatorNewEquipment;
    [SerializeField] NewMelee newMelee;
    [SerializeField] NewRange newRange;
    [SerializeField] NewArmor newArmor;
    [SerializeField] NewGrenade newGrenade;
    [SerializeField] PanelWithInputText panelWithInputTextExample;
    [SerializeField] ListWithEquipments listWithEquipmentsExample;

    public void SetParams(Character character, CreatorEquipment creatorEquipment)
    {
        this.character = character;
        this.creatorEquipment = creatorEquipment;

        foreach (Equipment equipment in character.Equipments)
        {
            ItemInList itemInList = Instantiate(itemInListExample, contentListEq);
            itemInList.SetParams(equipment.Name, DeleteEquipment);
        }

        foreach (MechImplants implant in character.Implants)
        {
            ItemInList itemInList = Instantiate(itemInListExample, contentListEq);
            itemInList.SetParams(implant.Name, DeleteImplant);
        }
    }

    public void ShowMeleeWeapon()
    {
        ShowEquipment(newMelee, SearchEquipmentByType(Equipment.TypeEquipment.Melee));
    }

    public void ShowRangeWeapon()
    {
        ShowEquipment(newRange, SearchEquipmentByType(Equipment.TypeEquipment.Range));
    }

    public void ShowArmor()
    {
        ShowEquipment(newArmor, SearchEquipmentByType(Equipment.TypeEquipment.Armor));
    }

    public void ShowEquipmentThing()
    {
        ShowEquipment(creatorNewEquipment, SearchEquipmentByType(Equipment.TypeEquipment.Thing));
    }

    public void ShowGrenade()
    {
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
        listWithEquipments.SetParams(creatorPanelExample, equipments, CreateNewEquipment);
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
        itemInList.SetParams(equipment.Name, DeleteEquipment);

    }
    public void AddNewImplant()
    {
        var panelWithInputText = Instantiate(panelWithInputTextExample, transform);
        panelWithInputText.Init(SetImplant);        
    }

    private void SetImplant(string name)
    {
        character.Implants.Add(new MechImplants(name));
        ItemInList itemInList = Instantiate(itemInListExample, contentListEq);
        itemInList.SetParams(name, DeleteImplant);
    }
    private void DeleteEquipment(string name)
    {
        foreach (Equipment eq in character.Equipments)
        {
            
            if (string.Compare(eq.Name, name, true) == 0)
            {
                character.Equipments.Remove(eq);
                break;
            }
        }
    }

    private void DeleteImplant(string name)
    {
        foreach (MechImplants im in character.Implants)
        {
            if (string.Compare(im.Name, name, true) == 0)
            {
                character.Implants.Remove(im);
                break;
            }
        }
    }
}
