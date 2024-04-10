using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListWithImplants : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] ItemListActiveButton buttonExample;
    [SerializeField] VisualCreateImplant createImplantExample;
    List<MechImplant> mechImplants = new List<MechImplant>();
    List<ItemListActiveButton> buttons = new List<ItemListActiveButton>();
    AudioWork audioWork;

    public delegate void ReturnMechImplant(MechImplant mechImplant);
    ReturnMechImplant returnMechImplant;

    public void SetParams(List<MechImplant> implants, ReturnMechImplant returnMechImplant, AudioWork audioWork)
    {
        gameObject.SetActive(true);
        this.returnMechImplant = returnMechImplant;
        mechImplants = implants;
        this.audioWork = audioWork;
        foreach(MechImplant implant in implants)
        {
            buttons.Add(Instantiate(buttonExample, content));
            buttons[^1].SetParams(implant.Name, FinishChoose, audioWork);
        }
    }

    private void FinishChoose(string name)
    {
        foreach(MechImplant implant in mechImplants)
        {
            if(string.Compare(implant.Name, name, true) == 0)
            {
                audioWork.PlayDone();
                returnMechImplant?.Invoke(implant);
                break;
            }
        }

        Destroy(gameObject);
    }

    public void Cancel()
    {
        audioWork.PlayCancel();
        Destroy(gameObject);
    }

    public void CreateNewImplant()
    {
        audioWork.PlayClick();
        Canvas canvas = GetComponentInParent<Canvas>();
        var panelCreation = Instantiate(createImplantExample, canvas.transform);
        panelCreation.SetParams(ReturnNewImplant, audioWork);
    }

    private void ReturnNewImplant(MechImplant mechImplant)
    {
        audioWork.PlayDone();
        returnMechImplant?.Invoke(mechImplant);
        Destroy(gameObject);
    }
}
