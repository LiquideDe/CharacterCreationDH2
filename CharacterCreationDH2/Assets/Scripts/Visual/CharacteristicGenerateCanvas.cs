using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteristicGenerateCanvas : MonoBehaviour
{
    public delegate void CharacteristicsGenerated(List<Characteristic> characteristics);
    private CharacteristicsGenerated characteristicsGenerated;
    [SerializeField] GameObject characteristicPanel, randomCard, gridCards, gridRandomCards;
    private List<Characteristic> characteristics;
    private List<CharacteristicCard> characteristicCards = new List<CharacteristicCard>();

    public void GenerateCharacteristics(Character character)
    {
        gameObject.SetActive(true);
        characteristics = new List<Characteristic>(character.GetCharacteristicsForGenerate());
        foreach(Characteristic characteristic in characteristics)
        {
            GameObject gameObject = Instantiate(characteristicPanel);
            gameObject.transform.SetParent(gridCards.transform);
            gameObject.SetActive(true);
            CharacteristicCard characteristicCard = gameObject.GetComponent<CharacteristicCard>();
            characteristicCard.SetTextName(characteristic.Name);
            characteristicCard.SetAmount(characteristic.Amount);
            characteristicCards.Add(characteristicCard);
            GameObject gameObject1 = Instantiate(randomCard);
            gameObject1.transform.SetParent(gridRandomCards.transform);
            gameObject1.SetActive(true);
        }
    }

    public void GenerateFinished()
    {
        for(int i = 0; i < characteristicCards.Count; i++)
        {
            characteristics[i].Amount = characteristicCards[i].Amount;
        }
        characteristicsGenerated?.Invoke(characteristics);
        Destroy(gameObject);
    }

    public void RegDelegateFinish(CharacteristicsGenerated characteristicsGenerated)
    {
        this.characteristicsGenerated = characteristicsGenerated;
    }
}