using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EditCharacteristicsAndEquipmentsView : CanDestroyView
{
    [SerializeField]
    private Button _buttonIncreaseWeapon, _buttonIncreaseBallistic, _buttonIncreaseStrength, _buttonIncreaseRun, _buttonIncreaseNatisk, _buttonIncreaseFullmove,
        _buttonIncreaseHalfmove, _buttonIncreaseWounds, _buttonIncreaseCorruption, _buttonIncreaseMadness, _buttonIncreaseInfluence,
        _buttonIncreaseFellowship, _buttonIncreaseWillpower, _buttonIncreasePerception, _buttonIncreaseIntelligence, _buttonIncreaseAgility, _buttonIncreaseToughness,
        _buttonIncreaseFatepoint;

    [SerializeField]
    private Button _buttonDecreaseWeapon, _buttonDecreaseBallistic, _buttonDecreaseStrength, _buttonDecreaseRun, _buttonDecreaseNatisk, _buttonDecreaseFullmove,
        _buttonDecreaseHalfmove, _buttonDecreaseWounds, _buttonDecreaseCorruption, _buttonDecreaseMadness, _buttonDecreaseInfluence,
        _buttonDecreaseFellowship, _buttonDecreaseWillpower, _buttonDecreasePerception, _buttonDecreaseIntelligence, _buttonDecreaseAgility, _buttonDecreaseToughness,
        _buttonDecreaseFatepoint;

    [SerializeField]
    private TextMeshProUGUI _textWeapon, _textBallistic, _textStrength, _textRun, _textNatisk, _textFullmove,
        _textHalfmove, _textWounds, _textCorruption, _textMadness, _textInfluence, _textFellowship, 
        _textWillpower, _textPerception, _textIntelligence, _textAgility, _textToughness, _textFatepoint;

    [SerializeField] private Button _buttonAddEquipment, _buttonAddArmor, _buttonAddWeapon, _buttonAddBallistic, _buttonAddGrenade, _buttonAddImplant, _buttonNext, _buttonPrev;

    [SerializeField] private Transform _contentEquipment, _contentImplant;
    [SerializeField] private ItemInList _implantPrefab;
    [SerializeField] private ItemWithNumberInList _equipmentPrefab;

    public event Action IncreaseWeapon, IncreaseBallistic, IncreaseStrength, IncreaseRun, IncreaseNatisk, IncreaseFullmove,
        IncreaseHalfmove, IncreaseWounds, IncreaseCorruption, IncreaseMadness, IncreaseInfluence,
        IncreaseFellowship, IncreaseWillpower, IncreasePerception, IncreaseIntelligence, IncreaseAgility, IncreaseToughness,
        IncreaseFatepoint;

    public event Action DecreaseWeapon, DecreaseBallistic, DecreaseStrength, DecreaseRun, DecreaseNatisk, DecreaseFullmove,
        DecreaseHalfmove, DecreaseWounds, DecreaseCorruption, DecreaseMadness, DecreaseInfluence,
        DecreaseFellowship, DecreaseWillpower, DecreasePerception, DecreaseIntelligence, DecreaseAgility, DecreaseToughness,
        DecreaseFatepoint;


    public event Action AddEquipment, AddArmor, AddWeapon, AddBallistic, AddGrenade, AddImplant, Next, Prev;

    public event Action<string> RemoveEquipment, RemoveImplant;
    public event Action<string, int> ChangeAmountEquipment;

    private List<ItemWithNumberInList> _equipments = new List<ItemWithNumberInList>();
    private List<ItemInList> _implants = new List<ItemInList>();

    private void OnEnable()
    {
        _buttonIncreaseWeapon.onClick.AddListener(IncreaseWeaponPressed);
        _buttonIncreaseBallistic.onClick.AddListener(IncreaseBallisticPressed);
        _buttonIncreaseStrength.onClick.AddListener(IncreaseStrengthPressed);
        _buttonIncreaseRun.onClick.AddListener(IncreaseRunPressed);
        _buttonIncreaseNatisk.onClick.AddListener(IncreaseNatiskPressed);
        _buttonIncreaseFullmove.onClick.AddListener(IncreaseFullmovePressed);
        _buttonIncreaseHalfmove.onClick.AddListener(IncreaseHalfmovePressed);
        _buttonIncreaseWounds.onClick.AddListener(IncreaseWoundsPressed);
        _buttonIncreaseCorruption.onClick.AddListener(IncreaseCorruptionPressed);
        _buttonIncreaseMadness.onClick.AddListener(IncreaseMadnessPressed);
        _buttonIncreaseInfluence.onClick.AddListener(IncreaseInfluencePressed);
        _buttonIncreaseFellowship.onClick.AddListener(IncreaseFellowshipPressed);
        _buttonIncreaseWillpower.onClick.AddListener(IncreaseWillpowerPressed);
        _buttonIncreasePerception.onClick.AddListener(IncreasePerceptionPressed);
        _buttonIncreaseIntelligence.onClick.AddListener(IncreaseIntelligencePressed);
        _buttonIncreaseAgility.onClick.AddListener(IncreaseAgilityPressed);
        _buttonIncreaseToughness.onClick.AddListener(IncreaseToughnessPressed);
        _buttonIncreaseFatepoint.onClick.AddListener(IncreaseFatepointPressed);

        _buttonDecreaseWeapon.onClick.AddListener(DecreaseWeaponPressed);
        _buttonDecreaseBallistic.onClick.AddListener(DecreaseBallisticPressed);
        _buttonDecreaseStrength.onClick.AddListener(DecreaseStrengthPressed);
        _buttonDecreaseRun.onClick.AddListener(DecreaseRunPressed);
        _buttonDecreaseNatisk.onClick.AddListener(DecreaseNatiskPressed);
        _buttonDecreaseFullmove.onClick.AddListener(DecreaseFullmovePressed);
        _buttonDecreaseHalfmove.onClick.AddListener(DecreaseHalfmovePressed);
        _buttonDecreaseWounds.onClick.AddListener(DecreaseWoundsPressed);
        _buttonDecreaseCorruption.onClick.AddListener(DecreaseCorruptionPressed);
        _buttonDecreaseMadness.onClick.AddListener(DecreaseMadnessPressed);
        _buttonDecreaseInfluence.onClick.AddListener(DecreaseInfluencePressed);
        _buttonDecreaseFellowship.onClick.AddListener(DecreaseFellowshipPressed);
        _buttonDecreaseWillpower.onClick.AddListener(DecreaseWillpowerPressed);
        _buttonDecreasePerception.onClick.AddListener(DecreasePerceptionPressed);
        _buttonDecreaseIntelligence.onClick.AddListener(DecreaseIntelligencePressed);
        _buttonDecreaseAgility.onClick.AddListener(DecreaseAgilityPressed);
        _buttonDecreaseToughness.onClick.AddListener(DecreaseToughnessPressed);
        _buttonDecreaseFatepoint.onClick.AddListener(DecreaseFatepointPressed);

        _buttonAddEquipment.onClick.AddListener(AddEquipmentPressed);
        _buttonAddArmor.onClick.AddListener(AddArmorPressed);
        _buttonAddWeapon.onClick.AddListener(AddWeaponPressed);
        _buttonAddBallistic.onClick.AddListener(AddBallisticPressed);
        _buttonAddGrenade.onClick.AddListener(AddGrenadePressed);
        _buttonAddImplant.onClick.AddListener(AddImplantPressed);
        _buttonNext.onClick.AddListener(NextPressed);
        _buttonPrev.onClick.AddListener(PrevPressed);


    }    

    private void OnDisable()
    {
        _buttonIncreaseWeapon.onClick.RemoveAllListeners();
        _buttonIncreaseBallistic.onClick.RemoveAllListeners();
        _buttonIncreaseStrength.onClick.RemoveAllListeners();
        _buttonIncreaseRun.onClick.RemoveAllListeners();
        _buttonIncreaseNatisk.onClick.RemoveAllListeners();
        _buttonIncreaseFullmove.onClick.RemoveAllListeners();
        _buttonIncreaseHalfmove.onClick.RemoveAllListeners();
        _buttonIncreaseWounds.onClick.RemoveAllListeners();
        _buttonIncreaseCorruption.onClick.RemoveAllListeners();
        _buttonIncreaseMadness.onClick.RemoveAllListeners();
        _buttonIncreaseInfluence.onClick.RemoveAllListeners();
        _buttonIncreaseFellowship.onClick.RemoveAllListeners();
        _buttonIncreaseWillpower.onClick.RemoveAllListeners();
        _buttonIncreasePerception.onClick.RemoveAllListeners();
        _buttonIncreaseIntelligence.onClick.RemoveAllListeners();
        _buttonIncreaseAgility.onClick.RemoveAllListeners();
        _buttonIncreaseToughness.onClick.RemoveAllListeners();
        _buttonIncreaseFatepoint.onClick.RemoveAllListeners();

        _buttonDecreaseWeapon.onClick.RemoveAllListeners();
        _buttonDecreaseBallistic.onClick.RemoveAllListeners();
        _buttonDecreaseStrength.onClick.RemoveAllListeners();
        _buttonDecreaseRun.onClick.RemoveAllListeners();
        _buttonDecreaseNatisk.onClick.RemoveAllListeners();
        _buttonDecreaseFullmove.onClick.RemoveAllListeners();
        _buttonDecreaseHalfmove.onClick.RemoveAllListeners();
        _buttonDecreaseWounds.onClick.RemoveAllListeners();
        _buttonDecreaseCorruption.onClick.RemoveAllListeners();
        _buttonDecreaseMadness.onClick.RemoveAllListeners();
        _buttonDecreaseInfluence.onClick.RemoveAllListeners();
        _buttonDecreaseFellowship.onClick.RemoveAllListeners();
        _buttonDecreaseWillpower.onClick.RemoveAllListeners();
        _buttonDecreasePerception.onClick.RemoveAllListeners();
        _buttonDecreaseIntelligence.onClick.RemoveAllListeners();
        _buttonDecreaseAgility.onClick.RemoveAllListeners();
        _buttonDecreaseToughness.onClick.RemoveAllListeners();
        _buttonDecreaseFatepoint.onClick.RemoveAllListeners();

        _buttonAddEquipment.onClick.RemoveAllListeners();
        _buttonAddArmor.onClick.RemoveAllListeners();
        _buttonAddWeapon.onClick.RemoveAllListeners();
        _buttonAddBallistic.onClick.RemoveAllListeners();
        _buttonAddGrenade.onClick.RemoveAllListeners();
        _buttonAddImplant.onClick.RemoveAllListeners();
        _buttonNext.onClick.RemoveAllListeners();
        _buttonPrev.onClick.RemoveAllListeners();
    }

    public void Initialize(Character character)
    {
        UpdateTextFields(character);
        UpdateEquipment(character.Equipments);
        UpdateImplants(character.Implants);
    }

    public void UpdateTextFields(ICharacter character)
    {
        _textWeapon.text = $"{character.Characteristics[0].Amount}";
        _textBallistic.text = $"{character.Characteristics[1].Amount}";
        _textStrength.text = $"{character.Characteristics[2].Amount}";
        _textRun.text = $"{character.Run}";
        _textNatisk.text = $"{character.Natisk}";
        _textFullmove.text = $"{character.FullMove}";
        _textHalfmove.text = $"{character.HalfMove}";
        _textWounds.text = $"{character.Wounds}";
        _textCorruption.text = $"{character.CorruptionPoints}";
        _textMadness.text = $"{character.InsanityPoints}";
        _textInfluence.text = $"{character.Characteristics[9].Amount}";
        _textFellowship.text = $"{character.Characteristics[8].Amount}";
        _textWillpower.text = $"{character.Characteristics[7].Amount}";
        _textPerception.text = $"{character.Characteristics[7].Amount}";
        _textIntelligence.text = $"{character.Characteristics[5].Amount}";
        _textAgility.text = $"{character.Characteristics[4].Amount}";
        _textToughness.text = $"{character.Characteristics[3].Amount}";
        _textFatepoint.text = $"{character.FatePoint}";
    }

    public void UpdateEquipment(List<Equipment> equipments)
    {
        if(_equipments.Count > 0)
        {
            foreach (ItemWithNumberInList item in _equipments)
                Destroy(item.gameObject);
            _equipments.Clear();
        }

        foreach(Equipment equipment in equipments)
        {
            ItemWithNumberInList item = Instantiate(_equipmentPrefab, _contentEquipment);
            item.ChangeAmount += ChangeAmountEquipmentPressed;
            item.RemoveThisItem += RemoveEquipmentPressed;
            item.Initialize(equipment.Name, equipment.Amount);
            _equipments.Add(item);
        }
    }

    public void UpdateImplants(List<MechImplant> mechImplants)
    {
        if(_implants.Count > 0)
        {
            foreach (ItemInList item in _implants)
                Destroy(item.gameObject);
            _implants.Clear();
        }

        foreach(MechImplant implant in mechImplants)
        {
            ItemInList item = Instantiate(_implantPrefab, _contentImplant);
            item.ChooseThis += RemoveImplant;
            item.Initialize(implant.Name);
            _implants.Add(item);
        }
    }    

    private void ChangeAmountEquipmentPressed(string name, int amount) => ChangeAmountEquipment?.Invoke(name, amount);

    private void RemoveEquipmentPressed(string name) => RemoveEquipment?.Invoke(name);

    private void PrevPressed() => Prev?.Invoke();

    private void NextPressed() => Next?.Invoke();

    private void AddImplantPressed() => AddImplant?.Invoke();

    private void AddGrenadePressed() => AddGrenade?.Invoke();

    private void AddBallisticPressed() => AddBallistic?.Invoke();

    private void AddWeaponPressed() => AddWeapon?.Invoke();

    private void AddArmorPressed() => AddArmor?.Invoke();

    private void AddEquipmentPressed() => AddEquipment?.Invoke();

    private void DecreaseFatepointPressed() => DecreaseFatepoint?.Invoke();

    private void DecreaseToughnessPressed() => DecreaseToughness?.Invoke();

    private void DecreaseAgilityPressed() => DecreaseAgility?.Invoke();

    private void DecreaseIntelligencePressed() => DecreaseIntelligence?.Invoke();

    private void DecreasePerceptionPressed() => DecreasePerception?.Invoke();

    private void DecreaseWillpowerPressed() => DecreaseWillpower?.Invoke();

    private void DecreaseFellowshipPressed() => DecreaseFellowship?.Invoke();

    private void DecreaseInfluencePressed() => DecreaseInfluence?.Invoke();

    private void DecreaseMadnessPressed() => DecreaseMadness?.Invoke();

    private void DecreaseCorruptionPressed() => DecreaseCorruption?.Invoke();

    private void DecreaseWoundsPressed() => DecreaseWounds?.Invoke();

    private void DecreaseHalfmovePressed() => DecreaseHalfmove?.Invoke();

    private void DecreaseFullmovePressed() => DecreaseFullmove?.Invoke();

    private void DecreaseNatiskPressed() => DecreaseNatisk?.Invoke();

    private void DecreaseRunPressed() => DecreaseRun?.Invoke();

    private void DecreaseStrengthPressed() => DecreaseStrength?.Invoke();

    private void DecreaseBallisticPressed() => DecreaseBallistic?.Invoke();

    private void DecreaseWeaponPressed() => DecreaseWeapon?.Invoke();

    private void IncreaseFatepointPressed() => IncreaseFatepoint?.Invoke();

    private void IncreaseToughnessPressed() => IncreaseToughness?.Invoke();

    private void IncreaseAgilityPressed() => IncreaseAgility?.Invoke();

    private void IncreaseIntelligencePressed() => IncreaseIntelligence?.Invoke();

    private void IncreasePerceptionPressed() => IncreasePerception?.Invoke();

    private void IncreaseWillpowerPressed() => IncreaseWillpower?.Invoke();

    private void IncreaseFellowshipPressed() => IncreaseFellowship?.Invoke();

    private void IncreaseInfluencePressed() => IncreaseInfluence?.Invoke();

    private void IncreaseMadnessPressed() => IncreaseMadness?.Invoke();

    private void IncreaseCorruptionPressed() => IncreaseCorruption?.Invoke();

    private void IncreaseWoundsPressed() => IncreaseWounds?.Invoke();

    private void IncreaseHalfmovePressed() => IncreaseHalfmove?.Invoke();

    private void IncreaseFullmovePressed() => IncreaseFullmove?.Invoke();

    private void IncreaseNatiskPressed() => IncreaseNatisk?.Invoke();

    private void IncreaseRunPressed() => IncreaseRun?.Invoke();

    private void IncreaseStrengthPressed() => IncreaseStrength?.Invoke();

    private void IncreaseBallisticPressed() => IncreaseBallistic?.Invoke();

    private void IncreaseWeaponPressed() => IncreaseWeapon?.Invoke();
}
