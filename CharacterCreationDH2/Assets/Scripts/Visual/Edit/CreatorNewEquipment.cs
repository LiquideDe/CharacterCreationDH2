using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class CreatorNewEquipment : MonoBehaviour
{
    public delegate void CreateNewEq(Equipment equipment);
    protected CreateNewEq createNewEq;
    protected string nameEq;
    protected float weight;
    public TMP_InputField inputName, inputWeight;
    protected List<TMP_InputField> inputs = new List<TMP_InputField>();

    private void Start()
    {
        inputs.Add(inputName);
        inputs.Add(inputWeight);
    }

    public void RegDelegate(CreateNewEq createNewEq)
    {
        this.createNewEq = createNewEq;
    }

    public void FinishCreating()
    {
        if(inputName.text != "")
        {
            float.TryParse(inputWeight.text, out weight);
            JSONEquipmentReader reader = new JSONEquipmentReader();
            reader.name = inputName.text;
            reader.description = "";
            reader.weight = weight;
            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Things/{reader.name}.JSON", reader);
            Equipment equipment = new Equipment(inputName.text, "", weight);
            createNewEq?.Invoke(equipment);
            ClearInputs();
            gameObject.SetActive(false);
        }
    }

    protected void ClearInputs()
    {
        foreach(TMP_InputField text in inputs)
        {
            text.text = "";
        }
    }

    protected void SaveEquipment<T>(string path, T jsonToSave)
    {
        List<string> data = new List<string>();
        data.Add(JsonUtility.ToJson(jsonToSave));
        File.WriteAllLines(path, data);
    }
}
