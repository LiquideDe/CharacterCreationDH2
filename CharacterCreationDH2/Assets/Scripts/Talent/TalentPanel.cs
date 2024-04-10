using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TalentPanel : MonoBehaviour, IPointerDownHandler
{
    public delegate void NotificationAboutId(int id, int cost);
    private NotificationAboutId notificationAboutId;
    [SerializeField] TextMeshProUGUI textDescr, textName, textCost, textShortDescr;
    Image image;
    [SerializeField] Sprite activeSprite, deactiveSprite;
    int id;
    string description;
    int cost;
    bool hasAlready, canTraining;
    public bool HasAlready { get => hasAlready; }
    public bool CanTraining { get => canTraining; }
    AudioWork audioWork;
    private void Awake()
    {
        image = this.GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        textDescr.text = textName.text + "\n" + "\n";
        textDescr.text += description;
        audioWork.PlayClick();
        if (!hasAlready)
        {
            notificationAboutId?.Invoke(id, cost);
        }        
    }

    public void CreatePanel(Talent talent, int id, NotificationAboutId notificationAboutId, bool canTraining, bool alreadyHas, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        textName.text = talent.Name;
        textCost.text = talent.Cost.ToString();
        cost = talent.Cost;
        this.id = id;
        description = talent.Description;
        this.notificationAboutId = notificationAboutId;
        textShortDescr.text = talent.ShortDescription;
        hasAlready = alreadyHas;
        this.canTraining = canTraining;
        if (!canTraining)
        {
            image.sprite = deactiveSprite;
        }
    }

    public void Deactivate()
    {
        hasAlready = true;
        gameObject.SetActive(false);
        textDescr.text = "";
    }

    public void CancelOperation()
    {
        hasAlready = false;
        gameObject.SetActive(true);
    }

    
}

    

