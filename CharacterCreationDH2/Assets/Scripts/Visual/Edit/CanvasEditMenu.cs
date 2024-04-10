using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasEditMenu : MonoBehaviour
{
    [SerializeField] ItemInList itemInListExample;
    [SerializeField] TextMeshProUGUI textName, textCorPoint, textMadPoint, textWound, textFatePoints;
    [SerializeField] Transform contentListMutation, contentListMental;
    [SerializeField] ControlerEquipmentsAndImplants equipAndImplants;
    [SerializeField] AmountCharacteristicChanger characteristicChanger;
    [SerializeField] PanelWithInputText panelWithInputTextExample;
    private Character character;
    public delegate void NextMenu();
    NextMenu nextMenu;
    public delegate void PrevMenu();
    PrevMenu prevMenu;
    public delegate void Done();
    Done done;
    AudioWork audioWork;


    public void ShowEditor(Character character, CreatorEquipment creatorEquipment, CreatorImplant creatorImplant, NextMenu nextMenu, PrevMenu prevMenu, Done done, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        textName.text = character.Name;
        textCorPoint.text = character.CorruptionPoints.ToString();
        textMadPoint.text = character.InsanityPoints.ToString();
        textWound.text = character.Wounds.ToString();
        textFatePoints.text = character.FatePoint.ToString();
        this.character = character;
        equipAndImplants.SetParams(character, creatorEquipment, creatorImplant, audioWork);
        characteristicChanger.SetParams(character, audioWork);
        this.nextMenu = nextMenu;
        this.done = done;
        this.prevMenu = prevMenu;
        gameObject.SetActive(true);

        foreach (string mutation in character.Mutation)
        {
            ItemInList itemInList = Instantiate(itemInListExample, contentListMutation);
            itemInList.SetParams(mutation, DeleteMutation, audioWork);
        }

        foreach (string mental in character.MentalDisorders)
        {
            ItemInList itemInList = Instantiate(itemInListExample, contentListMental);
            itemInList.SetParams(mental, DeleteMentalDisorders, audioWork);
        }
    }

    private void DeleteMutation(string name)
    {
        foreach (string mut in character.Mutation)
        {
            if (string.Compare(mut, name, true) == 0)
            {
                audioWork.PlayCancel();
                character.Mutation.Remove(mut);
                break;
            }
        }
    }

    private void DeleteMentalDisorders(string name)
    {
        foreach (string ment in character.MentalDisorders)
        {
            if (string.Compare(ment, name, true) == 0)
            {
                audioWork.PlayCancel();
                character.Mutation.Remove(ment);
                break;
            }
        }
    }

    public void PlusCorruption()
    {
        if(character.CorruptionPoints < 100)
        {
            audioWork.PlayClick();
            character.CorruptionPoints += 1;
            textCorPoint.text = character.CorruptionPoints.ToString();
        }
        else
        {
            audioWork.PlayWarning();
        }
        
    }

    public void MinusCorruption()
    {
        if(character.CorruptionPoints > 0)
        {
            audioWork.PlayClick();
            character.CorruptionPoints -= 1;
            textCorPoint.text = character.CorruptionPoints.ToString();
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

    public void PlusInsanity()
    {
        if(character.InsanityPoints < 100)
        {
            audioWork.PlayClick();
            character.InsanityPoints += 1;
            textMadPoint.text = character.InsanityPoints.ToString();
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

    public void MinusInsanity()
    {
        if(character.InsanityPoints > 0)
        {
            audioWork.PlayClick();
            character.InsanityPoints -= 1;
            textMadPoint.text = character.InsanityPoints.ToString();
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

    public void PlusWound()
    {
        audioWork.PlayClick();
        character.Wounds += 1;
        textWound.text = character.Wounds.ToString();
    }

    public void MinusWound()
    {
        if(character.Wounds > -10)
        {
            audioWork.PlayClick();
            character.Wounds -= 1;
            textWound.text = character.Wounds.ToString();
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

    public void PlusFate()
    {
        audioWork.PlayClick();
        character.FatePoint += 1;
        textFatePoints.text = character.FatePoint.ToString();
    }

    public void MinusFate()
    {
        if (character.FatePoint > 0)
        {
            audioWork.PlayClick();
            character.FatePoint -= 1;
            textFatePoints.text = character.FatePoint.ToString();
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

    public void Next()
    {
        audioWork.PlayClick();
        nextMenu?.Invoke();
        Destroy(gameObject);
    }

    public void Prev()
    {
        audioWork.PlayClick();
        prevMenu?.Invoke();
        Destroy(gameObject);
    }

    public void CreateMutation()
    {
        audioWork.PlayClick();
        var panelWithInputText = Instantiate(panelWithInputTextExample, transform);
        panelWithInputText.Init(SetMutation, audioWork);
    }

    public void CreateMental()
    {
        audioWork.PlayClick();
        var panelWithInputText = Instantiate(panelWithInputTextExample, transform);
        panelWithInputText.Init(SetMental, audioWork);
    }

    private void SetMutation(string name)
    {
        character.Mutation.Add(name);
        ItemInList itemInList = Instantiate(itemInListExample, contentListMutation);
        itemInList.SetParams(name, DeleteMutation, audioWork);
    }

    private void SetMental(string name)
    {
        character.MentalDisorders.Add(name);
        ItemInList itemInList = Instantiate(itemInListExample, contentListMental);
        itemInList.SetParams(name, DeleteMentalDisorders, audioWork);
    }

    public void ShowEndMenu()
    {
        audioWork.PlayDone();
        done?.Invoke();
        Destroy(gameObject);
    }

    public void PlayClick()
    {
        audioWork.PlayClick();
    }
}
