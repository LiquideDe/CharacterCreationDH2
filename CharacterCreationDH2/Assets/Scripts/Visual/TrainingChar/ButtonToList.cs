using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonToList : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] TextMeshProUGUI textName;
    private GameObject additionalPanel;

    public string TextName { set => textName.text = value; }

    public void OnPointerDown(PointerEventData eventData)
    {
        additionalPanel.SetActive(true);
    }

    public void SetPanel(GameObject additionalPanel)
    {
        this.additionalPanel = additionalPanel;
    }
}
