using UnityEngine;
using UnityEngine.UI;

namespace CharacterCreation
{
    public class MyToggle : Toggle
    {
        private int id;
        [SerializeField] Text text;

        public int Id { get => id; set => id = value; }
        public Text Text { get => text; }
    }
}

