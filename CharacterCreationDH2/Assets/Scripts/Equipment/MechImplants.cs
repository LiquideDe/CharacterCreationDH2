using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechImplants
{
    private string name;
    private string textDescription;

    public string Name { get { return name; } }
    public string Description { get { return textDescription; } }

    public MechImplants(string name, string textDescription)
    {
        this.name = name;
        this.textDescription = textDescription;
    }

    public MechImplants(string name)
    {
        this.name = name;
    }
}
