using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.IO;

public class CreatorNewEquipment : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public delegate void CreateNewEq(Equipment equipment);
    protected CreateNewEq createNewEq;
    protected string nameEq;
    protected float weight;
    public TMP_InputField inputName, inputWeight, inputRarity;
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
            reader.rarity = inputRarity.text;
            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Things/{reader.name}.JSON", reader);
            Equipment equipment = new Equipment(inputName.text, "", inputRarity.text, weight);
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }
}
