using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : Equipment
{
    private string firstName, secondName;
    public Special(string nameEquipment, string description, string firstName, string secondName): base (nameEquipment, description)
    {
        typeEquipment = TypeEquipment.Special;
        this.firstName = firstName;
        this.secondName = secondName;
    }

    public string FirstName { get => firstName; }
    public string SecondName { get => secondName; }
}
