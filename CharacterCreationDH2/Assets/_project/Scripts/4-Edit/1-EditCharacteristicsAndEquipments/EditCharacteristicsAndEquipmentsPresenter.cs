﻿using System;
using System.Collections.Generic;

namespace CharacterCreation
{
    public class EditCharacteristicsAndEquipmentsPresenter : IPresenter
    {
        public event Action<ICharacter> ReturnBack, GoNext;
        private EditCharacteristicsAndEquipmentsView _view;
        private AudioManager _audioManager;
        private LvlFactory _lvlFactory;
        private CreatorEquipment _creatorEquipment;
        private CreatorImplant _creatorImplant;
        private CreatorWeaponTrait _creatorWeaponTraits;
        private Character _character;
        private AnimateShowAndHideView _newForm;
        private ListWithNewItems _listWithItems;

        private delegate void MethodFormEquipment();

        public EditCharacteristicsAndEquipmentsPresenter(EditCharacteristicsAndEquipmentsView view, AudioManager audioManager,
            LvlFactory lvlFactory, CreatorEquipment creatorEquipment, CreatorImplant creatorImplant, CreatorWeaponTrait creatorWeaponProperties, ICharacter character)
        {
            _view = view;
            _audioManager = audioManager;
            _lvlFactory = lvlFactory;
            _creatorEquipment = creatorEquipment;
            _creatorImplant = creatorImplant;
            _creatorWeaponTraits = creatorWeaponProperties;
            SearchCharacter(character);
            Subscribe();
            _view.Initialize(_character);
        }

        private void SearchCharacter(ICharacter character)
        {
            if (character is Character)
                _character = (Character)character;
            else
                SearchCharacter(character.GetCharacter);
        }
        private void Subscribe()
        {
            _view.AddArmor += ShowArmor;
            _view.AddBallistic += ShowBallistic;
            _view.AddEquipment += ShowNewEquipment;
            _view.AddGrenade += ShowNewGrenade;
            _view.AddImplant += ShowNewImplants;
            _view.AddWeapon += ShowNewWeapons;
            _view.ChangeAmountEquipment += ChangeAmountEquipment;

            _view.DecreaseAgility += DecreaseAgility;
            _view.DecreaseBallistic += DecreaseBallistic;
            _view.DecreaseCorruption += DecreaseCorruption;
            _view.DecreaseFatepoint += DecreaseFatepoint;
            _view.DecreaseFellowship += DecreaseFellowship;
            _view.DecreaseInfluence += DecreaseInfluence;
            _view.DecreaseIntelligence += DecreaseIntelligence;
            _view.DecreaseMadness += DecreaseMadness;
            _view.DecreasePerception += DecreasePerception;
            _view.DecreaseStrength += DecreaseStrength;
            _view.DecreaseToughness += DecreaseToughness;
            _view.DecreaseWeapon += DecreaseWeapon;
            _view.DecreaseWillpower += DecreaseWillpower;
            _view.DecreaseWounds += DecreaseWounds;

            _view.IncreaseAgility += IncreaseAgility;
            _view.IncreaseBallistic += IncreaseBallistic;
            _view.IncreaseCorruption += IncreaseCorruption;
            _view.IncreaseFatepoint += IncreaseFatepoint;
            _view.IncreaseFellowship += IncreaseFellowship;
            _view.IncreaseInfluence += IncreaseInfluence;
            _view.IncreaseIntelligence += IncreaseIntelligence;
            _view.IncreaseMadness += IncreaseMadness;
            _view.IncreasePerception += IncreasePerception;
            _view.IncreaseStrength += IncreaseStrength;
            _view.IncreaseToughness += IncreaseToughness;
            _view.IncreaseWeapon += IncreaseWeapon;
            _view.IncreaseWillpower += IncreaseWillpower;
            _view.IncreaseWounds += IncreaseWounds;

            _view.Next += Next;
            _view.Prev += Prev;
            _view.RemoveEquipment += RemoveEquipment;
            _view.RemoveImplant += RemoveImplant;

            _view.OpenModifierWeapon += OpenModifier;

        }

