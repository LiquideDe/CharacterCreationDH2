using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CharacteristicPanel : MonoBehaviour
{
    public delegate bool CheckCost(int cost, int id);
    CheckCost checkCost;
    [SerializeField] ButtonStudy[] buttonStudies;
    [SerializeField] TextMeshProUGUI textName, textDozen, textUnits;
    private List<GameStat.Inclinations> inclinationsThisCharacteristic;
    private int[] costWithZeroIncl = new int[5] {500, 750,1000,1500,2500 };
    private int[] costWithOneIncl = new int[5] {250, 500,750,1000,1500 };
    private int[] costWithTwoIncl = new int[5] {100, 250,500,750,1250 };
    private int amount;
    public int idChar;


    public void SetParams(Character character, int id)
    {
        idChar = id;
        textName.text = $"{character.Characteristics[id].Name}";
        amount = character.Characteristics[id].Amount;
        DivideDozenAndUnits();
        SetInclination(character.Characteristics[id].Inclinations);
        CalculationCosts(character.Inclinations);
        ActivatedTraining(character.Characteristics[id].LvlLearned);
    }
    private void CalculationCosts(List<GameStat.Inclinations> inclinationsHero)
    {
        int sumIncls = 0;
        foreach (GameStat.Inclinations incl in inclinationsHero)
        {
            if (incl == inclinationsThisCharacteristic[0] || incl == inclinationsThisCharacteristic[1])
            {
                sumIncls++;
            }
        }

        if(sumIncls == 0)
        {
            SetCost(costWithZeroIncl);
        }
        else if(sumIncls == 1)
        {
            SetCost(costWithOneIncl);
        }
        else if (sumIncls == 2)
        {
            SetCost(costWithTwoIncl);
        }
        buttonStudies[0].IsPrevButtActive = true;
    }

    private void ActivatedTraining(int lvlLearned)
    {
        for(int i = 0; i < lvlLearned; i++)
        {
            buttonStudies[i].Activated();
            if(i < buttonStudies.Length)
            {
                buttonStudies[i + 1].IsPrevButtActive = true;
            }
        }
    }

    private void SetCost(int[] cost)
    {
        for (int i = 0; i < buttonStudies.Length; i++)
        {
            buttonStudies[i].Cost = cost[i];
            buttonStudies[i].RegDelegate(CheckHavePoints);            
        }
    }

    private void SetInclination(GameStat.Inclinations[] inclinations)
    {
        inclinationsThisCharacteristic = new List<GameStat.Inclinations>(inclinations);
    }
    
    public void RegDelegate(CheckCost checkCost)
    {
        this.checkCost = checkCost;        
    }

    private void CheckHavePoints(int cost, int id)
    {
        if (!(bool)checkCost?.Invoke(cost, idChar))
        {
            buttonStudies[id].CancelOperation();
        }
        else
        {
            amount += 5;
            DivideDozenAndUnits();
            if(id < buttonStudies.Length)
            {
                buttonStudies[id + 1].IsPrevButtActive = true;
            }
        }
    }

    private void DivideDozenAndUnits()
    {
        char[] arr = amount.ToString().ToCharArray();
        textDozen.text = arr[0].ToString();
        textUnits.text = arr[1].ToString();
    }
}
