using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class HomeworldFinalPanelView : ViewWithButtonsDoneAndCancel
{
    [SerializeField]
    private TMP_InputField _inputFate, _inputWound, _inputAge, _inputHair, _inputTradition, _inputSkeen,
        _inputRemember, _inputBody, _inputEyes, _inputPhys;

    [SerializeField]
    private Button _buttonFate, _buttonWound, _buttonAge, _buttonHair, _buttonTradition, _buttonSkeen,
        _buttonRemember, _buttonBody, _buttonEyes, _buttonPhys;

    public event Action<string> FateEntered;
    public event Action<string> WoundEntered;
    public event Action<string> AgeEntered;
    public event Action<string> HairEntered;
    public event Action<string> TraditionEntered;
    public event Action<string> SkeenEntered;
    public event Action<string> RememberEntered;
    public event Action<string> BodyEntered;
    public event Action<string> EyesEntered;
    public event Action<string> PhysEntered;

    public event Action ButtonFatePress;
    public event Action ButtonWoundPress;
    public event Action ButtonAgePress;
    public event Action ButtonHairPress;
    public event Action ButtonTraditionPress;
    public event Action ButtonSkeenPress;
    public event Action ButtonRememberPress;
    public event Action ButtonBodyPress;
    public event Action ButtonEyesPress;
    public event Action ButtonPhysPress;

    private void OnEnable()
    {
        _inputFate.onDeselect.AddListener(EnterTextFate);
        _inputWound.onDeselect.AddListener(EnterTextWound);
        _inputAge.onDeselect.AddListener(EnterTextAge);
        _inputHair.onDeselect.AddListener(EnterTextHair);
        _inputTradition.onDeselect.AddListener(EnterTextTradition);
        _inputSkeen.onDeselect.AddListener(EnterTextSkeen);
        _inputRemember.onDeselect.AddListener(EnterTextRemember);
        _inputBody.onDeselect.AddListener(EnterTextBody);
        _inputEyes.onDeselect.AddListener(EnterTextEyes);
        _inputPhys.onDeselect.AddListener(EnterTextPhys);

        _buttonFate.onClick.AddListener(ButtonFateDown);
        _buttonWound.onClick.AddListener(ButtonWoundDown);
        _buttonAge.onClick.AddListener(ButtonAgeDown);
        _buttonHair.onClick.AddListener(ButtonHairDown);
        _buttonTradition.onClick.AddListener(ButtonTraditionDown);
        _buttonSkeen.onClick.AddListener(ButtonSkeenDown);
        _buttonRemember.onClick.AddListener(ButtonRememberDown);
        _buttonBody.onClick.AddListener(ButtonBodyDown);
        _buttonEyes.onClick.AddListener(ButtonEyesDown);
        _buttonPhys.onClick.AddListener(ButtonPhysDown);
    }

    private void OnDisable()
    {
        _inputFate.onDeselect.RemoveAllListeners();
        _inputWound.onDeselect.RemoveAllListeners();
        _inputAge.onDeselect.RemoveAllListeners();
        _inputHair.onDeselect.RemoveAllListeners();
        _inputTradition.onDeselect.RemoveAllListeners();
        _inputSkeen.onDeselect.RemoveAllListeners();
        _inputRemember.onDeselect.RemoveAllListeners();
        _inputBody.onDeselect.RemoveAllListeners();
        _inputEyes.onDeselect.RemoveAllListeners();
        _inputPhys.onDeselect.RemoveAllListeners();

        _buttonFate.onClick.RemoveAllListeners();
        _buttonWound.onClick.RemoveAllListeners();
        _buttonAge.onClick.RemoveAllListeners();
        _buttonHair.onClick.RemoveAllListeners();
        _buttonTradition.onClick.RemoveAllListeners();
        _buttonSkeen.onClick.RemoveAllListeners();
        _buttonRemember.onClick.RemoveAllListeners();
        _buttonBody.onClick.RemoveAllListeners();
        _buttonEyes.onClick.RemoveAllListeners();
        _buttonPhys.onClick.RemoveAllListeners();
    }

    public void SetTextFate(string value)
    {
        _inputFate.text = value;
        _inputFate.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputFate.interactable = false;
        _buttonFate.interactable = false;
    }

    public void SetTextWound(string value)
    {
        _inputWound.text = value;
        _inputWound.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputWound.interactable = false;
        _buttonWound.interactable = false;
    }

    public void SetTextAge(string value)
    {
        _inputAge.text = value;
        _inputAge.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputAge.interactable = false;
        _buttonAge.interactable = false;
    }

    public void SetTextHair(string value)
    {
        _inputHair.text = value;
        _inputHair.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputHair.interactable = false;
        _buttonHair.interactable = false;
    }

    public void SetTextTradition(string value)
    {
        _inputTradition.text = value;
        _inputTradition.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputTradition.interactable = false;
        _buttonTradition.interactable = false;
    }

    public void SetTextSkeen(string value)
    {
        _inputSkeen.text = value;
        _inputSkeen.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputSkeen.interactable = false;
        _buttonSkeen.interactable = false;
    }

    public void SetTextRemember(string value)
    {
        _inputRemember.text = value;
        _inputRemember.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputRemember.interactable = false;
        _buttonRemember.interactable = false;
    }

    public void SetTextBody(string value)
    {
        _inputBody.text = value;
        _inputBody.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputBody.interactable = false;
        _buttonBody.interactable = false;
    }

    public void SetTextEyes(string value)
    {
        _inputEyes.text = value;
        _inputEyes.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputEyes.interactable = false;
        _buttonEyes.interactable = false;
    }

    public void SetTextPhys(string value)
    {
        _inputPhys.text = value;
        _inputPhys.lineType = TMP_InputField.LineType.MultiLineNewline;
        _inputPhys.interactable = false;
        _buttonPhys.interactable = false;
    }

    private void EnterTextFate(string value) 
    {
        CancelSelect();
        FateEntered?.Invoke(_inputFate.text);
    } 
    private void EnterTextWound(string value)
    {
        CancelSelect();
        WoundEntered?.Invoke(_inputWound.text);
    }
    private void EnterTextAge(string value)
    {
        CancelSelect();
        AgeEntered?.Invoke(_inputAge.text);
    }
    private void EnterTextHair(string value)
    {
        CancelSelect();
        HairEntered?.Invoke(_inputHair.text);
    }
    private void EnterTextTradition(string value)
    {
        CancelSelect();
        TraditionEntered?.Invoke(_inputTradition.text);
    } 
    private void EnterTextSkeen(string value)
    {
        CancelSelect();
        SkeenEntered?.Invoke(_inputSkeen.text);
    }
    private void EnterTextRemember(string value) 
    {
        CancelSelect();
        RememberEntered?.Invoke(_inputRemember.text);
    }
    private void EnterTextBody(string value) 
    {
        CancelSelect();
        BodyEntered?.Invoke(_inputBody.text);
    }
    private void EnterTextEyes(string value)
    {
        CancelSelect();
        EyesEntered?.Invoke(_inputEyes.text);
    }
    private void EnterTextPhys(string value)
    {
        CancelSelect();
        PhysEntered?.Invoke(_inputPhys.text);
    }

    private void ButtonFateDown() => ButtonFatePress?.Invoke();
    private void ButtonWoundDown() => ButtonWoundPress?.Invoke();
    private void ButtonAgeDown() => ButtonAgePress?.Invoke();
    private void ButtonHairDown() => ButtonHairPress?.Invoke();
    private void ButtonTraditionDown() => ButtonTraditionPress?.Invoke();
    private void ButtonSkeenDown() => ButtonSkeenPress?.Invoke();
    private void ButtonRememberDown() => ButtonRememberPress?.Invoke();
    private void ButtonBodyDown() => ButtonBodyPress?.Invoke();
    private void ButtonEyesDown() => ButtonEyesPress?.Invoke();
    private void ButtonPhysDown() => ButtonPhysPress?.Invoke();

    private void CancelSelect()
    {
        var eventSystem = EventSystem.current;
        if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);
    }
}
