using UnityEngine;
using DG.Tweening;
using System;
using Zenject;
using System.Collections.Generic;

namespace CharacterCreation
{
    public class AnimateShowAndHideView : CanDestroyView
    {
        [SerializeField] private CanvasGroup _bodyGroup;
        [SerializeField] private RectTransform _bodyTransform;
        protected AudioManager _audio;

        [Inject]
        private void Construct(AudioManager audioManager) => _audio = audioManager;

        public void Show()
        {
            if (_bodyGroup != null || _bodyTransform != null)
            {
                Vector2 targetBodyPosition = _bodyTransform.anchoredPosition;
                Vector2 startShift = new Vector2(Screen.width / 2, targetBodyPosition.y);
                _audio.PlayPopUp();
                Sequence animation = DOTween.Sequence();

                animation.Append(_bodyGroup.DOFade(1, 1f).From(0)).Join(_bodyTransform.DOAnchorPos(targetBodyPosition, 1f).From(startShift));
            }

        }

        public void ShowFromLeft()
        {
            Vector2 targetBodyPosition = _bodyTransform.anchoredPosition;
            Vector2 startShift = new Vector2(-Screen.width / 2, targetBodyPosition.y);
            _audio.PlayPopUp();
            Sequence animation = DOTween.Sequence();

            animation.Append(_bodyGroup.DOFade(1, 1f).From(0)).Join(_bodyTransform.DOAnchorPos(targetBodyPosition, 1f).From(startShift));
        }

        public void Hide(Action HideIsDone)
        {
            Vector2 targetBodyPosition = _bodyTransform.anchoredPosition;
            Vector2 finishShift = new Vector2(-Screen.width / 2, targetBodyPosition.y);
            _audio.PlayPopDown();
            Sequence animation = DOTween.Sequence();

            animation.Append(_bodyGroup.DOFade(0, 1f).From(1)).Join(_bodyTransform.DOAnchorPos(finishShift, 1f).From(targetBodyPosition)).
                OnComplete(() => HideIsDone?.Invoke());
        }

        public void HideRight(Action HideIsDone)
        {
            Vector2 targetBodyPosition = _bodyTransform.anchoredPosition;
            Vector2 finishShift = new Vector2(Screen.width / 2, targetBodyPosition.y);
            _audio.PlayPopDown();
            Sequence animation = DOTween.Sequence();

            animation.Append(_bodyGroup.DOFade(0, 1f).From(1)).Join(_bodyTransform.DOAnchorPos(finishShift, 1f).From(targetBodyPosition)).
                OnComplete(() => HideIsDone?.Invoke());
        }

        public void HideRight(Action<string> HideIsDone, string text)
        {
            Vector2 targetBodyPosition = _bodyTransform.anchoredPosition;
            Vector2 finishShift = new Vector2(Screen.width / 2, targetBodyPosition.y);
            _audio.PlayPopDown();
            Sequence animation = DOTween.Sequence();

            animation.Append(_bodyGroup.DOFade(0, 1f).From(1)).Join(_bodyTransform.DOAnchorPos(finishShift, 1f).From(targetBodyPosition)).
                OnComplete(() => HideIsDone?.Invoke(text));
        }

        public void HideRight(Action<CanDestroyView> HideIsDone, CanDestroyView canDestroyView)
        {
            Vector2 targetBodyPosition = _bodyTransform.anchoredPosition;
            Vector2 finishShift = new Vector2(Screen.width / 2, targetBodyPosition.y);
            _audio.PlayPopDown();
            Sequence animation = DOTween.Sequence();

            animation.Append(_bodyGroup.DOFade(0, 1f).From(1)).Join(_bodyTransform.DOAnchorPos(finishShift, 1f).From(targetBodyPosition)).
                OnComplete(() => HideIsDone?.Invoke(canDestroyView));
        }

        public void Hide(Action<List<int>> HideIsDone, List<int> ints)
        {
            Vector2 targetBodyPosition = _bodyTransform.anchoredPosition;
            Vector2 finishShift = new Vector2(-Screen.width / 2, targetBodyPosition.y);
            _audio.PlayPopDown();
            Sequence animation = DOTween.Sequence();

            animation.Append(_bodyGroup.DOFade(0, 1f).From(1)).Join(_bodyTransform.DOAnchorPos(finishShift, 1f).From(targetBodyPosition)).
                OnComplete(() => HideIsDone?.Invoke(ints));
        }

    }
}

