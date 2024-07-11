using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabHolder", menuName = "Holder/PrefabHolder")]
public class PrefabHolder : ScriptableObject
{
    [SerializeField] private GameObject _intermediatePrefab, _homeworldPrefab, _homeworldFinalPrefab, _mainMenuPrefab, _backgroundPrefab, _backgroundFinalPrefab;
    [SerializeField] private GameObject _rolePrefab, _rolePrefabFinal, _chooseBetweenManualAndRandom, _characteristicRandomPrefab, _characteristicManual;
    [SerializeField] private GameObject _upgradeCharacteristic, _upgradeSkill, _upgradeTalent, _upgradePsycana;
    [SerializeField] private GameObject _prophecy, _name, _firstPrint, _secondPrint, _thirdPrint;
    [SerializeField] private GameObject _loads, _inputExperience, _finalMenu, _listWithNewItems, _inputNewProperty, _editProperties;
    [SerializeField] private GameObject _editCharacteristicsAndEquipments;
    [SerializeField] private GameObject _newEquipment, _newMelee, _newRange, _newGrenade, _newArmor, _listWithNewItemsAndNewButton, _newImplant;

    public GameObject Get(TypeScene typeScene)
    {
        switch (typeScene)
        {
            case TypeScene.Intermediate:
                return _intermediatePrefab;

            case TypeScene.Homeworld:
                return _homeworldPrefab;

            case TypeScene.HomeworldFinal:
                return _homeworldFinalPrefab;

            case TypeScene.MainMenu:
                return _mainMenuPrefab;

            case TypeScene.Background:
                return _backgroundPrefab;

            case TypeScene.BackgroundFinal:
                return _backgroundFinalPrefab;

            case TypeScene.Role:
                return _rolePrefab;

            case TypeScene.RoleFinal:
                return _rolePrefabFinal;

            case TypeScene.ChoiceBetweenManualAndRandom:
                return _chooseBetweenManualAndRandom;

            case TypeScene.RandomCharacteristic:
                return _characteristicRandomPrefab;

            case TypeScene.ManualCharacteristic:
                return _characteristicManual;

            case TypeScene.UpgradeCharacteristic:
                return _upgradeCharacteristic;

            case TypeScene.UpgradeSkill:
                return _upgradeSkill;

            case TypeScene.UpgradeTalent:
                return _upgradeTalent;

            case TypeScene.UpgradePsycana:
                return _upgradePsycana;

            case TypeScene.Prophecy:
                return _prophecy;

            case TypeScene.Name:
                return _name;

            case TypeScene.FirstPage:
                return _firstPrint;

            case TypeScene.SecondPage:
                return _secondPrint;

            case TypeScene.ThirdPage:
                return _thirdPrint;

            case TypeScene.Loads:
                return _loads;

            case TypeScene.InputExperience:
                return _inputExperience;

            case TypeScene.FinalMenu:
                return _finalMenu;

            case TypeScene.ListWithNewItems:
                return _listWithNewItems;

            case TypeScene.InputNewProperty:
                return _inputNewProperty;

            case TypeScene.EditProperties:
                return _editProperties;

            case TypeScene.NewArmor:
                return _newArmor;

            case TypeScene.NewEquipment:
                return _newEquipment;

            case TypeScene.NewGrenade:
                return _newGrenade;

            case TypeScene.NewMelee:
                return _newMelee;

            case TypeScene.NewRange:
                return _newRange;

            case TypeScene.ListWithNewItemsAndNewButton:
                return _listWithNewItemsAndNewButton;

            case TypeScene.EditCharacteristicsAndEquipments:
                return _editCharacteristicsAndEquipments;

            case TypeScene.NewImplant:
                return _newImplant;

            default:
                throw new ArgumentException(nameof(TypeScene));
        }
    }
}
