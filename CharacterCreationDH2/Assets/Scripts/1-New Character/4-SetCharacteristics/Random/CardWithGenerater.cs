using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Zenject;

public class CardWithGenerater : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] CardWithNumber cardWithNumber;
    [SerializeField] GameObject button;
    private AudioManager _audioManager;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    private int GenerateValue(int max)
    {
        System.Random random = new System.Random();
        return random.Next(3, max);
    }

    public void GenerateFromButton()
    {
        _audioManager.PlayClick();
        int summ = 0;
        summ += GenerateValue(10);
        summ += GenerateValue(10);
        CloseGenerator(summ);
    }

    private void CloseGenerator(int summ)
    {
        cardWithNumber.SetAmount(summ);
        button.SetActive(false);
        inputField.gameObject.SetActive(false);
        cardWithNumber.gameObject.SetActive(true);
    }

    public void GenerateFromInput()
    {
        StartCoroutine(CheckInput());
        CancelSelect(); 
    }
    private void CancelSelect()
    {
        var eventSystem = EventSystem.current;
        if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);
    }

    IEnumerator CheckInput()
    {
        yield return new WaitForEndOfFrame();
        if (IsInputFieldTyped())
        {
            if (int.TryParse(inputField.text, out int number))
            {
                if (number <= 20 && number > 0)
                {
                    _audioManager.PlayClick();
                    CloseGenerator(number);
                }
                else
                {
                    _audioManager.PlayWarning();
                    inputField.text = "";
                }
            }
        }
        else
        {
            inputField.text = "";
        }
    }

    private bool IsInputFieldTyped()
    {
        if (inputField.text != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
