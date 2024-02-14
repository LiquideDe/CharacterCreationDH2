using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : Equipment
{
    private string firstName, secondName;
    public Special(JSONSpecialReader specialReader): base (specialReader.name, specialReader.description, "")
    {
        typeEquipment = TypeEquipment.Special;
        firstName = specialReader.firstEquipment;
        secondName = specialReader.secondEquipment;
    }

    public string FirstName { get => firstName; }
    public string SecondName { get => secondName; }
}
