using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ParamInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string description;
    [SerializeField] TextMeshProUGUI textDescription;
    [SerializeField] GameObject panelWithText;
    // Start is called before the first frame update
    
    public void SetDescription(string description)
    {
        this.description = description;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        textDescription.text = description;
        float x = (Screen.width  - 0.5f) - panelWithText.GetComponent<RectTransform>().sizeDelta.x/2;
        float y = Screen.height - panelWithText.GetComponent<RectTransform>().sizeDelta.y/2;
        float newY = Mathf.Clamp(transform.position.y, -y, y);
        float newX = Mathf.Clamp(transform.position.x + 500, -x, x);
        panelWithText.transform.position = new Vector3(newX, newY);
        panelWithText.SetActive(true);
        
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panelWithText.SetActive(false);
    }

}
