using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCharacter : OperationWithCharacter
{
    [SerializeField] TMP_InputField inputExp;    
    [SerializeField] private CanvasTrainingChar characteristicPanel;    
    [SerializeField] private GameObject panelWithInput;    
    
    public void ShowUpgrade(string path)
    {
        InitialCreators(path);
        panelWithInput.SetActive(true);
        gameObject.SetActive(true);
    }

    public void StartUpgradeCharacter()
    {
        int exp;
        if(inputExp.text.Length > 0 && int.TryParse(inputExp.text, out exp))
        {
            character.ExperienceUnspent += exp;
            TrainingClass train = gameObject.AddComponent<TrainingClass>();
            train.RegDelegate(Finish);
            train.OpenTraining(characteristicPanel, skillTrainingCanvas, talentTrainingCanvas, psyCanvas, character, creatorTalents, audioWork);
        }
        
    }

}
