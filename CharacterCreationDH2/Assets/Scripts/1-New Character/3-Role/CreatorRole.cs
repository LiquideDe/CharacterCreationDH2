using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreatorRole : ICreator
{
    private List<Role> _roles = new List<Role>();

    public CreatorRole(CreatorTalents creatorTalents)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Roles"));
        foreach(string dir in dirs)
        {
            _roles.Add(new Role(dir, creatorTalents));
        }       
    }

    public int Count => _roles.Count;

    public IHistoryCharacter Get(int id)
    {
        return _roles[id];
    }

}
