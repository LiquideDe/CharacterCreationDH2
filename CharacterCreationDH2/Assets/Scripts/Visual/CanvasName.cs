using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasName : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    public delegate void GoToScreenshot(string name);
    GoToScreenshot toScreenshot;

    public void RegDelegate(GoToScreenshot toScreenshot)
    {
        this.toScreenshot = toScreenshot;
    }

    public void TextInput()
    {
        toScreenshot?.Invoke(inputName.text);
        Destroy(gameObject);
    }
}
