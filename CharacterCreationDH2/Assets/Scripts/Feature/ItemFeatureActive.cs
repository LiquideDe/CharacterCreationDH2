using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class ItemFeatureActive : ItemFeature, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SetAnotherLvl();
    }
}
