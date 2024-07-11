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
        {GameStat.Inclinations.Agility, "�" },
        {GameStat.Inclinations.Ballistic, "��" },
        {GameStat.Inclinations.Defense, "�" },
        {GameStat.Inclinations.Fellowship, "�" },
        {GameStat.Inclinations.Fieldcraft, "���" },
        {GameStat.Inclinations.Finesse, "���" },
        {GameStat.Inclinations.Intelligence, "���" },
        {GameStat.Inclinations.Knowledge, "���" },
        {GameStat.Inclinations.Leadership, "���" },
        {GameStat.Inclinations.Offense, "���" },
        {GameStat.Inclinations.Perception, "���" },
        {GameStat.Inclinations.Psyker, "���" },
        {GameStat.Inclinations.Social, "���" },
        {GameStat.Inclinations.Strength, "�" },
        {GameStat.Inclinations.Tech, "���" },
        {GameStat.Inclinations.Toughness, "���" },
        {GameStat.Inclinations.Weapon, "��" },
        {GameStat.Inclinations.Willpower, "��" }
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
        _textDescription = $"�������� ������� ��������� � {GameStat.inclinationTranslate[_inclination]}";
        textName.text = _inclinationToShort[inclination];
    }

    public void SetActive() => _image.sprite = _active;

    public void SetDeactive() => _image.sprite = _nonActive;
}
