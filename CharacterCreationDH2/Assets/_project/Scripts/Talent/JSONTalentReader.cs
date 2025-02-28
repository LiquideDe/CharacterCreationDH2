using System;

namespace CharacterCreation
{
    [Serializable]
    public class JSONTalentReader
    {
        public string name, inclinationFirst, inclinationSecond;
        public int rank;
        public bool canActivate, repeatable;
    }
}