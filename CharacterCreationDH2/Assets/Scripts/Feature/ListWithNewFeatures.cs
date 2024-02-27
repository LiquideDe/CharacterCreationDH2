using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListWithNewFeatures : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] ItemFeatureActive itemFeatureExample;
    List<ItemFeatureActive> items = new List<ItemFeatureActive>();
    public delegate void ReturnNewFeature(Feature feature);
    ReturnNewFeature returnNew;

    public void SetParams(List<Feature> features, List<Feature> featuresCharacter, ReturnNewFeature returnNew)
    {
        gameObject.SetActive(true);
        this.returnNew = returnNew;
        foreach(Feature feature in features)
        {
            int sch = 0;
            foreach (Feature charFeature in featuresCharacter)
            {
                
                if(string.Compare(feature.Name, charFeature.Name, true) == 0)
                {
                    sch++;
                    break;
                }
            }
            if(sch == 0)
            {
                items.Add(Instantiate(itemFeatureExample, content));
                items[^1].SetParams(feature, AddThisFeature);
            }
        }
    }

    private void AddThisFeature(Feature feature)
    {
        returnNew?.Invoke(feature);
        Cancel();
    }

    public void Cancel()
    {
        Destroy(gameObject);
    }
}
