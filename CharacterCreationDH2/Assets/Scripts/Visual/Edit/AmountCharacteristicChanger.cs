using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmountCharacteristicChanger : MonoBehaviour
{
    Character character;
    [SerializeField] TextMeshProUGUI[] characteristics;
    AudioWork audioWork;

    public void SetParams(Character character, AudioWork audioWork)
    {
        this.character = character;
        this.audioWork = audioWork;
        for (int i = 0; i < character.Characteristics.Count; i++)
        {
            characteristics[i].text = character.Characteristics[i].Amount.ToString();
        }
    }
    public void PlusCharacteristic(int id)
    {
        audioWork.PlayClick();
        character.Characteristics[id].Amount += 1;
        characteristics[id].text = character.Characteristics[id].Amount.ToString();
        character.CalculatePhysAbilities();
    }

    public void MinusCharacteristic(int id)
    {
        audioWork.PlayClick();
        character.Characteristics[id].Amount -= 1;
        characteristics[id].text = character.Characteristics[id].Amount.ToString();
        character.CalculatePhysAbilities();
    }

    
}
