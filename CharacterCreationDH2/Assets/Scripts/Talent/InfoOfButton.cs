using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoOfButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI textDescription;
    [SerializeField] GameObject panelInfo;
    public string description;
    private Image image;
    [SerializeField] Sprite activeSprite, deActivesprite;
    [SerializeField] bool isActive, isHideAll;
    [SerializeField] GameStat.Inclinations inclination;
    public delegate void ClickOnButton();
    ClickOnButton clickOnButton;
    public bool IsActive { get => isActive; }
    public GameStat.Inclinations Inclination { get => inclination; }

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        textDescription.text = ComposeText();
        panelInfo.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panelInfo.SetActive(false);
    }

    public void RegDelegate(ClickOnButton clickOnButton)
    {
        this.clickOnButton = clickOnButton;
    }
    private string ComposeText()
    {
        string text;
        if (!isHideAll)
        {
            if (isActive)
            {
                text = "Скрыть таланты связанные с " + description;
            }
            else
            {
                text = "Показать таланты связанные с " + description;
            }
        }
        else
        {
            if (isActive)
            {
                text = "Скрыть недоступные таланты";
            }
            else
            {
                text = "Показать недоступные таланты";
            }
        }
        return text;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isActive)
        {
            isActive = false;
            image.sprite = deActivesprite;

        }
        else
        {
            isActive = true;
            image.sprite = activeSprite;
        }
        clickOnButton?.Invoke();
    }
}
