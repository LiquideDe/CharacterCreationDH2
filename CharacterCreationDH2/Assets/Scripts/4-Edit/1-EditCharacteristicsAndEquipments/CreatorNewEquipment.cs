using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class CreatorNewEquipment : ViewWithButtonsDoneAndCancel
{

    [SerializeField] protected TMP_InputField _inputName, _inputWeight, _inputRarity;

    public event Action<Equipment> ReturnNewEquipment;
    public event Action WrongInput;

    public virtual void Initialize()
    {
        /*
        _buttonOk.onClick.AddListener(FinishCreating);
        _buttonCancel.onClick.AddListener(Cancel.Invoke);*/
    }

    public virtual void FinishCreating()
    {
        if (_inputName.text != "")
        {
            float.TryParse(_inputWeight.text, out float weight);
            JSONEquipmentReader reader = new JSONEquipmentReader();
            reader.name = _inputName.text;
            reader.description = "";
            reader.weight = weight;
            reader.rarity = _inputRarity.text;
            reader.typeEquipment = Equipment.TypeEquipment.Thing.ToString();
            reader.amount = 1;
            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Things/{reader.name}.JSON", reader);
            Equipment equipment = new Equipment(_inputName.text, "", _inputRarity.text, 1, weight);
            ReturnNewEquipment?.Invoke(equipment);
            gameObject.SetActive(false);
        }
        else
            WrongInputPressed();

    }

    public virtual void AddProperty(string property) { Debug.Log($"Не работает увы"); }

    protected void SaveEquipment<T>(string path, T jsonToSave)
    {
        List<string> data = new List<string>();
        data.Add(JsonUtility.ToJson(jsonToSave));
        File.WriteAllLines(path, data);
    }

    protected void SendEquipment(Equipment equipment) => ReturnNewEquipment?.Invoke(equipment);

    protected void WrongInputPressed() => WrongInput?.Invoke();

    protected override void ButtonDonePressed() => FinishCreating();
    
}
