using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasTrainingChar : MonoBehaviour
{
    public delegate void NextPanelSkill();
    NextPanelSkill nextPanelSkill;
    private int exp;
    private Character character;
    [SerializeField] List<CharacteristicPanel> characteristicPanels;
    [SerializeField] GameObject charPanel, grid;
    [SerializeField] TextMeshProUGUI textExp;
    AudioWork audioWork;

    public void ShowCharacteristicPanels(Character character, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        gameObject.SetActive(true);
        this.character = character;
        exp = character.ExperienceUnspent;
        UpdateExpText();
        for(int i = 0; i < characteristicPanels.Count; i++)
        {
            if (character.Characteristics[i].InternalName != GameStat.CharacterName.Influence)
            {
                characteristicPanels[i].SetParams(character, i, audioWork);
                characteristicPanels[i].RegDelegate(CheckExp);
            }
            else
            {
                characteristicPanels[i].SetParams(character, i, audioWork,true);
                characteristicPanels[i].RegDelegate(CheckExp);
            }
        }
    }

    private bool CheckExp(int cost, int id)
    {
        if(cost > exp)
        {
            return false;
        }
        else if(character.Characteristics[id].Amount < 95)
        {
            exp -= cost;
            UpdateExpText();
            
            character.ExperienceSpent += cost;
            character.ExperienceTotal += cost;
            character.ExperienceUnspent -= cost;
            if(character.Characteristics[id].InternalName != GameStat.CharacterName.Influence)
            {
                character.Characteristics[id].SetNewLvl();
                return true;
            }
            else
            {
                character.Characteristics[id].Amount += 5;
                characteristicPanels[id].AddAmount(5);
                                
                return false;                
            }            
        }
        else
        {
            return false;
        }
    }

    private void UpdateExpText()
    {
        textExp.text = $"нн - {exp}";
    }

    public void RegDelegate(NextPanelSkill nextPanelSkill)
    {
        this.nextPanelSkill = nextPanelSkill;
    }

    public void NextButton()
    {
        audioWork.PlayClick();
        nextPanelSkill?.Invoke();
        Destroy(gameObject);
    }
}
