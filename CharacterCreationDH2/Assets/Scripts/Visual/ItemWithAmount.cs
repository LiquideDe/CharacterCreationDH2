using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ItemWithAmount : ItemInList
{
    [SerializeField] TMP_InputField inputAmount;
    public delegate void ReturnChangeAmount(string name, int amount);
    ReturnChangeAmount returnChangeAmount;

    public void SetAmountAndDelegate(int amount, ReturnChangeAmount returnChangeAmount)
    {        
        inputAmount.text = amount.ToString();
        this.returnChangeAmount = returnChangeAmount;
    }

    public void ChangeAmount()
    {
        CancelSelect();
        int.TryParse(inputAmount.text, out int amount);
        returnChangeAmount?.Invoke(textName.text, amount);
    }

    private void CancelSelect()
    {
        var eventSystem = EventSystem.current;
        if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);
    }
}
