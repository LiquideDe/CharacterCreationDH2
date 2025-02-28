using UnityEngine;
using TMPro;
using System;

namespace CharacterCreation
{
    public class SetExperienceView : ViewWithButtonsDoneAndCancel
    {
        [SerializeField] private TMP_InputField _inputExperience;

        public event Action<string> InputDone;

        protected override void ButtonDonePressed()
        {
            InputDone?.Invoke(_inputExperience.text);
        }
    }
}