        private void Unscribe()
        {
            _view.AddArmor -= ShowArmor;
            _view.AddBallistic -= ShowBallistic;
            _view.AddEquipment -= ShowNewEquipment;
            _view.AddGrenade -= ShowNewGrenade;
            _view.AddImplant -= ShowNewImplants;
            _view.AddWeapon -= ShowNewWeapons;
            _view.ChangeAmountEquipment -= ChangeAmountEquipment;

            _view.DecreaseAgility -= DecreaseAgility;
            _view.DecreaseBallistic -= DecreaseBallistic;
            _view.DecreaseCorruption -= DecreaseCorruption;
            _view.DecreaseFatepoint -= DecreaseFatepoint;
            _view.DecreaseFellowship -= DecreaseFellowship;
            _view.DecreaseInfluence -= DecreaseInfluence;
            _view.DecreaseIntelligence -= DecreaseIntelligence;
            _view.DecreaseMadness -= DecreaseMadness;
            _view.DecreasePerception -= DecreasePerception;
            _view.DecreaseStrength -= DecreaseStrength;
            _view.DecreaseToughness -= DecreaseToughness;
            _view.DecreaseWeapon -= DecreaseWeapon;
            _view.DecreaseWillpower -= DecreaseWillpower;
            _view.DecreaseWounds -= DecreaseWounds;

            _view.IncreaseAgility -= IncreaseAgility;
            _view.IncreaseBallistic -= IncreaseBallistic;
            _view.IncreaseCorruption -= IncreaseCorruption;
            _view.IncreaseFatepoint -= IncreaseFatepoint;
            _view.IncreaseFellowship -= IncreaseFellowship;
            _view.IncreaseInfluence -= IncreaseInfluence;
            _view.IncreaseIntelligence -= IncreaseIntelligence;
            _view.IncreaseMadness -= IncreaseMadness;
            _view.IncreasePerception -= IncreasePerception;
            _view.IncreaseStrength -= IncreaseStrength;
            _view.IncreaseToughness -= IncreaseToughness;
            _view.IncreaseWeapon -= IncreaseWeapon;
            _view.IncreaseWillpower -= IncreaseWillpower;
            _view.IncreaseWounds -= IncreaseWounds;

            _view.Next -= Next;
            _view.Prev -= Prev;
            _view.RemoveEquipment -= RemoveEquipment;
            _view.RemoveImplant -= RemoveImplant;

            _view.OpenModifierWeapon -= OpenModifier;
        }
        private void DecreaseAgility() => DecreaseCharacteristic(4);

        private void DecreaseBallistic() => DecreaseCharacteristic(1);

        private void DecreaseFellowship() => DecreaseCharacteristic(8);

        private void DecreaseInfluence() => DecreaseCharacteristic(9);

        private void DecreaseIntelligence() => DecreaseCharacteristic(5);

        private void DecreasePerception() => DecreaseCharacteristic(6);

        private void DecreaseStrength() => DecreaseCharacteristic(2);

        private void DecreaseToughness() => DecreaseCharacteristic(3);

        private void DecreaseWeapon() => DecreaseCharacteristic(0);

        private void DecreaseWillpower() => DecreaseCharacteristic(7);

        private void DecreaseWounds()
        {
            _audioManager.PlayClick();
            _character.ChangeWounds(-1);
            _view.UpdateTextFields(_character);
        }

        private void DecreaseCorruption()
        {
            _audioManager.PlayClick();
            _character.ChangeCorruption(-1);
            _view.UpdateTextFields(_character);
        }

        private void DecreaseFatepoint()
        {
            _audioManager.PlayClick();
            _character.ChangeFatepoints(-1);
            _view.UpdateTextFields(_character);
        }

        private void DecreaseMadness()
        {
            _audioManager.PlayClick();
            _character.ChangeMadness(-1);
            _view.UpdateTextFields(_character);
        }

        private void IncreaseAgility() => IncreaseCharacteristic(4);

        private void IncreaseBallistic() => IncreaseCharacteristic(1);

        private void IncreaseFellowship() => IncreaseCharacteristic(8);

        private void IncreaseInfluence() => IncreaseCharacteristic(9);

        private void IncreaseIntelligence() => IncreaseCharacteristic(5);

