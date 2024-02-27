using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListWithEquipments : MonoBehaviour
{
    CreatorNewEquipment newEquipment;
    [SerializeField] Transform content;
    [SerializeField] ItemListActiveButton itemExample;
    public delegate void ReturnEquipment(Equipment equipment);
    ReturnEquipment returnEquipment;
    private List<Equipment> equipments = new List<Equipment>();
    private List<ItemListActiveButton> activeButtons = new List<ItemListActiveButton>();

    public void SetParams(CreatorNewEquipment newEquipment, List<Equipment> equipments, ReturnEquipment returnEquipment)
    {
        gameObject.SetActive(true);
        this.equipments = equipments;
        this.returnEquipment = returnEquipment;
        this.newEquipment = newEquipment;
        foreach(Equipment equipment in equipments)
        {
            activeButtons.Add(Instantiate(itemExample, content));
            activeButtons[^1].SetParams(equipment.Name, FinishChoose);
        }
    }

    private void FinishChoose(string name)
    {
        foreach(Equipment equipment in equipments)
        {
            if(string.Compare(equipment.Name, name, true)==0)
            {
                returnEquipment?.Invoke(equipment);
                break;
            }
        }
    }

    public void Cancel()
    {
        Destroy(gameObject);
    }

    public void CreateNewEquipment()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        CreatorNewEquipment newEq = Instantiate(newEquipment, canvas.transform);
        newEq.RegDelegate(ReturnNewEquipment);
    }

    private void ReturnNewEquipment(Equipment equipment)
    {
        returnEquipment?.Invoke(equipment);
    }

}
