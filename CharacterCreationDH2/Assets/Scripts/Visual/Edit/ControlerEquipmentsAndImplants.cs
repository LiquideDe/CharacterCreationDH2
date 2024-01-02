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
    [SerializeField] ItemListActiveButton itemListActiveButton;
    [SerializeField] TMP_InputField inputImplantname;
    [SerializeField] Transform contentListEq, contentNewEq;
    [SerializeField] GameObject listNewEq;
    [SerializeField] Button buttonNewEq;
    [SerializeField] CreatorNewEquipment creatorNewEquipment;
    [SerializeField] NewMelee newMelee;
    [SerializeField] NewRange newRange;
    [SerializeField] NewArmor newArmor;
    private List<ItemListActiveButton> listItems = new List<ItemListActiveButton>();

    private void Start()
    {
        creatorNewEquipment.RegDelegate(CreateNewEquipment);
        newMelee.RegDelegate(CreateNewEquipment);
        newRange.RegDelegate(CreateNewEquipment);
        newArmor.RegDelegate(CreateNewEquipment);
    }
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
        buttonNewEq.onClick.RemoveAllListeners();
        ShowEquipment(Equipment.TypeEquipment.Melee);
        buttonNewEq.onClick.AddListener(ShowMeleeCreator);
    }

    public void ShowRangeWeapon()
    {
        buttonNewEq.onClick.RemoveAllListeners();
        ShowEquipment(Equipment.TypeEquipment.Range);
        buttonNewEq.onClick.AddListener(ShowRangeCreator);
    }

    public void ShowArmor()
    {
        buttonNewEq.onClick.RemoveAllListeners();
        ShowEquipment(Equipment.TypeEquipment.Armor);
        buttonNewEq.onClick.AddListener(ShowArmorCreator);
    }

    public void ShowEquipmentThing()
    {
        buttonNewEq.onClick.RemoveAllListeners();
        ShowEquipment(Equipment.TypeEquipment.Thing);
        buttonNewEq.onClick.AddListener(ShowThingCreator);
    }

    private void ShowEquipment(Equipment.TypeEquipment type)
    {
        Debug.Log($"Срабатываем");
        CleanListNewEq();
        listNewEq.gameObject.SetActive(true);
        foreach (Equipment equipment in creatorEquipment.Equipments)
        {
            if (equipment.TypeEq == type)
            {
                listItems.Add(Instantiate(itemListActiveButton, contentNewEq));
                listItems[^1].SetParams(equipment.Name, GetNewEquipment);
            }
        }
    }

    private void CreateNewEquipment(Equipment equipment)
    {
        creatorEquipment.AddEquipment(equipment);
        GetNewEquipment(equipment.Name);
    }
    public void CreateNewImplant()
    {
        character.Implants.Add(new MechImplants(inputImplantname.text));
        ItemInList itemInList = Instantiate(itemInListExample, contentListEq);
        itemInList.SetParams(inputImplantname.text, DeleteImplant);
        inputImplantname.text = "";
    }
    private void CleanListNewEq()
    {
        if (listItems.Count > 0)
        {
            foreach (ItemListActiveButton item in listItems)
            {
                Destroy(item.gameObject);
            }
            listItems.Clear();
        }
    }

    private void GetNewEquipment(string name)
    {
        character.Equipments.Add(creatorEquipment.GetEquipment(name));
        ItemInList itemInList = Instantiate(itemInListExample, contentListEq);
        itemInList.SetParams(name, DeleteEquipment);
    }

    private void ShowMeleeCreator()
    {
        newMelee.gameObject.SetActive(true);
    }

    private void ShowRangeCreator()
    {
        newRange.gameObject.SetActive(true);
    }

    private void ShowThingCreator()
    {
        creatorNewEquipment.gameObject.SetActive(true);
    }

    private void ShowArmorCreator()
    {
        newArmor.gameObject.SetActive(true);
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