        private void IncreasePerception() => IncreaseCharacteristic(6);

        private void IncreaseStrength() => IncreaseCharacteristic(2);

        private void IncreaseToughness() => IncreaseCharacteristic(3);

        private void IncreaseWeapon() => IncreaseCharacteristic(0);

        private void IncreaseWillpower() => IncreaseCharacteristic(7);

        private void IncreaseWounds()
        {
            _audioManager.PlayClick();
            _character.ChangeWounds(1);
            _view.UpdateTextFields(_character);
        }

        private void IncreaseCorruption()
        {
            _audioManager.PlayClick();
            _character.ChangeCorruption(1);
            _view.UpdateTextFields(_character);
        }

        private void IncreaseFatepoint()
        {
            _audioManager.PlayClick();
            _character.ChangeFatepoints(1);
            _view.UpdateTextFields(_character);
        }

        private void IncreaseMadness()
        {
            _audioManager.PlayClick();
            _character.ChangeMadness(1);
            _view.UpdateTextFields(_character);
        }

        private void Next()
        {
            //_audioManager.PlayClick();
            CheckAndCloseAllLists();
            Unscribe();
            _view.DestroyView();
            GoNext?.Invoke(_character);
        }

        private void Prev()
        {
            //_audioManager.PlayClick();

            CheckAndCloseAllLists();
            Unscribe();
            _view.DestroyView();
            ReturnBack?.Invoke(_character);
        }


        private void RemoveImplant(string name)
        {
            foreach (MechImplant implant in _character.Implants)
                if (string.Compare(implant.Name, name, true) == 0)
                {
                    _character.Implants.Remove(implant);
                    break;
                }

            _view.UpdateImplants(_character.Implants);

        }

        private void ShowNewImplants()
        {
            _audioManager.PlayClick();
            CheckAndCloseAllLists();
            List<string> implantNames = new List<string>();
            foreach (MechImplant implant in _creatorImplant.Implants)
                implantNames.Add(implant.Name);

            ListWithNewItemsAndNewButton listWithNew = _lvlFactory.Get(TypeScene.ListWithNewItemsAndNewButton).GetComponent<ListWithNewItemsAndNewButton>();
            listWithNew.AddNewItem += ShowNewImplant;
            listWithNew.ChooseThis += AddImplant;
            listWithNew.CloseList += CloseList;
            listWithNew.Initialize(implantNames, "Выберите имплант");
            _listWithItems = listWithNew;
        }

        private void ShowNewImplant()
        {
            _audioManager.PlayClick();
            _listWithItems.DestroyView();
            _listWithItems = null;

            NewImplant newImplant = _lvlFactory.Get(TypeScene.NewImplant).GetComponent<NewImplant>();
            newImplant.Cancel += CloseForm;
            newImplant.ReturnImplant += AddNewImplant;
            newImplant.WrongInput += _audioManager.PlayWarning;
            _newForm = newImplant;
        }

        private void AddImplant(string name)
        {
            _audioManager.PlayDone();
            _character.Implants.Add(new MechImplant(_creatorImplant.GetImplant(name)));
            _view.UpdateImplants(_character.Implants);
            _listWithItems.DestroyView();
            _listWithItems = null;
        }

        private void AddNewImplant(MechImplant implant)
        {
            _audioManager.PlayDone();
            _newForm.DestroyView();
            _newForm = null;

            _character.Implants.Add(implant);
            _view.UpdateImplants(_character.Implants);
            _creatorImplant.AddImplant(implant);
        }

        private void ShowNewWeapons() => ShowListWithNewEquipments(Equipment.TypeEquipment.Melee, $"Выберите оружие ближнего боя", ShowNewMeleeForm);

        private void ShowNewMeleeForm() => ShowFormWithProperties(_lvlFactory.Get(TypeScene.NewMelee).GetComponent<NewMelee>(), AddNewEquipment);

        private void ShowNewGrenade() => ShowListWithNewEquipments(Equipment.TypeEquipment.Grenade, "Выберите гранату", ShowNewGrenadeForm);

