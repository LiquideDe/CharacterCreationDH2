using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class EditPropertyCharacter : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputName, inputHome, inputBack, inputRole, inputProph, inputElite, inputGender, inputAge, inputSkeen, inputBody, inputHair, inputPhysFeat, inputEyes,
        inputTraditions, inputRememberHome, inputRememberBack;
    [SerializeField] InclinationList inclinationList;
    [SerializeField] ListWithFeatures listWithFeatures;
    Character character;
    public delegate void NextWindow();
    NextWindow nextWindow;

    public void SetParams(Character character, CreatorFeatures creatorFeatures, NextWindow nextWindow)
    {
        gameObject.SetActive(true);
        this.character = character;
        inclinationList.SetParams(character.Inclinations);
        listWithFeatures.SetParams(character, creatorFeatures.Features);
        this.nextWindow = nextWindow;

        inputName.text = character.Name;
        inputHome.text = character.Homeworld;
        inputBack.text = character.Background;
        inputRole.text = character.Role;
        inputProph.text = character.Prophecy;
        inputElite.text = character.Elite;
        inputGender.text = character.Gender;
        inputAge.text = character.Age.ToString();
        inputSkeen.text = character.Skeen;
        inputBody.text = character.Constitution;
        inputHair.text = character.Hair;
        inputPhysFeat.text = character.PhysFeatures;
        inputEyes.text = character.Eyes;
        inputTraditions.text = character.Tradition;
        inputRememberHome.text = character.MemoryOfHome;
        inputRememberBack.text = character.MemoryOfBackground;
    }

    private void CancelSelect()
    {
        var eventSystem = EventSystem.current;
        if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);
    }

    public void ChangeProperty()
    {
        CancelSelect();
        int.TryParse(inputAge.text, out int age);
        character.Name = inputName.text;
        character.Homeworld = inputHome.text;
        character.Background = inputBack.text;
        character.Role = inputRole.text;
        character.Prophecy = inputProph.text;
        character.Elite = inputElite.text;
        character.Gender = inputGender.text;
        character.Age = age;
        character.Skeen = inputSkeen.text;
        character.Constitution = inputBody.text;
        character.Hair = inputHair.text;
        character.PhysFeatures = inputPhysFeat.text;
        character.Eyes = inputEyes.text;
        character.Tradition = inputTraditions.text;
        character.MemoryOfHome = inputRememberHome.text;
        character.MemoryOfBackground = inputRememberBack.text;
    }

    public void Next()
    {
        nextWindow?.Invoke();
        Destroy(gameObject);
    }
}
