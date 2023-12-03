using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class CardWithGenerater : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] CardWithNumber cardWithNumber;
    [SerializeField] GameObject button;
    

    private int GenerateValue(int max)
    {
        //return UnityEngine.Random.Range(1, max);
        System.Random random = new System.Random();
        return random.Next(3, max);
    }

    public void GenerateFromButton()
    {
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
                    CloseGenerator(number);
                }
                else
                {
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
