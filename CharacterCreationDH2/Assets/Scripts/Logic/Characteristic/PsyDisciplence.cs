using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsyDisciplence 
{
    private string name, textDescription, school;
    private int cost;
    
    public string Name { get { return name; } }
    public string Description { get { return textDescription; } }
    public string School { get { return school; } }
    public int Cost { get { return cost; } }
    public PsyDisciplence(string name, string textDescription, string school, int cost)
    {
        this.name = name;
        this.textDescription = textDescription;
        this.school = school;
        this.cost = cost;
    }
}
