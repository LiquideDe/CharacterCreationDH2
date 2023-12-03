using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection
{
    private PsyPower parentPsyPower;
    private PsyPower childPsyPower;

    public Connection(PsyPower parentPsyPower, PsyPower childPsyPower)
    {
        this.parentPsyPower = parentPsyPower;
        this.childPsyPower = childPsyPower;
    }

    public PsyPower ParentPsyPower { get => parentPsyPower; }
    public PsyPower ChildPsyPower { get => childPsyPower; }
}
