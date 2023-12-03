using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToggleVisual : VisualCanvas
{
    protected List<GameObject> toggleGroups = new List<GameObject>();
    protected List<GameObject> toggles = new List<GameObject>();
    [SerializeField] GameObject exampleToggleGroup, toggle, grid;
    protected void CreateToggleGroup(string nameGroup)
    {
        toggleGroups.Add(Instantiate(exampleToggleGroup, grid.transform));
        toggleGroups[^1].SetActive(true);
        toggleGroups[^1].GetComponentInChildren<TextMeshProUGUI>().text = nameGroup;
    }

    protected void CreateToggle(string name, int id, string description)
    {
        toggles.Add(Instantiate(toggle));
        var newToggle = toggles[^1].GetComponent<MyToggle>();
        newToggle.Text.text = name;
        newToggle.group = toggleGroups[^1].GetComponent<ToggleGroup>();
        newToggle.transform.SetParent(toggleGroups[^1].transform);
        newToggle.gameObject.SetActive(true);
        newToggle.Id = id;
        toggles[^1].GetComponent<ParamInfo>().SetDescription(description);
    }
}
