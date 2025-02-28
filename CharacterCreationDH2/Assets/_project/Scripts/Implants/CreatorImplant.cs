using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace CharacterCreation
{
    public class CreatorImplant
    {
        public event Action CreatingImplantIsDone;
        private List<MechImplant> implants = new List<MechImplant>();
        private AudioManager _audioManager;
        public List<MechImplant> Implants { get => implants; }

        public CreatorImplant(AudioManager audioManager) => _audioManager = audioManager;

        public void StartCreate() => CreateImplant().Forget();

        public void AddImplant(MechImplant implant)
        {
            implants.Add(implant);
        }

        public MechImplant GetImplant(string name)
        {
            foreach (MechImplant implant in implants)
            {
                if (string.Compare(implant.Name, name, true) == 0)
                {
                    return implant;
                }
            }

            Debug.Log($"!!!!ВНИМАНИЕ!!!! Не нашли имплант {name}");
            return null;
        }

        private async UniTask CreateImplant()
        {
            string[] implantsJson = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/Implants", "*.JSON");

            foreach (string implant in implantsJson)
            {
                string[] data = File.ReadAllLines(implant);
                SaveLoadImplant implantSaveLoad = JsonUtility.FromJson<SaveLoadImplant>(data[0]);
                implants.Add(new MechImplant(implantSaveLoad));
                await UniTask.Yield();
            }
            CreatingImplantIsDone?.Invoke();
        }
    }
}

