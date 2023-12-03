using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class CharacteristicCard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textName, textAmount;

    public void SetTextName(string name)
    {
        textName.text = name;
    }

    public void SetAmount(int amount)
    {
        textAmount.text = $"{amount}";
    }

    public void PlusAmount(int amount)
    {
        textAmount.text = $"{int.Parse(textAmount.text) + amount}";
    }

    public int Amount { get => int.Parse(textAmount.text); }
}