        private void ShowNewGrenadeForm() => ShowFormWithProperties(_lvlFactory.Get(TypeScene.NewGrenade).GetComponent<NewGrenade>(), AddNewEquipment);

        private void ShowNewEquipment() => ShowListWithNewEquipments(Equipment.TypeEquipment.Thing, "Выберите снаряжение", ShowEquipmentForm);

        private void ShowEquipmentForm() => ShowForm(_lvlFactory.Get(TypeScene.NewEquipment).GetComponent<CreatorNewEquipment>(), AddNewEquipment);

        private void ShowBallistic() => ShowListWithNewEquipments(Equipment.TypeEquipment.Range, "Выберите стрелковое оружие", ShowNewBallistic);

        private void ShowNewBallistic() => ShowFormWithProperties(_lvlFactory.Get(TypeScene.NewRange).GetComponent<NewRange>(), AddNewEquipment);

        private void ShowArmor() => ShowListWithNewEquipments(Equipment.TypeEquipment.Armor, "Выберите броню", ShowNewArmor);

        private void ShowNewArmor() => ShowForm(_lvlFactory.Get(TypeScene.NewArmor).GetComponent<NewArmor>(), AddNewEquipment);

        private void ShowListWithNewEquipments(Equipment.TypeEquipment typeEquipment, string title, MethodFormEquipment method)
        {
            _audioManager.PlayClick();
            CheckAndCloseAllLists();
            ListWithNewItemsAndNewButton listWithNew = _lvlFactory.Get(TypeScene.ListWithNewItemsAndNewButton).GetComponent<ListWithNewItemsAndNewButton>();
            listWithNew.AddNewItem += method.Invoke;
            listWithNew.ChooseThis += AddThisEquipment;
            listWithNew.CloseList += CloseList;

            listWithNew.Initialize(EquipmentNames(typeEquipment), title);
            _listWithItems = listWithNew;
        }

        private void IncreaseCharacteristic(int id)
        {
            if (_character.Characteristics[id].Amount < 100)
            {
                _audioManager.PlayClick();
                _character.Characteristics[id].Amount += 1;
                _view.UpdateTextFields(_character);
            }
            else
                _audioManager.PlayWarning();
        }

        private void DecreaseCharacteristic(int id)
        {
            if (_character.Characteristics[id].Amount > 1)
            {
                _audioManager.PlayClick();
                _character.Characteristics[id].Amount -= 1;
                _view.UpdateTextFields(_character);
            }
            else
                _audioManager.PlayWarning();
        }

        private void CheckAndCloseAllLists()
        {
            if (_newForm != null)
                _newForm.HideRight(_newForm.DestroyView);
            _newForm = null;

            if (_listWithItems != null)
                _listWithItems.HideRight(_listWithItems.DestroyView);
            _listWithItems = null;
        }

        private List<string> EquipmentNames(Equipment.TypeEquipment typeEquipment)
        {
            List<string> names = new List<string>();
            foreach (Equipment equipment in _creatorEquipment.Equipments)
                if (equipment.TypeEq == typeEquipment)
                    names.Add(equipment.Name);

            return names;
        }

        private void ShowFormWithProperties(NewMelee newMelee, Action<Equipment> DoItWithEquipment)
        {
            newMelee.NeedInProperties += ShowListWithProperties;
            ShowForm(newMelee, DoItWithEquipment);
        }

        private void ShowForm(CreatorNewEquipment newEquipmentForm, Action<Equipment> DoItWithEquipment)
        {
            _audioManager.PlayClick();
            if (_listWithItems != null)
                _listWithItems.HideRight(_listWithItems.DestroyView);
            newEquipmentForm.Cancel += CloseForm;
            newEquipmentForm.ReturnNewEquipment += DoItWithEquipment;
            newEquipmentForm.WrongInput += _audioManager.PlayWarning;
            newEquipmentForm.Initialize();
            _newForm = newEquipmentForm;
        }

