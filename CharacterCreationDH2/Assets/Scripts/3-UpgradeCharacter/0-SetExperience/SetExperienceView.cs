using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SetExperienceView : MonoBehaviour
{
    [SerializeField] private Button _buttonDone;
    [SerializeField] private TMP_InputField _inputExperience;

    public event Action<string> InputDone;

    private void OnEnable() => _buttonDone.onClick.AddListener(DonePressed);
    private void OnDisable() => _buttonDone.onClick.RemoveAllListeners();

    public void DestroyView() => Destroy(gameObject);

    private void DonePressed() => InputDone?.Invoke(_inputExperience.text);
}
