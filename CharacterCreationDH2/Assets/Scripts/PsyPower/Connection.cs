public class Connection
{
    private PsyPower parentPsyPower;
    private PsyPower childPsyPower;

    public Connection(PsyPower parentPsyPower, PsyPower childPsyPower)
    {
        this.parentPsyPower = parentPsyPower;
        this.childPsyPower = childPsyPower;
    }

    public PsyPower ParentPsyPower => parentPsyPower; 
    public PsyPower ChildPsyPower => childPsyPower; 
}
