using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ParamInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField] TextMeshProUGUI textDescription;
    [SerializeField] GameObject panelWithText;
    private string _description;

    public void SetDescription(string description) => _description = description;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        textDescription.text = _description;
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        float x = (Camera.main.pixelWidth - 0.5f) - panelWithText.GetComponent<RectTransform>().sizeDelta.x/2;
        float y = Camera.main.pixelHeight - panelWithText.GetComponent<RectTransform>().sizeDelta.y/2;
        float newY = Mathf.Clamp(worldPosition.y, -y, y);
        float newX = Mathf.Clamp(worldPosition.x, -7, 7);
        panelWithText.transform.position = new Vector2(newX, newY);
        panelWithText.SetActive(true);        
    }

    public void OnPointerExit(PointerEventData eventData) => panelWithText.SetActive(false);   

}
