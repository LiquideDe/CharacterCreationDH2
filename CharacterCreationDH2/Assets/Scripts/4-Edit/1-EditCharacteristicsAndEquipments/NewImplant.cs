using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class NewImplant : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName, inputDescription, inputArmor, inputToughness;
    [SerializeField] Toggle toggleHead, toggleRightHand, toggleLeftHand, toggleBody, toggleRightLeg, toggleLeftLeg, toggleAllBody;
    [SerializeField] Button _buttonOk, _buttonCancel;
    public event Action Cancel, WrongInput;
    public event Action<MechImplant> ReturnImplant;

    private void OnEnable()
    {
        _buttonOk.onClick.AddListener(Done);
        _buttonCancel.onClick.AddListener(CancelPressed);
    }

    private void OnDisable()
    {
        _buttonOk.onClick.RemoveAllListeners();
        _buttonCancel.onClick.RemoveAllListeners();
    }

    public void Initialize() { }

    public void Done()
    {
        if (inputName.text.Length > 0)
        {
            string name = inputName.text;
            string description = inputDescription.text;
            int.TryParse(inputArmor.text, out int armor);
            MechImplant.PartsOfBody partOfBody;
            if (toggleHead.isOn)
            {
                partOfBody = MechImplant.PartsOfBody.Head;
            }
            else if (toggleRightHand.isOn)
            {
                partOfBody = MechImplant.PartsOfBody.RightHand;
            }
            else if (toggleLeftHand.isOn)
            {
                partOfBody = MechImplant.PartsOfBody.LeftHand;
            }
            else if (toggleBody.isOn)
            {
                partOfBody = MechImplant.PartsOfBody.Body;
            }
            else if (toggleRightLeg.isOn)
            {
                partOfBody = MechImplant.PartsOfBody.RightLeg;
            }
            else if (toggleLeftLeg.isOn)
            {
                partOfBody = MechImplant.PartsOfBody.LeftLeg;
            }
            else
            {
                partOfBody = MechImplant.PartsOfBody.All;
            }
            int.TryParse(inputToughness.text, out int toughness);
            MechImplant mechImplant = new MechImplant(name, partOfBody, armor, description, toughness);


            SaveLoadImplant implantSave = new SaveLoadImplant();
            implantSave.name = name;
            implantSave.armor = armor;
            implantSave.partsOfBody = partOfBody.ToString();
            implantSave.description = description;
            implantSave.bonusToughness = toughness;
            List<string> data = new List<string>();
            data.Add(JsonUtility.ToJson(implantSave));
            File.WriteAllLines($"{Application.dataPath}/StreamingAssets/Implants/{name}.JSON", data);

            ReturnImplant?.Invoke(mechImplant);
        }
        else
            WrongInput?.Invoke();
    }

    public void DestroyView() => Destroy(gameObject);

    public void CancelPressed() => Cancel?.Invoke();
}