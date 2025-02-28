using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

namespace CharacterCreation
{
    public class CreatorWorlds : ICreator
    {
        public event Action CreateWorldIsFinished;
        private List<Homeworld> homeworlds = new List<Homeworld>();

        public void CreateWorlds(CreatorSkills creatorSkills)
        {
            CreateWorldsAsync(creatorSkills).Forget();
        }

        public int Count => homeworlds.Count;

        public IHistoryCharacter Get(int id)
        {
            return homeworlds[id];
        }

        private async UniTask CreateWorldsAsync(CreatorSkills creatorSkills)
        {
            List<string> dirs = new List<string>();
            dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Worlds"));
            for (int i = 0; i < dirs.Count; i++)
            {
                homeworlds.Add(new Homeworld(dirs[i], creatorSkills));
                await UniTask.Yield();
            }
            CreateWorldIsFinished?.Invoke();
        }
    }
}

