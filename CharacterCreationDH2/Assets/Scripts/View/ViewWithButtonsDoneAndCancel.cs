using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewWithButtonsDoneAndCancel : CanDestroyView
{
    [SerializeField] private Button _buttonDone, _buttonCancel;
    public event Action Done;
    public event Action<CanDestroyView> Cancel;
    private bool isButtonWithListener;

    private void OnEnable() => AddListeners();

    private void OnDisable()
    {
        _buttonDone.onClick.RemoveAllListeners();
        _buttonCancel.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        if (isButtonWithListener == false)
            AddListeners();
    }

    private void AddListeners()
    {
        _buttonDone.onClick.AddListener(ButtonDonePressed);
        _buttonCancel.onClick.AddListener(ButtonCancelPressed);
        isButtonWithListener = true;
    }

    private void ButtonCancelPressed() => Cancel?.Invoke(this);

    protected virtual void ButtonDonePressed() => Done?.Invoke();
}
