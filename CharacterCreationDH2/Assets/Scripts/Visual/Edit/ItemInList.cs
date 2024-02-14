using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInList : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textName;
    public delegate void ChooseItem(string name);
    ChooseItem chooseItem;

    public void SetParams(string name, ChooseItem chooseItem)
    {
        this.chooseItem = chooseItem;
        textName.text = name;
        gameObject.SetActive(true);
    }

    public void ChooseThis()
    {
        chooseItem?.Invoke(textName.text);
        Destroy(gameObject);
    }

}
