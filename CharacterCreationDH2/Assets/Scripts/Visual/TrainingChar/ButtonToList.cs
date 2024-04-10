using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonToList : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] TextMeshProUGUI textName;
    private GameObject additionalPanel;
    AudioWork audioWork;

    public string TextName { set => textName.text = value; }

    public void OnPointerDown(PointerEventData eventData)
    {
        audioWork.PlayClick();
        additionalPanel.SetActive(true);
    }

    public void SetPanel(GameObject additionalPanel, AudioWork audioWork)
    {
        this.additionalPanel = additionalPanel;
        this.audioWork = audioWork;
    }
}
