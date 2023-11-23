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

    public void CreatePanels(Character character)
    {
        this.character = character;
        exp = character.ExperienceUnspent;
        UpdateExpText();
        int ch = 0;
        foreach(Characteristic characteristic in character.Characteristics)
        {
            GameObject cp = Instantiate(charPanel);
            cp.SetActive(true);
            cp.transform.SetParent(grid.transform);
            characteristicPanels.Add(cp.GetComponent<CharacteristicPanel>());
            characteristicPanels[^1].SetParams(character, ch);
            characteristicPanels[^1].RegDelegate(CheckExp);
            
            ch++;
        }
    }

    private bool CheckExp(int cost, int id)
    {
        if(cost > exp)
        {
            return false;
        }
        else
        {
            exp -= cost;
            UpdateExpText();
            character.Characteristics[id].SetNewLvl();
            character.ExperienceSpent += cost;
            character.ExperienceTotal += cost;
            character.ExperienceUnspent -= cost;
            return true;
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
