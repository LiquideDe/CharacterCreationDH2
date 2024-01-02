using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManualCharacteristic : MonoBehaviour
{
    public delegate void Finish();
    Finish finish;
    [SerializeField] TextMeshProUGUI[] textAmounts;
    [SerializeField] TextMeshProUGUI textTotalPoints;
    Character character;
    int maxAmount, totalPoints;
    List<int> baseAmounts = new List<int>();

    public void ShowManual(Finish finish, Character character, int averageLvl)
    {
        this.finish = finish;
        character.GetCharacteristicsForGenerate(averageLvl);
        for(int i = 0; i < character.Characteristics.Count; i++)
        {
            textAmounts[i].text = character.Characteristics[i].Amount.ToString();
            baseAmounts.Add(character.Characteristics[i].Amount);
        }
        this.character = character;
        if(averageLvl <= 25)
        {
            maxAmount = 40;
        }
        else
        {
            maxAmount = 45;
        }
        totalPoints = 60;
    }

    public void PlusAmount(int id)
    {        
        if(totalPoints > 0 && character.Characteristics[id].Amount < maxAmount)
        {
            totalPoints--;
            character.Characteristics[id].Amount++;
            textAmounts[id].text = character.Characteristics[id].Amount.ToString();
            textTotalPoints.text = $"Осталось очков: {totalPoints}";
        }
        
    }

    public void MinusAmount(int id)
    {
        if(character.Characteristics[id].Amount - 1 >= baseAmounts[id])
        {
            character.Characteristics[id].Amount--;
            textAmounts[id].text = character.Characteristics[id].Amount.ToString();
            totalPoints++;
            textTotalPoints.text = $"Осталось очков: {totalPoints}";
        }
        
    }

    public void CloseManual()
    {
        finish?.Invoke();
        Destroy(gameObject);
    }
}
