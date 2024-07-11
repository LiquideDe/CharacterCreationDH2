using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundFinalPanelView : MonoBehaviour, IFinalPanelWithToggles
{
    [SerializeField] Button _buttonDone, _buttonCancel;

    public event Action CancelPress;
    public event Action<List<ToggleGroup>> DonePress;
    private List<ToggleGroup> _toggleGroups;

    private void OnEnable()
    {
        _buttonDone.onClick.AddListener(Done);
        _buttonCancel.onClick.AddListener(Cancel);
    }

    private void OnDisable()
    {
        _buttonDone.onClick.RemoveAllListeners();
        _buttonCancel.onClick.RemoveAllListeners();
    }

    public void SetToggles(List<ToggleGroup> toggleGroups)
    {
        _toggleGroups = new List<ToggleGroup>(toggleGroups);
    }

    public void DestroyView()
    {
        Destroy(gameObject);
    }

    private void Cancel() => CancelPress?.Invoke();

    private void Done() => DonePress?.Invoke(_toggleGroups);
}
