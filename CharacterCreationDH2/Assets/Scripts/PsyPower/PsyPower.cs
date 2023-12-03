using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PsyPower
{
    private string namePower, description, action;
    private int cost, psyRateRequire, id, lvl, idParent;
    private bool isBase, isActive;
    private Characteristic[] requireCharacteristics = new Characteristic[9];
    private string textCost;


    
    public PsyPower(string namePower, string description, int cost, int psyRateRequire, int id, int lvl,string action, int idParent, Characteristic[] requireCharacteristics, bool isActive = false)
    {
        if (id == 0)
        {
            isBase = true;
        }

        this.isActive = isActive;
        this.namePower = namePower;
        this.description = description;
        this.cost = cost;
        this.psyRateRequire = psyRateRequire;
        this.id = id;
        this.action = action;
        this.lvl = lvl;
        this.idParent = idParent;
        this.requireCharacteristics =  requireCharacteristics;        
        UpdateTextCost();
    }

    private void UpdateTextCost()
    {
        textCost = $"нн {cost}";
        textCost += $", оп{psyRateRequire}";
        foreach (Characteristic characteristic in requireCharacteristics)
        {           
            if (characteristic.Amount > 0)
            {
                textCost += $", {characteristic.Name} {characteristic.Amount}";
            }
        }
    }

    public string NamePower { get => namePower; }
    public string Description { get => description; }
    public int Cost { get => cost; }
    public int PsyRateRequire { get => psyRateRequire; }
    public int Id { get => id; }
    public bool IsActive { get => isActive; }
    public bool IsBase { get => isBase; }
    public string Action { get => action; }
    public int Lvl { get => lvl; }
    public int IdParent { get => idParent; }
    public Characteristic[] RequireCharacteristics { get => requireCharacteristics; }
    public string TextCost { get => textCost; }

    public void ActivatePower()
    {
        isActive = true;
    }

    public void DeactivatePower()
    {
        isActive = false;
    }

}
