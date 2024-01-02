using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PsyPanel : MonoBehaviour, IPointerDownHandler
{
    public delegate void OpenPsy(int id);
    OpenPsy openPsy;
    [SerializeField] TextMeshProUGUI textName, textCost;
    [SerializeField] Image image;
    [SerializeField] Sprite spriteActive, spriteDeActive;
    public int id, cost;
    bool isActive;

    public int Id { get => id; }
    public int Cost { get => cost; } 

    public void OnPointerDown(PointerEventData eventData)
    {
        openPsy?.Invoke(id);
    }

    public void SetPsyPanel(string name, string textCost,int cost, int id, bool isActive)
    {
        textName.text = name;
        this.textCost.text = textCost;
        this.id = id;
        this.cost = cost;
        if (isActive)
        {
            BuyPower();
        }
    }

    public void RegDelegate(OpenPsy openPsy)
    {
        this.openPsy = openPsy;
    }

    public void CancelOperation()
    {
        isActive = false;
        image.sprite = spriteDeActive;
    }

    public void BuyPower()
    {
        isActive = true;
        image.sprite = spriteActive;
    }
}
