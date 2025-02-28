using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace CharacterCreation
{
    public class CreatorBackgrounds : ICreator
    {
        public event Action CreateBackgroundIsDone;
        private List<Background> _backgrounds = new List<Background>();

        public void CreateBackgrounds(CreatorSkills creatorSkills, CreatorTalents creatorTalents, CreatorTraits creatorTraits, CreatorImplant creatorImplant)
        {
            CreateBackgroundAsync(creatorSkills, creatorTalents, creatorTraits, creatorImplant).Forget();
        }

        public int Count => _backgrounds.Count;

        IHistoryCharacter ICreator.Get(int id)
        {
            return _backgrounds[id];
        }

        private async UniTask CreateBackgroundAsync(CreatorSkills creatorSkills, CreatorTalents creatorTalents, CreatorTraits creatorTraits, CreatorImplant creatorImplant)
        {
            List<string> dirs = new List<string>();
            dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Backgrounds"));
            for (int i = 0; i < dirs.Count; i++)
            {
                _backgrounds.Add(new Background(dirs[i], creatorSkills, creatorTalents, creatorTraits, creatorImplant));
                await UniTask.Yield();
            }
            CreateBackgroundIsDone?.Invoke();
        }
    }
}

