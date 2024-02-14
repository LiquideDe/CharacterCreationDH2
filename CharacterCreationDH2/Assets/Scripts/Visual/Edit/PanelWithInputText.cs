using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelWithInputText : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    public delegate void ReturnName(string name);
    ReturnName returnName;

    public void Init(ReturnName returnName)
    {
        gameObject.SetActive(true);
        this.returnName = returnName;
    }

    public void Done()
    {
        returnName?.Invoke(inputName.text);
        Cancel();
    }

    public void Cancel()
    {
        Destroy(gameObject);
    }
}
