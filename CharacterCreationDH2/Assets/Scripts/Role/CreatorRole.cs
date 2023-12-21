using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorRole 
{
    private List<Role> roles = new List<Role>();
    int id;
    public CreatorRole()
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Roles"));
        foreach(string dir in dirs)
        {
            roles.Add(new Role(dir));
        }

       
    }

    public Role GetNextRole()
    {
        if (id + 1 < roles.Count)
        {
            id += 1;
        }
        else
        {
            id = 0;
        }
        return roles[id];
    }

    public Role GetPrevRole()
    {
        if (id - 1 < 0)
        {
            id = roles.Count - 1;
        }
        else
        {
            id -= 1;
        }
        return roles[id];
    }

    
}
