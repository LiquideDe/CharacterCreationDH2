using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

namespace CharacterCreation
{
    public class EditPropertyCharacterView : AnimateShowAndHideView
    {
        [SerializeField]
        private TMP_InputField inputName, inputHome, inputBack, inputRole, inputProph, inputElite, inputGender, inputAge, inputSkeen, inputBody, inputHair, inputPhysFeat, inputEyes,
            inputTraditions, inputRememberHome, inputRememberBack;

        [SerializeField] private Button _buttonNext, _buttonAddInclination, _buttonAddFeature, _buttonAddMental, _buttonAddMutation;
        [SerializeField] private ItemInList _itemInListPrefab;
        [SerializeField] private ItemWithNumberInList _itemFeaturePrefab;
        [SerializeField] private Transform _inclinationContent, _featureContent, _mentalContent, _mutationContent;

        public event Action<SaveLoadCharacter> ChangePropertyCharacter;
        public event Action Next, AddInclination, AddFeature, AddMental, AddMutation;
        public event Action<string> RemoveInclination, RemoveFeature, RemoveMental, RemoveMutation;
        public event Action<string, int> ChangeFeatureLvl;

        private List<ItemInList> _inclinations = new List<ItemInList>();
        private List<ItemWithNumberInList> _features = new List<ItemWithNumberInList>();
        private List<ItemInList> _mentals = new List<ItemInList>();
        private List<ItemInList> _mutations = new List<ItemInList>();

        private delegate void RemoveItem(string name);

        private void OnEnable()
        {
            inputName.onDeselect.AddListener(ChangeProperty);
            inputHome.onDeselect.AddListener(ChangeProperty);
            inputBack.onDeselect.AddListener(ChangeProperty);
            inputRole.onDeselect.AddListener(ChangeProperty);
            inputProph.onDeselect.AddListener(ChangeProperty);
            inputElite.onDeselect.AddListener(ChangeProperty);
            inputGender.onDeselect.AddListener(ChangeProperty);
            inputAge.onDeselect.AddListener(ChangeProperty);
            inputSkeen.onDeselect.AddListener(ChangeProperty);
            inputBody.onDeselect.AddListener(ChangeProperty);
            inputHair.onDeselect.AddListener(ChangeProperty);
            inputPhysFeat.onDeselect.AddListener(ChangeProperty);
            inputEyes.onDeselect.AddListener(ChangeProperty);
            inputTraditions.onDeselect.AddListener(ChangeProperty);
            inputRememberHome.onDeselect.AddListener(ChangeProperty);
            inputRememberBack.onDeselect.AddListener(ChangeProperty);

            _buttonNext.onClick.AddListener(NextPressed);
            _buttonNext.onClick.AddListener(_audio.PlayClick);
            _buttonAddInclination.onClick.AddListener(AddInclinationPressed);
            _buttonAddFeature.onClick.AddListener(AddFeaturePressed);
            _buttonAddMental.onClick.AddListener(AddMentalPressed);
            _buttonAddMutation.onClick.AddListener(AddMutationPressed);
        }

        private void OnDisable()
        {
            inputName.onDeselect.RemoveAllListeners();
            inputHome.onDeselect.RemoveAllListeners();
            inputBack.onDeselect.RemoveAllListeners();
            inputRole.onDeselect.RemoveAllListeners();
            inputProph.onDeselect.RemoveAllListeners();
            inputElite.onDeselect.RemoveAllListeners();
            inputGender.onDeselect.RemoveAllListeners();
            inputAge.onDeselect.RemoveAllListeners();
            inputSkeen.onDeselect.RemoveAllListeners();
            inputBody.onDeselect.RemoveAllListeners();
            inputHair.onDeselect.RemoveAllListeners();
            inputPhysFeat.onDeselect.RemoveAllListeners();
            inputEyes.onDeselect.RemoveAllListeners();
            inputTraditions.onDeselect.RemoveAllListeners();
            inputRememberHome.onDeselect.RemoveAllListeners();
            inputRememberBack.onDeselect.RemoveAllListeners();

            _buttonNext.onClick.RemoveAllListeners();
            _buttonAddInclination.onClick.RemoveAllListeners();
            _buttonAddFeature.onClick.RemoveAllListeners();
            _buttonAddMental.onClick.RemoveAllListeners();
            _buttonAddMutation.onClick.RemoveAllListeners();
        }

        public void Initialize(Character character)
        {
            inputName.text = character.Name;
            inputHome.text = character.Homeworld;
            inputBack.text = character.Background;
            inputRole.text = character.Role;
            inputProph.text = character.Prophecy;
            inputElite.text = character.Elite;
            inputGender.text = character.Gender;
            inputAge.text = character.Age.ToString();
            inputSkeen.text = character.Skeen;
            inputBody.text = character.Constitution;
            inputHair.text = character.Hair;
            inputPhysFeat.text = character.PhysFeatures;
            inputEyes.text = character.Eyes;
            inputTraditions.text = character.Tradition;
            inputRememberHome.text = character.MemoryOfHome;
            inputRememberBack.text = character.MemoryOfBackground;

            UpdateTraits(character.Traits);

            List<string> nameInclinations = new List<string>();
            foreach (GameStat.Inclinations inclination in character.Inclinations)
            {
                nameInclinations.Add(GameStat.inclinationTranslate[inclination]);
            }
            UpdateInclinations(nameInclinations);
            UpdateMental(character.MentalDisorders);
            UpdateMutation(character.Mutation);
        }

