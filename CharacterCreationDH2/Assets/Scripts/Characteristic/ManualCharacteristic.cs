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
    AudioWork audioWork;

    public void ShowManual(Finish finish, Character character, int averageLvl, AudioWork audioWork)
    {
        this.finish = finish;
        this.audioWork = audioWork;
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
            audioWork.PlayClick();
            totalPoints--;
            character.Characteristics[id].Amount++;
            textAmounts[id].text = character.Characteristics[id].Amount.ToString();
            textTotalPoints.text = $"Осталось очков: {totalPoints}";
        }
        else
        {
            audioWork.PlayWarning();
        }
        
    }

    public void MinusAmount(int id)
    {
        if(character.Characteristics[id].Amount - 1 >= baseAmounts[id])
        {
            audioWork.PlayClick();
            character.Characteristics[id].Amount--;
            textAmounts[id].text = character.Characteristics[id].Amount.ToString();
            totalPoints++;
            textTotalPoints.text = $"Осталось очков: {totalPoints}";
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

    public void CloseManual()
    {
        audioWork.PlayDone();
        finish?.Invoke();
        Destroy(gameObject);
    }
}
