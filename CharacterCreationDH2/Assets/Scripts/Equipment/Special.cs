using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : Equipment
{
    private string firstName, secondName;
    private int amountFirst, amountSecond;
    public Special(JSONSpecialReader specialReader): base (specialReader.name, specialReader.description, "")
    {
        typeEquipment = TypeEquipment.Special;
        firstName = specialReader.firstEquipment;
        secondName = specialReader.secondEquipment;
        amountFirst = specialReader.amountFirst;
        amountSecond = specialReader.amountSecond;
    }

    public string FirstName { get => firstName; }
    public string SecondName { get => secondName; }
    public int AmountFirst { get => amountFirst; }
    public int AmountSecond { get => amountSecond; }
}
