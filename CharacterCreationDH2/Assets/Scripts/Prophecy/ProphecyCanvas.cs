using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ProphecyCanvas : MonoBehaviour
{
    public delegate void FinishProphecy();
    FinishProphecy finishProphecy;
    [SerializeField] TextMeshProUGUI textDescription;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject button;
    Character character;
    Prophecy prophecy;
    AudioWork audioWork;

    public void GenerateFromButton()
    {
        audioWork.PlayClick();
        SetText(prophecy.GenerateProphecy(character));        
    }

    public void GenerateFromInput()
    {
        audioWork.PlayClick();
        EventSystem.current.SetSelectedGameObject(null);
        if (int.TryParse(inputField.text, out int number))
        {
            if (number <= 100 && number > 0)
            {
                SetText(prophecy.GenerateProphecy(character, number));
            }
            else
            {
                inputField.text = "";
            }
        }
    }

    private void SetText(string text)
    {
        textDescription.text = $"Ваше пророчество: {text}";
        character.Prophecy = text;
        button.SetActive(false);
        inputField.interactable = false;
        character.CalculatePhysAbilities();
    }

    public void RegDelegate(FinishProphecy finishProphecy)
    {
        this.finishProphecy = finishProphecy;
    }

    public void StartChoose(Character character, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        prophecy = new Prophecy();
        this.character = character;
    }

    public void Finish()
    {
        if(textDescription.text != "")
        {
            audioWork.PlayDone();
            finishProphecy?.Invoke();
            Destroy(gameObject);
        }
        else
        {
            audioWork.PlayWarning();
        }
    }
}
