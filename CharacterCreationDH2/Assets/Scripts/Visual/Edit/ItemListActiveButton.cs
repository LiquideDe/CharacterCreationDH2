using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemListActiveButton : ItemInList, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ChooseThis();
    }
}
