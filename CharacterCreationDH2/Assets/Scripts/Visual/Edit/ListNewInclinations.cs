using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListNewInclinations : MonoBehaviour
{
    public delegate void ReturnNameInclination(string name);
    ReturnNameInclination returnInclination;
    [SerializeField] Transform content;
    [SerializeField] ItemListActiveButton itemExample;
    private List<ItemListActiveButton> activeButtons = new List<ItemListActiveButton>();
    AudioWork audioWork;

    public void SetParams(List<GameStat.Inclinations> inclinationsCharacter, ReturnNameInclination returnInclination, AudioWork audioWork)
    {
        gameObject.SetActive(true);
        this.audioWork = audioWork;
        this.returnInclination = returnInclination;
        foreach (GameStat.Inclinations inclination in Enum.GetValues(typeof(GameStat.Inclinations)))
        {
            int sch = 0;
            foreach (GameStat.Inclinations charIncl in inclinationsCharacter)
            {
                if (inclination == charIncl)
                {
                    sch++;
                    break;
                }
            }
            if (sch < 1 && inclination != GameStat.Inclinations.None && inclination != GameStat.Inclinations.Elite)
            {
                activeButtons.Add(Instantiate(itemExample, content));
                activeButtons[^1].SetParams(GameStat.inclinationTranslate[inclination], ChooseThisInclination, audioWork);
            }
        }
    }

    private void ChooseThisInclination(string name)
    {
        audioWork.PlayDone();
        returnInclination?.Invoke(name);
        Destroy(gameObject);
    }

    public void Cancel()
    {
        audioWork.PlayCancel();
        Destroy(gameObject);
    }
}
