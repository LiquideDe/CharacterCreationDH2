using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CreatorTogglesForFinalPanel : MonoBehaviour
{
    [SerializeField] private GameObject exampleToggleGroup, toggle, grid;
    [SerializeField] private BackgroundFinalPanelView _finalPanelWithToggles;
    private List<GameObject> _toggleGroups = new List<GameObject>();
    private List<GameObject> _toggles = new List<GameObject>();
    AudioManager _audioManager;

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void CreateToggles<T>(List<List<T>> traitList, string nameChoose) where T : INameWithDescription
    {
        foreach (List<T> traits in traitList)
        {
            CreateToggleGroup(nameChoose);
            for (int i = 0; i < traits.Count; i++)
            {
                CreateToggle(traits[i].Name, i, traits[i].Description);
            }
        }
    }

    public void CreateToggleEquipments(List<List<Equipment>> equipmentsList)
    {
        foreach (List<Equipment> equipment in equipmentsList)
        {
            CreateToggleGroup("Экипировка");
            for (int i = 0; i < equipment.Count; i++)
            {
                if (equipment[i].TypeEq == Equipment.TypeEquipment.Melee || equipment[i].TypeEq == Equipment.TypeEquipment.Range || equipment[i].TypeEq == Equipment.TypeEquipment.Grenade)
                {
                    Weapon weapon = (Weapon)equipment[i];
                    string dopText = $"\n Урон {weapon.Damage}, БрПроб {weapon.Penetration}, Качества {weapon.Properties}";
                    CreateToggle(equipment[i].NameWithAmount, i, equipment[i].Description + dopText);
                }
                else
                {
                    CreateToggle(equipment[i].NameWithAmount, i, equipment[i].Description);
                }

            }
        }
    }

    public void CreateToggleInclinations(List<List<GameStat.Inclinations>> inclinations)
    {
        foreach(List<GameStat.Inclinations> inclinationList in inclinations)
        {
            CreateToggleGroup("Склонности");
            int sc = 0;
            for(int i = 0; i < inclinationList.Count; i++)
            {
                CreateToggle(GameStat.inclinationTranslate[inclinationList[i]], sc, GameStat.descriptionInclination[inclinationList[i]]);
                sc++;
            }
        }
        
    }

    public void FinalResize()
    {
        foreach (GameObject togG in _toggleGroups)
        {
            int count = togG.transform.childCount;
            if (count > 4)
            {
                int mult = (int)(count / 4);
                var sizechanger = togG.GetComponent<RectTransform>();
                //sizechanger.sizeDelta = new Vector2(sizechanger.sizeDelta.x, sizechanger.sizeDelta.y + sizechanger.sizeDelta.y * mult);
                sizechanger.sizeDelta = new Vector2(sizechanger.sizeDelta.x, sizechanger.sizeDelta.y * mult);
            }
        }

        List<ToggleGroup> toggleGroups = new List<ToggleGroup>();
        foreach(GameObject game in _toggleGroups)
        {
            toggleGroups.Add(game.GetComponent<ToggleGroup>());
        }
        _finalPanelWithToggles.SetToggles(toggleGroups);
    }

    private void CreateToggleGroup(string nameGroup)
    {
        _toggleGroups.Add(Instantiate(exampleToggleGroup, grid.transform));
        _toggleGroups[^1].SetActive(true);
        _toggleGroups[^1].GetComponentInChildren<TextMeshProUGUI>().text = nameGroup;
    }

    private void CreateToggle(string name, int id, string description)
    {
        _toggles.Add(Instantiate(toggle));
        var newToggle = _toggles[^1].GetComponent<MyToggle>();
        newToggle.Text.text = name;
        newToggle.onValueChanged.AddListener(delegate { _audioManager.PlayClick(); });
        newToggle.group = _toggleGroups[^1].GetComponent<ToggleGroup>();
        newToggle.transform.SetParent(_toggleGroups[^1].transform);
        newToggle.gameObject.SetActive(true);
        newToggle.Id = id;
        _toggles[^1].GetComponent<ParamInfo>().SetDescription(description);

        int childCount = _toggleGroups[^1].transform.childCount - 2;
        if (childCount > 8)
        {
            int rows = (int)Math.Ceiling(childCount / 4f);
            _toggleGroups[^1].GetComponent<RectTransform>().sizeDelta = new Vector2(_toggleGroups[^1].GetComponent<RectTransform>().sizeDelta.x, 40 * rows);
        }
    }    

    
}
