using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TalentPanel : MonoBehaviour, IPointerDownHandler
{
    public delegate void NotificationAboutId(int id, int cost);
    private NotificationAboutId notificationAboutId;
    [SerializeField] TextMeshProUGUI textDescr, textName, textCost;
    int id;
    string description;
    int cost;
    bool isPossible = true;
    public void OnPointerDown(PointerEventData eventData)
    {
        
        textDescr.text = textName.text + "\n" + "\n";
        textDescr.text += description;
        if (isPossible)
        {
            notificationAboutId?.Invoke(id, cost);
        }        
    }

    public void CreatePanel(string name, string description, int cost, int id, NotificationAboutId notificationAboutId)
    {
        textName.text = name;
        textCost.text = cost.ToString();
        this.cost = cost;
        this.id = id;
        this.description = description;
        this.notificationAboutId = notificationAboutId;
    }

    public void Deactivate()
    {
        isPossible = false;
        gameObject.SetActive(false);
        textDescr.text = "";
    }

    public void CancelOperation()
    {
        isPossible = true;
        gameObject.SetActive(true);
    }
}

    

