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
    [SerializeField] bool isActive, isHideUnavailable, isHideShow;
    [SerializeField] GameStat.Inclinations inclination;
    public delegate void ClickOnButton();
    ClickOnButton clickOnButton;
    public bool IsActive { get => isActive; }
    public GameStat.Inclinations Inclination { get => inclination; }
    AudioManager audioWork;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetAudio(AudioManager audioWork)
    {
        this.audioWork = audioWork;
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
        if (!isHideUnavailable && !isHideShow)
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
        else if(isHideUnavailable)
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
        else
        {
            if (isActive)
            {
                text = "Показать все таланты";
            }
            else
            {
                text = "Скрыть все таланты";
            }
        }
        return text;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioWork.PlayClick();
        ChangeActive();
        clickOnButton?.Invoke();
    }

    public void ChangeActive()
    {
        if (isActive)
        {
            DeActivate();

        }
        else
        {
            Activate();
        }
    }

    public void DeActivate()
    {
        isActive = false;
        image.sprite = deActivesprite;
    }

    public void Activate()
    {
        isActive = true;
        image.sprite = activeSprite;
    }
}
