using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CardWithNumber : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Canvas canvas;
    int amount;
    RectTransform dragRect;
    Vector3 startPos;
    CanvasGroup canvasGroup;
    bool cantReplace;
    private void Start()
    {
        dragRect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRect.anchoredPosition += eventData.delta/canvas.scaleFactor;
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