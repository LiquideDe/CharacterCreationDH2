using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text;
using System;

public class HomeWorldVisual : VisualCanvas
{
    public delegate void ChosenWorld(Homeworld chosenWorld, int fate, int wounds);
    private ChosenWorld chosenWorld;
    [SerializeField] GameObject finalPanel;
    [SerializeField] TMP_InputField woundsText, fateText;
    private Homeworld homeworld;

    public void FinalTouchToWorld()
    {
        finalPanel.SetActive(true);
    }
    public void WorldIsChosen()
    {
        if(fateText.text != "" && woundsText.text != "")
        {
            chosenWorld?.Invoke(homeworld, int.Parse(fateText.text), int.Parse(woundsText.text));
            Destroy(gameObject);
        }        
    }
    public void CancelChose()
    {
        finalPanel.SetActive(false);
        fateText.text = null;
        woundsText.text = null;
    }

    public void GenerateFate()
    {
        int fate = UnityEngine.Random.Range(1, 10);
        fateText.text = fate.ToString();
    }

    public void GenerateWound()
    {
        int wound = UnityEngine.Random.Range(1, 5);
        woundsText.text = wound.ToString();
    }

    public void regFinalDelegate(ChosenWorld chosenWorld)
    {
        this.chosenWorld = chosenWorld;
    }
    public void ShowWorld(Homeworld homeworld)
    {
        textName.text = ReadText("Название.txt");
        path = homeworld.PathHomeworld;
        this.homeworld = homeworld;
        IEnumerable<string> imageFiles = Directory.EnumerateFiles(path, "*.jpg");
        foreach(string s in imageFiles)
        {
            images.Add(ReadImage(s));
        }
        image.sprite = images[0];
        textBonusDescr.text = ReadText("Бонус.txt");
        textDescr.text = ReadText("Описание.txt");
        textCitata.text = ReadText("Цитата.txt");
        if(images.Count > 1)
        {
            InvokeRepeating("ChangeImage", 6, 6);
        }
        gameObject.SetActive(true);
    }

    

    
}
