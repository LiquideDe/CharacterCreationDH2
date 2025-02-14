using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CreatorRole : ICreator
{
    public event Action CreatingRoleIsDone;
    private List<Role> _roles = new List<Role>();

    public void CreateRoles(CreatorTalents creatorTalents)
    {
        CreateRoleAsync(creatorTalents).Forget();
    }

    public int Count => _roles.Count;

    public IHistoryCharacter Get(int id)
    {
        return _roles[id];
    }

    private async UniTask CreateRoleAsync(CreatorTalents creatorTalents)
    {
        List<string> dirs = new List<string>();
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Roles"));
        foreach (string dir in dirs)
        {
            _roles.Add(new Role(dir, creatorTalents));
            await UniTask.Yield();
        }
        CreatingRoleIsDone?.Invoke();
    }
}
