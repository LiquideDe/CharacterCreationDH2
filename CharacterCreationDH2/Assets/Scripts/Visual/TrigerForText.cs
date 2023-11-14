using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrigerForText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject panel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panel.SetActive(false);
    }

}
