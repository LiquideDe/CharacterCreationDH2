using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INameWithDescription : IName
{
    string Description { get; }
}
