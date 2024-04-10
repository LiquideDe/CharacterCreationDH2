using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListWithFeatures : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] ItemFeature itemFeatureExample;
    [SerializeField] ListWithNewFeatures listWithNewFeaturesExample;
    Character character;
    List<Feature> features = new List<Feature>();
    List<ItemFeature> itemFeatures = new List<ItemFeature>();
    AudioWork audioWork;

    public void SetParams(Character character, List<Feature> features, AudioWork audioWork)
    {
        this.character = character;
        this.features = features;
        this.audioWork = audioWork;
        foreach(Feature feature in character.Features)
        {
            AddingItem(feature);
        }
    }

    public void ShowNewFeatures()
    {
        audioWork.PlayClick();
        Canvas canvas = GetComponentInParent<Canvas>();
        var listWithNewFeatures = Instantiate(listWithNewFeaturesExample, canvas.transform);
        listWithNewFeatures.SetParams(features, character.Features, AddNewFeature, audioWork);
    }

    private void ChangeLvl(Feature feature)
    {
        audioWork.PlayClick();
        FindFeature(feature).Lvl = feature.Lvl;
    }

    private void RemoveFeature(Feature feature)
    {
        audioWork.PlayCancel();
        character.Features.Remove(FindFeature(feature));
    }

    private void AddNewFeature(Feature feature)
    {
        character.Features.Add(feature);
        AddingItem(feature);
    }

    private Feature FindFeature(Feature feature)
    {
        foreach (Feature feat in character.Features)
        {
            if (string.Compare(feature.Name, feat.Name, true) == 0)
            {
                return feat;
            }
        }

        return null;
    }

    private void AddingItem(Feature feature)
    {
        itemFeatures.Add(Instantiate(itemFeatureExample, content));
        itemFeatures[^1].SetParams(feature, ChangeLvl, RemoveFeature);
    }
}
