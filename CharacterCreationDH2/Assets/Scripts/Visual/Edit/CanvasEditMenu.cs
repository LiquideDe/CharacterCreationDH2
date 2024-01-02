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
    [SerializeField] TMP_InputField inputNameMutation, inputNameMental;
    private Character character;
    public delegate void NextMenu();
    NextMenu nextMenu;


    public void ShowEditor(Character character, CreatorEquipment creatorEquipment, NextMenu nextMenu)
    {
        textName.text = character.Name;
        textCorPoint.text = character.CorruptionPoints.ToString();
        textMadPoint.text = character.InsanityPoints.ToString();
        textWound.text = character.Wounds.ToString();
        textFatePoints.text = character.FatePoint.ToString();
        this.character = character;
        equipAndImplants.SetParams(character, creatorEquipment);
        characteristicChanger.SetParams(character);
        this.nextMenu = nextMenu;
        gameObject.SetActive(true);

        foreach (string mutation in character.Mutation)
        {
            ItemInList itemInList = Instantiate(itemInListExample, contentListMutation);
            itemInList.SetParams(mutation, DeleteMutation);
        }

        foreach (string mental in character.MentalDisorders)
        {
            ItemInList itemInList = Instantiate(itemInListExample, contentListMental);
            itemInList.SetParams(mental, DeleteMentalDisorders);
        }
    }

    private void DeleteMutation(string name)
    {
        foreach (string mut in character.Mutation)
        {
            if (string.Compare(mut, name, true) == 0)
            {
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
                character.Mutation.Remove(ment);
                break;
            }
        }
    }

    public void PlusCorruption()
    {
        if(character.CorruptionPoints < 100)
        {
            character.CorruptionPoints += 1;
            textCorPoint.text = character.CorruptionPoints.ToString();
        }
        
    }

    public void MinusCorruption()
    {
        if(character.CorruptionPoints > 0)
        {
            character.CorruptionPoints -= 1;
            textCorPoint.text = character.CorruptionPoints.ToString();
        }        
    }

    public void PlusInsanity()
    {
        if(character.InsanityPoints < 100)
        {
            character.InsanityPoints += 1;
            textMadPoint.text = character.InsanityPoints.ToString();
        }    
    }

    public void MinusInsanity()
    {
        if(character.InsanityPoints > 0)
        {
            character.InsanityPoints -= 1;
            textMadPoint.text = character.InsanityPoints.ToString();
        }        
    }

    public void PlusWound()
    {
        character.Wounds += 1;
        textWound.text = character.Wounds.ToString();
    }

    public void MinusWound()
    {
        if(character.Wounds > 0)
        {
            character.Wounds -= 1;
            textWound.text = character.Wounds.ToString();
        }
    }

    public void PlusFate()
    {
        character.FatePoint += 1;
        textFatePoints.text = character.FatePoint.ToString();
    }

    public void MinusFate()
    {
        if (character.FatePoint > 0)
        {
            character.FatePoint -= 1;
            textFatePoints.text = character.FatePoint.ToString();
        }
    }

    public void Next()
    {
        nextMenu?.Invoke();
        Destroy(gameObject);
    }

    public void CreateMutation()
    {
        if(inputNameMutation.text.Length > 0)
        {
            character.Mutation.Add(inputNameMutation.text);
            ItemInList itemInList = Instantiate(itemInListExample, contentListMutation);
            itemInList.SetParams(inputNameMutation.text, DeleteMutation);
            inputNameMutation.text = "";
        }        
    }

    public void CreateMental()
    {
        if(inputNameMental.text.Length > 0)
        {
            character.MentalDisorders.Add(inputNameMental.text);
            ItemInList itemInList = Instantiate(itemInListExample, contentListMental);
            itemInList.SetParams(inputNameMental.text, DeleteMutation);
            inputNameMental.text = "";
        }        
    }


}
