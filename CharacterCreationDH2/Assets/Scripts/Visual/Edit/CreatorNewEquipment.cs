using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.IO;

public class CreatorNewEquipment : MonoBehaviour, IDragHandler
{
    public delegate void CreateNewEq(Equipment equipment);
    protected CreateNewEq createNewEq;
    protected string nameEq;
    protected float weight;
    public TMP_InputField inputName, inputWeight, inputRarity;
    protected List<TMP_InputField> inputs = new List<TMP_InputField>();
    protected AudioWork audioWork;

    public void RegDelegate(CreateNewEq createNewEq, AudioWork audioWork)
    {
        this.createNewEq = createNewEq;
        this.audioWork = audioWork;
    }

    public void FinishCreating()
    {
        if(inputName.text != "")
        {
            audioWork.PlayDone();
            float.TryParse(inputWeight.text, out weight);
            JSONEquipmentReader reader = new JSONEquipmentReader();
            reader.name = inputName.text;
            reader.description = "";
            reader.weight = weight;
            reader.rarity = inputRarity.text;
            reader.typeEquipment = Equipment.TypeEquipment.Thing.ToString();
            reader.amount = 1;
            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Things/{reader.name}.JSON", reader);
            Equipment equipment = new Equipment(inputName.text, "", inputRarity.text, 1,weight);
            createNewEq?.Invoke(equipment);
            gameObject.SetActive(false);
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

    protected void SaveEquipment<T>(string path, T jsonToSave)
    {
        List<string> data = new List<string>();
        data.Add(JsonUtility.ToJson(jsonToSave));
        File.WriteAllLines(path, data);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }

    public void Cancel()
    {
        audioWork.PlayCancel();
        Destroy(gameObject);
    }
}
