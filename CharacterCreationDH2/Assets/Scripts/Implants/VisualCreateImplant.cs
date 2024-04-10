using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class VisualCreateImplant : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName, inputDescription, inputArmor, inputToughness;
    [SerializeField] Toggle toggleHead, toggleRightHand, toggleLeftHand, toggleBody, toggleRightLeg, toggleLeftLeg, toggleAllBody;
    public delegate void ReturnImplant(MechImplant mechImplant);
    private ReturnImplant returnImplant;
    AudioWork audioWork;

    public void SetParams(ReturnImplant returnImplant, AudioWork audioWork)
    {
        this.audioWork = audioWork;
        this.returnImplant = returnImplant;
        gameObject.SetActive(true);
    }

    public void Done()
    {
        if(inputName.text.Length > 0)
        {
            audioWork.PlayDone();
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


            ImplantSaveLoad implantSave = new ImplantSaveLoad();
            implantSave.name = name;
            implantSave.armor = armor;
            implantSave.partsOfBody = partOfBody.ToString();
            implantSave.description = description;
            implantSave.bonusToughness = toughness;
            List<string> data = new List<string>();
            data.Add(JsonUtility.ToJson(implantSave));
            File.WriteAllLines($"{Application.dataPath}/StreamingAssets/Implants/{name}.JSON", data);

            returnImplant?.Invoke(mechImplant);
            Destroy(gameObject);
        }
        else
        {
            audioWork.PlayWarning();
        }
    }

    public void Cancel()
    {
        audioWork.PlayCancel();
        Destroy(gameObject);
    }
}
