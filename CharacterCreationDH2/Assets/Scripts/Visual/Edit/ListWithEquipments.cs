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
    AudioWork audioWork;

    public void SetParams(CreatorNewEquipment newEquipment, List<Equipment> equipments, ReturnEquipment returnEquipment, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        gameObject.SetActive(true);
        this.equipments = equipments;
        this.returnEquipment = returnEquipment;
        this.newEquipment = newEquipment;
        foreach(Equipment equipment in equipments)
        {
            activeButtons.Add(Instantiate(itemExample, content));
            activeButtons[^1].SetParams(equipment.Name, FinishChoose, audioWork);
        }
    }

    private void FinishChoose(string name)
    {
        foreach(Equipment equipment in equipments)
        {
            if(string.Compare(equipment.ClearName, name, true)==0)
            {
                audioWork.PlayDone();
                returnEquipment?.Invoke(equipment);
                break;
            }
        }
    }

    public void Cancel()
    {
        audioWork.PlayCancel();
        Destroy(gameObject);
    }

    public void CreateNewEquipment()
    {
        audioWork.PlayClick();
        Canvas canvas = GetComponentInParent<Canvas>();
        CreatorNewEquipment newEq = Instantiate(newEquipment, canvas.transform);
        newEq.RegDelegate(ReturnNewEquipment, audioWork);
    }

    private void ReturnNewEquipment(Equipment equipment)
    {
        audioWork.PlayDone();
        returnEquipment?.Invoke(equipment);
    }

}
