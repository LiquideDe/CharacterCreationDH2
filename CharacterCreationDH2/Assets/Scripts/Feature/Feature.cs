
public class Feature
{
    private string name;
    private int lvl;

    public string Name { get => name; }
    public int Lvl { get => lvl; set => lvl = value; }

    public Feature(string name, int lvl)
    {
        this.name = name;
        this.lvl = lvl;
    }
}
