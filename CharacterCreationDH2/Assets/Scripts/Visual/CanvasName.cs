using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasName : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    [SerializeField] Toggle toggleMale, toggleFemale;
    public delegate void GoToScreenshot(string name, string gender);
    GoToScreenshot toScreenshot;
    AudioWork audioWork;

    public void RegDelegate(GoToScreenshot toScreenshot, AudioWork audioWork)
    {
        this.toScreenshot = toScreenshot;
        this.audioWork = audioWork;
    }

    public void TextInput()
    {
        if(inputName.text.Length > 0)
        {
            audioWork.PlayDone();
            string gender;
            if (toggleMale.isOn)
            {
                gender = "Ì";
            }
            else
            {
                gender = "Æ";
            }
            toScreenshot?.Invoke(inputName.text, gender);
            Destroy(gameObject);
        }
        else
        {
            audioWork.PlayWarning();
        }
        
    }
}
