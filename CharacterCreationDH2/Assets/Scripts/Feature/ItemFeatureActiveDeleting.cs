using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ItemFeatureActiveDeleting : ItemFeature, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        RemoveThis();
    }
}