        private void AddThisEquipment(string name)
        {
            _audioManager.PlayDone();
            _listWithItems.HideRight(_listWithItems.DestroyView);
            Equipment equipment = _creatorEquipment.GetEquipment(name);
            if (equipment is Weapon)
            {
                Weapon weapon = (Weapon)equipment;
                _character.Equipments.Add(new Weapon(weapon));
            }
            else if (equipment is Armor)
            {
                Armor armor = (Armor)equipment;
                _character.Equipments.Add(new Armor(armor));
            }
            else
                _character.Equipments.Add(new Equipment(equipment));

            _view.UpdateEquipment(_character.Equipments);
        }

        private void CloseList(CanDestroyView list)
        {
            _audioManager.PlayCancel();
            _listWithItems.HideRight(list.DestroyView);
            _listWithItems = null;
        }

        private void CloseForm(CanDestroyView form)
        {
            _audioManager.PlayCancel();
            _newForm.HideRight(form.DestroyView);
            _newForm = null;
        }

        private void AddNewEquipment(Equipment equipment)
        {
            _audioManager.PlayDone();
            _newForm.HideRight(_newForm.DestroyView);
            _newForm = null;
            _character.Equipments.Add(equipment);
            _view.UpdateEquipment(_character.Equipments);
            _creatorEquipment.AddEquipment(equipment);
        }

        private void ShowListWithProperties()
        {
            _audioManager.PlayClick();
            ListWithNewItems list = _lvlFactory.Get(TypeScene.ListWithNewItems).GetComponent<ListWithNewItems>();
            list.CloseList += CloseList;
            list.ChooseThis += AddProperty;
            list.Initialize(_creatorWeaponTraits.GetNames(), $"Выберите особое качество");
            _listWithItems = list;
        }

        private void AddProperty(string name)
        {
            _audioManager.PlayClick();
            if (_listWithItems != null)
                _listWithItems.HideRight(_listWithItems.DestroyView);

            if (_newForm is CreatorNewEquipment newEquipmentForm)
                newEquipmentForm.AddProperty(name);

        }

        private void ChangeAmountEquipment(string name, int amount)
        {
            _audioManager.PlayClick();
            foreach (Equipment equipment in _character.Equipments)
            {
                if (string.Compare(equipment.Name, name) == 0)
                {
                    equipment.Amount = amount;
                    break;
                }
            }
            _view.UpdateEquipment(_character.Equipments);
        }

        private void RemoveEquipment(string name)
        {
            _audioManager.PlayCancel();
            foreach (Equipment equipment in _character.Equipments)
                if (string.Compare(name, equipment.Name, true) == 0)
                {
                    _character.Equipments.Remove(equipment);
                    break;
                }
            _view.UpdateEquipment(_character.Equipments);
        }

        private void OpenModifier(Weapon weapon)
        {
            _audioManager.PlayClick();
            if (weapon.TypeEq == Equipment.TypeEquipment.Melee)
            {
                ShowFormWithProperties(_lvlFactory.Get(TypeScene.NewMelee).GetComponent<NewMelee>(), ModifierWeapon);
                if (_newForm is NewMelee newMelee)
                    newMelee.SetWeapon(weapon);
            }
            else if (weapon.TypeEq == Equipment.TypeEquipment.Range)
            {
                ShowFormWithProperties(_lvlFactory.Get(TypeScene.NewRange).GetComponent<NewRange>(), ModifierWeapon);
                if (_newForm is NewRange newRange)
                    newRange.SetWeapon(weapon);
            }
            else if (weapon.TypeEq == Equipment.TypeEquipment.Grenade)
            {
                ShowFormWithProperties(_lvlFactory.Get(TypeScene.NewGrenade).GetComponent<NewGrenade>(), ModifierWeapon);
                if (_newForm is NewGrenade newGrenade)
                    newGrenade.SetWeapon(weapon);
            }
        }

        private void ModifierWeapon(Equipment equipment)
        {
            _audioManager.PlayDone();
            _newForm.HideRight(_newForm.DestroyView);
            _newForm = null;
            Weapon weapon = (Weapon)equipment;
            for (int i = 0; i < _character.Equipments.Count; i++)
            {
                if (string.Compare(equipment.Name, _character.Equipments[i].Name, true) == 0)
                {
                    _character.Equipments[i] = weapon;
                    _view.UpdateEquipment(_character.Equipments);
                    break;
                }
            }
        }
    }

}
