using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristic 
{
    private GameStat.CharacterName name;
    private GameStat.Inclinations[] inclinations = new GameStat.Inclinations[2];
    private int lvlLearnedChar;
    private int futureLvlLearnedChar;
    private bool isFutureLvl;
    private int amount = 0;

    public string Name { get { return GameStat.characterTranslate[name]; } }
    public GameStat.CharacterName InternalName { get => name; }
    public int LvlLearned { get { return lvlLearnedChar; } }
    public int Amount { get => amount; set => amount = value; }

    public GameStat.Inclinations[] Inclinations { get { return inclinations; } }

    public Characteristic(GameStat.CharacterName name, GameStat.Inclinations firstInclination, GameStat.Inclinations secondInclination)
    {
        this.name = name;
        inclinations[0] = firstInclination;
        inclinations[1] = secondInclination;
    }

    public Characteristic(GameStat.CharacterName name, int amount)
    {
        this.name = name;
        this.amount = amount;
    }

    public void SetNewLvl()
    {
        lvlLearnedChar += 1;
        amount += 5;
    }

    public void SetNewPosibleLvl()
    {
        isFutureLvl = true;
        futureLvlLearnedChar = lvlLearnedChar + 1;
        amount += 5;
    }

    public void CancelNewLvl()
    {
        isFutureLvl = false;
        amount -= 5;
    }

}
