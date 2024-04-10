using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInList : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textName;    
    public delegate void ChooseItem(string name);
    ChooseItem chooseItem;
    AudioWork audioWork;

    public void SetParams(string name, ChooseItem chooseItem, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        this.chooseItem = chooseItem;
        textName.text = name;
        gameObject.SetActive(true);
    }

    public void ChooseThis()
    {
        audioWork.PlayClick();
        chooseItem?.Invoke(textName.text);
        Destroy(gameObject);
    }

}
