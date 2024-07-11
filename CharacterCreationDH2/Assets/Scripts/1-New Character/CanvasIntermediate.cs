using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

public class CanvasIntermediate : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] Button button;
    AudioManager _audioWork;
    public delegate void NextTask();
    NextTask nextTask;

    [Inject]
    public void Construct(AudioManager audioWork)
    {
        _audioWork = audioWork;
    }

    private void OnEnable() => button.onClick.AddListener(ButtonPressed);
    

    private void OnDisable() => button.onClick.RemoveAllListeners();
    

    public void OpenIntermediatePanel(NextTask nextTask, string text)
    {
        this.nextTask = nextTask;
        descriptionText.text = text;
    }

    public void ButtonPressed()
    {
        _audioWork.PlayDone();
        nextTask?.Invoke();
        Destroy(gameObject);
    }

}
