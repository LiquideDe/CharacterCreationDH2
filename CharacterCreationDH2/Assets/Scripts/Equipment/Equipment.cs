public class Equipment : IName
{
    private string nameEquipment, description, rarity;
    private float weight;
    private int amount;
    public enum TypeEquipment
    {
        Thing, Melee, Range, Armor, Special, Grenade
    }
    protected TypeEquipment typeEquipment;
    public Equipment(string nameEquipment, string description, string rarity, int amount=1, float weight = 0)
    {
        this.nameEquipment = nameEquipment;
        this.description = description;
        typeEquipment = TypeEquipment.Thing;
        this.weight = weight;
        this.rarity = rarity;
        this.amount = amount;
    }

    public Equipment(Equipment equipment)
    {
        nameEquipment = equipment.Name;
        description = equipment.Description;
        rarity = equipment.Rarity;
        weight = equipment.Weight;
        amount = equipment.Amount;
        typeEquipment = equipment.TypeEq;
    }

    public string NameWithAmount => GetName(); 
    public string Name => nameEquipment;

    public string Description => description; 
    public TypeEquipment TypeEq => typeEquipment; 
    public float Weight => weight; 
    public string Rarity => rarity; 
    public int Amount { get => amount; set => amount = value; }

    private string GetName()
    {
        if(amount < 2)
        {
            return nameEquipment;
        }

        return $"{nameEquipment}-{amount} רע.";
    }
}
