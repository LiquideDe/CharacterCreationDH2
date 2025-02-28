using System;

namespace CharacterCreation
{
    public class LoadingCanvas : CanDestroyView
    {
        public event Action LoadingIsDone;
        private int _amountReady;
        private int _maxAmount;

        public void SetMaxAmount(int amount) => _maxAmount = amount;

        public void PlusReady()
        {
            _amountReady++;
            if (_amountReady == _maxAmount)
            {
                LoadingIsDone?.Invoke();
                DestroyView();
            }
        }
    }
}

