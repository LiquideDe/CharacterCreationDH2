using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointInsert : MonoBehaviour, IDropHandler
{
    [SerializeField] CharacteristicCard characteristicCard;
    bool isEmpty = true;

    public void OnDrop(PointerEventData eventData)
    {
        if (isEmpty)
        {
            if (eventData.pointerDrag != null)
            {
                CardWithNumber cardWith = eventData.pointerDrag.GetComponent<CardWithNumber>();
                cardWith.SetNewParent(transform);
                //cardWith.transform.position = this.transform.position;
                
                cardWith.GetComponent<RectTransform>().anchoredPosition = this.transform.GetComponent<RectTransform>().anchoredPosition;
                //cardWith.NewStartPosition(transform.position);
                characteristicCard.PlusAmount(cardWith.GetAmount());
                cardWith.gameObject.SetActive(false);
                isEmpty = false;
            }
        }
        
    }
}
