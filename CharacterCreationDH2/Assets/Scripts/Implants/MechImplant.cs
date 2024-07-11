using System;

public class MechImplant : IName
{
    public enum PartsOfBody { Head, RightHand, LeftHand, Body, RightLeg, LeftLeg, All};
    private string _name;
    private string _textDescription;
    public PartsOfBody Place { get; set; }
    public int Armor { get; set; }
    public string Name =>_name; 
    public string Description { get { return _textDescription; } set => _textDescription = value; }
    public int BonusToughness { get; set; }

    public MechImplant(string name, string textDescription)
    {
        this._name = name;
        this._textDescription = textDescription;
    }

    public MechImplant(string name)
    {
        this._name = name;
    }

    public MechImplant(string name, PartsOfBody place, int armor, string description, int bonusToughness)
    {
        this._name = name;
        Place = place;
        Armor = armor;
        _textDescription = description;
        BonusToughness = bonusToughness;
    }

    public MechImplant(SaveLoadImplant implantSave)
    {
        _name = implantSave.name;
        Place = (PartsOfBody)Enum.Parse(typeof(PartsOfBody),implantSave.partsOfBody);
        Armor = implantSave.armor;
        _textDescription = implantSave.description;
        BonusToughness = implantSave.bonusToughness;
    }

    public MechImplant(MechImplant implant)
    {
        _name = implant.Name;
        Place = implant.Place;
        Armor = implant.Armor;
        _textDescription = implant.Description;
        BonusToughness = implant.BonusToughness;
    }

}
