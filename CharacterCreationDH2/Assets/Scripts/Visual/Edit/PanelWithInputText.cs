using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelWithInputText : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    public delegate void ReturnName(string name);
    ReturnName returnName;
    AudioWork audioWork;

    public void Init(ReturnName returnName, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        gameObject.SetActive(true);
        this.returnName = returnName;
    }

    public void Done()
    {
        audioWork.PlayDone();
        returnName?.Invoke(inputName.text);
        Destroy(gameObject);
    }

    public void Cancel()
    {
        audioWork.PlayCancel();
        Destroy(gameObject);
    }
}
