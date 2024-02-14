using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class ButtonStudy : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public delegate void PayTheCost(int cost, int id);
    PayTheCost payTheCost;
    [SerializeField] Sprite spriteLearned, spriteUnlearned;
    [SerializeField] TextMeshProUGUI helpText;
    private Image image;
    private bool isPrevButtActive;
    private bool isActivated;
    private int cost=200;
    [SerializeField] private int id;
    public bool IsPrevButtActive { get => isPrevButtActive; set => isPrevButtActive = value; }
    public int Cost { get => cost; set => cost = value; }

    private void Start()
    {
        helpText.text = $"{cost} нн";
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPrevButtActive && !isActivated)
        {
            image.sprite = spriteLearned;
            isActivated = true;
            payTheCost?.Invoke(cost, id);           
        }
        
    }
    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (isPrevButtActive && !isActivated)
        {
            helpText.text = cost.ToString();
            //helpText.transform.position = new Vector3(helpText.transform.position.x, transform.position.y);
            //helpText.gameObject.SetActive(true);            
        }
        
    }*/

    public void OnPointerExit(PointerEventData eventData)
    {
        //helpText.gameObject.SetActive(false);
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void RegDelegate(PayTheCost payTheCost)
    {
        this.payTheCost = payTheCost;
    }

    public void CancelOperation()
    {
        isActivated = false;
        image.sprite = spriteUnlearned;
    }

    public void Activated()
    {
        isPrevButtActive = true;
        isActivated = true;
        image.sprite = spriteLearned;
    }

}
