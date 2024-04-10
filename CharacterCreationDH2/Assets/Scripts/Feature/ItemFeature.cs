using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemFeature : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textName;
    [SerializeField] TMP_InputField inputLvl;
    public string NameFeature { get => textName.text; }
    public string Lvl { get => inputLvl.text; }

    public delegate void ChangeLvl(Feature feature);
    ChangeLvl changeLvl;

    public delegate void RemoveThisFeature(Feature feature);
    RemoveThisFeature removeThisFeature;

    public void SetParams(Feature feature, ChangeLvl changeLvl, RemoveThisFeature removeThisFeature = null)
    {
        gameObject.SetActive(true);
        textName.text = feature.Name;
        inputLvl.text = feature.Lvl.ToString();
        this.changeLvl = changeLvl;
        this.removeThisFeature = removeThisFeature;
    }

    public void SetAnotherLvl()
    {
        changeLvl?.Invoke(CreateFeature());
    }

    public void RemoveThis()
    {
        removeThisFeature?.Invoke(CreateFeature());
        Destroy(gameObject);
    }

    private Feature CreateFeature()
    {
        int.TryParse(inputLvl.text, out int lvl);
        return new Feature(textName.text, lvl);
    }
}