        public void UpdateTraits(List<Trait> traits)
        {
            if (_features.Count > 0)
            {
                foreach (ItemWithNumberInList item in _features)
                    Destroy(item.gameObject);
                _features.Clear();
            }


            foreach (Trait trait in traits)
            {
                ItemWithNumberInList itemFeaturet = Instantiate(_itemFeaturePrefab, _featureContent);
                itemFeaturet.ChangeAmount += ChangeFeatureLvlPressed;
                itemFeaturet.RemoveThisItem += RemoveFeaturePressed;
                itemFeaturet.Initialize(trait.Name, trait.Lvl);
                _features.Add(itemFeaturet);
            }
        }

        public void UpdateInclinations(List<string> inclinations)
        {
            if (_inclinations.Count > 0)
                ClearListWithItems(_inclinations);

            _inclinations.AddRange(CreateItemInList(inclinations, RemoveInclinationPressed, _inclinationContent));
        }

        public void UpdateMental(List<string> mentals)
        {
            if (_mentals.Count > 0)
                ClearListWithItems(_mentals);

            _mentals.AddRange(CreateItemInList(mentals, RemoveMentalPressed, _mentalContent));
        }

        public void UpdateMutation(List<string> mutations)
        {

            if (_mutations.Count > 0)
                ClearListWithItems(_mutations);

            _mutations.AddRange(CreateItemInList(mutations, RemoveMutationPressed, _mutationContent));
        }

        private List<ItemInList> CreateItemInList(List<string> names, RemoveItem methodForRemove, Transform content)
        {
            List<ItemInList> itemInLists = new List<ItemInList>();
            foreach (string name in names)
            {
                ItemInList itemInList = Instantiate(_itemInListPrefab, content);
                itemInList.ChooseThis += methodForRemove.Invoke;
                itemInList.Initialize(name);
                itemInLists.Add(itemInList);
            }

            return itemInLists;
        }

        private void ClearListWithItems(List<ItemInList> itemInLists)
        {
            Debug.Log($"Удаляем окна. Было до удаления {itemInLists.Count}");
            foreach (ItemInList itemInList in itemInLists)
            {
                Destroy(itemInList.gameObject);
            }

            itemInLists.Clear();
            Debug.Log($"Стало после {itemInLists.Count}");
        }

        private void ChangeProperty(string value)
        {
            int.TryParse(inputAge.text, out int age);
            SaveLoadCharacter saveLoadCharacter = new SaveLoadCharacter();

            saveLoadCharacter.name = inputName.text;
            saveLoadCharacter.homeworld = inputHome.text;
            saveLoadCharacter.background = inputBack.text;
            saveLoadCharacter.role = inputRole.text;
            saveLoadCharacter.prophecy = inputProph.text;
            saveLoadCharacter.elite = inputElite.text;
            saveLoadCharacter.gender = inputGender.text;
            saveLoadCharacter.age = age;
            saveLoadCharacter.skeen = inputSkeen.text;
            saveLoadCharacter.constitution = inputBody.text;
            saveLoadCharacter.hair = inputHair.text;
            saveLoadCharacter.physFeatures = inputPhysFeat.text;
            saveLoadCharacter.eyes = inputEyes.text;
            saveLoadCharacter.tradition = inputTraditions.text;
            saveLoadCharacter.memoryOfHome = inputRememberHome.text;
            saveLoadCharacter.memoryOfBackground = inputRememberBack.text;

            ChangePropertyCharacter?.Invoke(saveLoadCharacter);
        }

        private void CancelSelect()
        {
            var eventSystem = EventSystem.current;
            if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);
        }

        private void AddInclinationPressed() => AddInclination?.Invoke();

        private void AddFeaturePressed() => AddFeature?.Invoke();

        private void AddMentalPressed() => AddMental?.Invoke();

        private void AddMutationPressed() => AddMutation?.Invoke();

        private void RemoveInclinationPressed(string value) => RemoveInclination?.Invoke(value);

        private void RemoveFeaturePressed(string value) => RemoveFeature?.Invoke(value);

        private void RemoveMentalPressed(string value) => RemoveMental?.Invoke(value);

        private void RemoveMutationPressed(string value) => RemoveMutation?.Invoke(value);

        private void ChangeFeatureLvlPressed(string name, int lvl) => ChangeFeatureLvl?.Invoke(name, lvl);

        private void NextPressed() => Hide(Next);
    }
}

