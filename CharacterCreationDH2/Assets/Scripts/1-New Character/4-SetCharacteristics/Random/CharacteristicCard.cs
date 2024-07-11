using UnityEngine;
using TMPro;
using Zenject;

public class CharacteristicCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textName, _textAmount;
    private AudioManager _audioManager;
    private int _amount;
    private bool _isSetAmountFromRandomCard;

    public bool IsSetAmountFromRandomCard => _isSetAmountFromRandomCard;
    public int Amount => _amount;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void SetAmount(int amount)
    {
        _amount = amount;
        _textAmount.text = $"{amount}";
    }

    public void PlusAmount(int amount)
    {
        _audioManager.PlayClick();
        _isSetAmountFromRandomCard = true;
        _amount += amount;
        _textAmount.color = new Color(0, 239, 195, 255);
        _textAmount.text = $"{_amount}";
    }

    
}
