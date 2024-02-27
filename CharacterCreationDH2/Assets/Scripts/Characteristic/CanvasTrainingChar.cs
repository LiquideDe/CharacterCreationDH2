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
    private List<CharacteristicPanel> characteristicPanels = new List<CharacteristicPanel>();
    [SerializeField] GameObject charPanel, grid;
    [SerializeField] TextMeshProUGUI textExp;

    public void ShowCharacteristicPanels(Character character)
    {
        gameObject.SetActive(true);
        this.character = character;
        exp = character.ExperienceUnspent;
        UpdateExpText();
        int ch = 0;
        foreach(Characteristic characteristic in character.Characteristics)
        {
            GameObject cp = Instantiate(charPanel, grid.transform);
            cp.SetActive(true);
            characteristicPanels.Add(cp.GetComponent<CharacteristicPanel>());
            if(characteristic.InternalName != GameStat.CharacterName.Influence)
            {
                characteristicPanels[^1].SetParams(character, ch);
                characteristicPanels[^1].RegDelegate(CheckExp);
            }
            else
            {
                characteristicPanels[^1].SetParams(character, ch, true);
                characteristicPanels[^1].RegDelegate(CheckExp);
            }
            
            ch++;
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
        nextPanelSkill?.Invoke();
        Destroy(gameObject);
    }
}
