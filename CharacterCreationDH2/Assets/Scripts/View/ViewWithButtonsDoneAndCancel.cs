using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewWithButtonsDoneAndCancel : AnimateShowAndHideView
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
        Show();
    }

    private void AddListeners()
    {
        _buttonDone.onClick.AddListener(ButtonDonePressed);
        _buttonDone.onClick.AddListener(_audio.PlayDone);
        _buttonCancel.onClick.AddListener(ButtonCancelPressed);
        _buttonCancel.onClick.AddListener(_audio.PlayCancel);
        isButtonWithListener = true;
    }

    private void ButtonCancelPressed() => HideRight(Cancel,this);//Cancel?.Invoke(this);

    protected virtual void ButtonDonePressed() => Hide(Done);//Done?.Invoke();
}
