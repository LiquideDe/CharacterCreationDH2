using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;

public class TalentPanel : MonoBehaviour, IPointerDownHandler, IItemForList
{    
    [SerializeField] TextMeshProUGUI textName, textCost, textShortDescr;    
    [SerializeField] Sprite activeSprite, deactiveSprite;
    public event Action<string> ShowThisTalent;
    private Image _image;
    private RectTransform _rectTransform;

    public GameObject GameObject => gameObject;

    public RectTransform RectTransform => _rectTransform;

    private void Awake()
    {
        _image = this.GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData) => ShowThisTalent?.Invoke(textName.text);

    public void Show() => gameObject.SetActive(true);

    public void Initialize(ISkillTalentEtcForList skillTalentEtcForList, int cost, bool isCanTaken)
    {
        Talent talent = (Talent)skillTalentEtcForList;
        textName.text = talent.Name;
        textCost.text = $"{cost} нн";
        textShortDescr.text = talent.ShortDescription;
        if (!isCanTaken)
        {
            _image.sprite = deactiveSprite;
            //gameObject.SetActive(false);
        }
    }
}

    

