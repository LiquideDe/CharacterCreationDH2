using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasIntermediate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] Button button;
    AudioWork audioWork;
    public delegate void NextTask();
    NextTask nextTask;


    public void SetAudio(AudioWork audioWork)
    {
        this.audioWork = audioWork;
    }
    public void OpenIntermediatePanel(NextTask nextTask, string text)
    {
        button.onClick.RemoveAllListeners();
        this.nextTask = nextTask;
        descriptionText.text = text;
        button.onClick.AddListener(ButtonPressed);
    }

    public void ButtonPressed()
    {
        audioWork.PlayDone();
        nextTask?.Invoke();
    }

}
