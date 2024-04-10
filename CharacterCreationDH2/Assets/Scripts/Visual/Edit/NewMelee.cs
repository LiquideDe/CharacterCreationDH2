using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;

public class NewMelee : CreatorNewEquipment
{
    public TMP_InputField inputClass, inputDamage, inputBonusDamage, inputPenetration;
    public TMP_Dropdown dropDown;
    public Transform content;
    public ListWithNewFeatures listWithPrefab;
    public ItemFeature itemExample;
    List<ItemFeature> items = new List<ItemFeature>();

    public new void FinishCreating()
    {
        if (inputName.text != "" && inputClass.text.Length > 0 && inputPenetration.text.Length > 0 && inputWeight.text.Length > 0)
        {
            audioWork.PlayDone();
            float.TryParse(inputWeight.text, out weight);
            int.TryParse(inputPenetration.text, out int penetration);
            JSONMeleeReader meleeReader = new JSONMeleeReader();
            meleeReader.name = inputName.text;
            meleeReader.penetration = penetration;
            meleeReader.properties = MakePropertiesText();
            meleeReader.weaponClass = inputClass.text;
            meleeReader.weight = weight;
            meleeReader.damage = MakeDamageText();
            meleeReader.typeEquipment = Equipment.TypeEquipment.Melee.ToString();
            meleeReader.amount = 1;

            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Melee/{meleeReader.name}.JSON", meleeReader);

            Weapon weapon = new Weapon(meleeReader);
            createNewEq?.Invoke(weapon);
            Destroy(gameObject);
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

    protected string MakeDamageText()
    {
        string typeDamage = "";
        switch (dropDown.value)
        {
            case 0:
                typeDamage = "В";
                break;
            case 1:
                typeDamage = "Р";
                break;
            case 2:
                typeDamage = "У";
                break;
            case 3:
                typeDamage = "Э";
                break;
        }
        int.TryParse(inputDamage.text, out int damage);
        int.TryParse(inputBonusDamage.text, out int bonusDamage);
        if(damage == 0)
        {
            damage = 1;
        }
        string textdamage = $"{damage}к10+{bonusDamage}{typeDamage}";
        return textdamage;
    }

    public void AddProperty()
    {
        audioWork.PlayClick();
        List<string> properties = new List<string>();
        List<Feature> emptyList = new List<Feature>();
        List<Feature> listWithFeatures = new List<Feature>();
        properties.AddRange(GameStat.ReadText($"{Application.dataPath}/StreamingAssets/Equipments/PropertiesOfWeapon.txt").Split(new char[] { '/' }).ToList());
        foreach(string prop in properties)
        {
            listWithFeatures.Add(new Feature(prop, 0));
        }
        var listWith = Instantiate(listWithPrefab, transform);
        listWith.SetParams(listWithFeatures, emptyList, SetProperty, audioWork);
    }

    protected void SetProperty(Feature feature)
    {
        items.Add(Instantiate(itemExample, content));
        items[^1].SetParams(feature, null, RemoveThisFeature);
    } 

    private void RemoveThisFeature(Feature feature)
    {
        audioWork.PlayCancel();
        foreach(ItemFeature item in items)
        {
            if(string.Compare(item.NameFeature, feature.Name, true) == 0)
            {
                Debug.Log($"Нашли {feature.Name}");
                Destroy(item.gameObject);
                items.Remove(item);
                break;
            }
        }
    }

    protected string MakePropertiesText()
    {
        string properties = "";
        foreach(ItemFeature item in items)
        {
            int.TryParse(item.Lvl, out int lvl);
            if(lvl != 0)
            {
                properties += $"{item.NameFeature}({lvl}),";
            }
            else
            {
                properties += $"{item.NameFeature},";
            }
            
        }
        properties = properties.TrimEnd(',');
        return properties;
    }

}
