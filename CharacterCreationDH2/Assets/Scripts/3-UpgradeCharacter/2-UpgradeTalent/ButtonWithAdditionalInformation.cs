using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ButtonWithAdditionalInformation : Button, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI textName;
    [SerializeField] Sprite _active, _nonActive;
    [SerializeField] Image _image;
    public event Action<string> ShowDescription;
    public event Action<GameStat.Inclinations> ShowThisInclination;
    public event Action HidePanel;
    private GameStat.Inclinations _inclination;
    private string _textDescription;
    private Dictionary<GameStat.Inclinations, string> _inclinationToShort = new Dictionary<GameStat.Inclinations, string>() 
    {
        {GameStat.Inclinations.Agility, "Л" },
        {GameStat.Inclinations.Ballistic, "НС" },
        {GameStat.Inclinations.Defense, "З" },
        {GameStat.Inclinations.Fellowship, "О" },
        {GameStat.Inclinations.Fieldcraft, "Пол" },
        {GameStat.Inclinations.Finesse, "Изо" },
        {GameStat.Inclinations.Intelligence, "Инт" },
        {GameStat.Inclinations.Knowledge, "Поз" },
        {GameStat.Inclinations.Leadership, "Лид" },
        {GameStat.Inclinations.Offense, "Нап" },
        {GameStat.Inclinations.Perception, "Вос" },
        {GameStat.Inclinations.Psyker, "Пса" },
        {GameStat.Inclinations.Social, "Общ" },
        {GameStat.Inclinations.Strength, "С" },
        {GameStat.Inclinations.Tech, "Тех" },
        {GameStat.Inclinations.Toughness, "Вын" },
        {GameStat.Inclinations.Weapon, "НР" },
        {GameStat.Inclinations.Willpower, "СВ" }
    };

    public GameStat.Inclinations Inclinations => _inclination;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        ShowDescription?.Invoke(_textDescription);
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        HidePanel?.Invoke();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        ShowThisInclination?.Invoke(_inclination);
    }

    public void Initialize(GameStat.Inclinations inclination)
    {
        _inclination = inclination;
        _textDescription = $"Показать таланты связанные с {GameStat.inclinationTranslate[_inclination]}";
        textName.text = _inclinationToShort[inclination];
    }

    public void SetActive() => _image.sprite = _active;

    public void SetDeactive() => _image.sprite = _nonActive;
}
