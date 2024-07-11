using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class PsyPanel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] TextMeshProUGUI textName, textCost;
    [SerializeField] Image image;
    [SerializeField] Sprite spriteActive, spriteDeActive;
    public event Action<string> ShowThisPsyPower; 
    public int id;

    public int Id { get => id; }

    public void OnPointerDown(PointerEventData eventData) => ShowThisPsyPower?.Invoke(textName.text);

    public void SetPsyPanel(string name, string textCost, int id, bool isActive)
    {
        textName.text = name;
        this.textCost.text = textCost;
        this.id = id;
        if (isActive)
        {
            image.sprite = spriteActive;
        }
    }
}
