
public class Feature
{
    private string _name;
    private int _lvl;
    private string _description;


    public string Name  => _name; 
    public int Lvl { get => _lvl; set => _lvl = value; }
    public string Description => _description;

    public Feature(string name, int lvl)
    {
        _name = name;
        _lvl = lvl;
    }

    public Feature(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public Feature(Feature feature)
    {
        _name = feature.Name;
        _description = feature.Description;
        _lvl = feature.Lvl;
    }
}
