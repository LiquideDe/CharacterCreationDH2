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

    public void RegDelegate(GoToScreenshot toScreenshot)
    {
        this.toScreenshot = toScreenshot;
    }

    public void TextInput()
    {
        if(inputName.text.Length > 0)
        {
            string gender;
            if (toggleMale.isOn)
            {
                gender = "�";
            }
            else
            {
                gender = "�";
            }
            toScreenshot?.Invoke(inputName.text, gender);
            Destroy(gameObject);
        }
        
    }
}
