using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CardWithNumber : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] TextMeshProUGUI text;
    int amount;
    Vector3 startPos;
    CanvasGroup canvasGroup;
    bool cantReplace;
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //dragRect.anchoredPosition += eventData.delta/canvas.scaleFactor;
        transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
    }

    public void SetAmount(int amount)
    {
        this.amount = amount;
        text.text = amount.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!cantReplace)
        {
            transform.position = startPos;
            canvasGroup.blocksRaycasts = true;
        }
        
        
    }

    public void NewStartPosition(Vector3 pos)
    {
        startPos = pos;
    }

    public int GetAmount()
    {
        return amount;
    }

    public void SetNewParent(Transform transform)
    {
        cantReplace = true;
        this.transform.SetParent(transform);
    }
}
