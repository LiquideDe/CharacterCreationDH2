using UnityEngine;
using UnityEngine.UI;
using System;

namespace CharacterCreation
{
    public class FinalMenuView : AnimateShowAndHideView
    {
        [SerializeField] Button _buttonSaveAndExitToMenu, _buttonSaveAndExit, _buttonExitToMenu, _buttonExit;

        public event Action SaveAndExitToMenu, SaveAndExit, ExitToMenu, Exit;

        private void OnEnable()
        {
            _buttonSaveAndExitToMenu.onClick.AddListener(SaveAndExitToMenuPressed);
            _buttonSaveAndExitToMenu.onClick.AddListener(_audio.PlayClick);
            _buttonSaveAndExit.onClick.AddListener(SaveAndExitPressed);
            _buttonSaveAndExit.onClick.AddListener(_audio.PlayClick);
            _buttonExitToMenu.onClick.AddListener(ExitToMenuPressed);
            _buttonExitToMenu.onClick.AddListener(_audio.PlayClick);
            _buttonExit.onClick.AddListener(ExitPressed);
            _buttonExit.onClick.AddListener(_audio.PlayClick);
        }

        private void OnDisable()
        {
            _buttonSaveAndExitToMenu.onClick.RemoveAllListeners();
            _buttonSaveAndExit.onClick.RemoveAllListeners();
            _buttonExitToMenu.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
        }

        private void SaveAndExitToMenuPressed() => Hide(SaveAndExitToMenu);

        private void SaveAndExitPressed() => Hide(SaveAndExit);

        private void ExitToMenuPressed() => Hide(ExitToMenu);

        private void ExitPressed() => Hide(Exit);
    }
}

