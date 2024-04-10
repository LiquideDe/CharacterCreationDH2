using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InclinationList : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] ItemInList itemExample;
    [SerializeField] ListNewInclinations listNewInclinationsExample;
    private List<ItemInList> itemInclinations = new List<ItemInList>();
    List<GameStat.Inclinations> inclinationsCharacter = new List<GameStat.Inclinations>();
    AudioWork audioWork;

    public void SetParams(List<GameStat.Inclinations> inclinationsCharacter, AudioWork audioWork)
    {
        gameObject.SetActive(true);
        this.audioWork = audioWork;
        this.inclinationsCharacter = inclinationsCharacter;
        foreach(GameStat.Inclinations charIncl in inclinationsCharacter)
        {
            itemInclinations.Add(Instantiate(itemExample, content));
            itemInclinations[^1].SetParams(GameStat.inclinationTranslate[charIncl], RemoveThisInclination, audioWork);
        }
    }

    private void RemoveThisInclination(string name)
    {
        foreach(GameStat.Inclinations charIncl in inclinationsCharacter)
        {
            if(string.Compare(name, GameStat.inclinationTranslate[charIncl]) == 0)
            {
                audioWork.PlayCancel();
                inclinationsCharacter.Remove(charIncl);
                break;
            }
        }
    }

    public void ShowListWithNewInclination()
    {
        audioWork.PlayClick();
        Canvas canvas = GetComponentInParent<Canvas>();
        var listNewInclinations = Instantiate(listNewInclinationsExample, canvas.transform);
        listNewInclinations.SetParams(inclinationsCharacter, AddThisInclination, audioWork);
    }

    private void AddThisInclination(string name)
    {        
        foreach(GameStat.Inclinations inclination in Enum.GetValues(typeof(GameStat.Inclinations)))
        {
            if(inclination != GameStat.Inclinations.None && string.Compare(name, GameStat.inclinationTranslate[inclination], true) == 0)
            {
                inclinationsCharacter.Add(inclination);
                itemInclinations.Add(Instantiate(itemExample, content));
                itemInclinations[^1].SetParams(GameStat.inclinationTranslate[inclination], RemoveThisInclination, audioWork);
                break;
            }
        }        
    }
}
