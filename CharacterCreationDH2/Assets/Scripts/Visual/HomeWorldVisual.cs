using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Text;
using System;
using System.Linq;
using UnityEngine.EventSystems;

public class HomeWorldVisual : VisualCanvas
{
    public delegate void ChosenWorld(Homeworld chosenWorld);
    private ChosenWorld chosenWorld;
    [SerializeField] GameObject finalPanel;
    [SerializeField] GameObject[] buttons;
    [SerializeField] TMP_InputField[] inputs;
    [SerializeField] TextMeshProUGUI textTrad;
    [SerializeField] GameObject poleTriggera;
    private Homeworld homeworld;
    private List<string> skeens = new List<string>();
    private List<string> eyes = new List<string>();
    private List<string> hair = new List<string>();
    private List<string> age = new List<string>();
    private List<string> rememberThing = new List<string>();
    private List<string> body = new List<string>();
    private List<string> traditions = new List<string>();
    private List<string> phys = new List<string>();
    private int generatedFateB, generatedWound;
    private string generatedSkeen, generatedEye, generatedHair, generatedage, generatedRememberThing, generatedBody, generatedTraditions, generatedPhys;

    public void FinalTouchToWorld()
    {
        finalPanel.SetActive(true);
    }
    public void WorldIsChosen()
    {
        if(CheckAllInputs())
        {
            homeworld.Fatepoint += generatedFateB;
            homeworld.Wound += generatedWound;
            homeworld.Skeen = generatedSkeen;
            homeworld.Eyes = generatedEye;
            homeworld.Hair = generatedHair;
            homeworld.Age = generatedage;
            homeworld.Remember = generatedRememberThing;
            homeworld.Body = generatedBody;
            homeworld.Traditions = generatedTraditions;
            homeworld.Phys = generatedPhys;

            chosenWorld?.Invoke(homeworld);
            Destroy(gameObject);
        }        
    }
    public void CancelChose()
    {
        finalPanel.SetActive(false);
        CancelAllTexts();
    }

    private bool CheckAllInputs()
    {
        foreach (GameObject but in buttons)
        {
            if (but.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    private void CancelAllTexts()
    {
        foreach (TMP_InputField tmp in inputs)
        {
            tmp.text = "";
            tmp.interactable = true;
        }
        foreach (GameObject but in buttons)
        {
            but.SetActive(true);
        }
        poleTriggera.SetActive(false);
    }

    public void regFinalDelegate(ChosenWorld chosenWorld)
    {
        this.chosenWorld = chosenWorld;
    }
    public void ShowWorld(Homeworld homeworld)
    {
        path = homeworld.PathHomeworld;
        textName.text = ReadText(path + "/Название.txt");        
        this.homeworld = homeworld;
        SetImage(path);
        textBonusDescr.text = ReadText(path + "/Бонус.txt");
        textDescr.text = ReadText(path + "/Описание.txt");
        textCitata.text = ReadText(path + "/Цитата.txt");
        if(images.Count > 1)
        {
            InvokeRepeating("ChangeImage", 6, 6);
        }
        gameObject.SetActive(true);
        skeens = ReadText(path + "/Кожа.txt").Split(new char[] { '/' }).ToList();
        eyes = ReadText(path + "/Глаза.txt").Split(new char[] { '/' }).ToList();
        hair = ReadText(path + "/Волосы.txt").Split(new char[] { '/' }).ToList();
        age = ReadText(path + "/Возраст.txt").Split(new char[] { '/' }).ToList();
        body = ReadText(path + "/Телосложение.txt").Split(new char[] { '/' }).ToList();
        rememberThing = ReadText(path + "/Памятные вещи.txt").Split(new char[] { '/' }).ToList();
        traditions = ReadText(path + "/Традиции.txt").Split(new char[] { '/' }).ToList();
        phys = ReadText(path + "/Физические особенности.txt").Split(new char[] { '/' }).ToList();
    }

    private int GenerateValue(int max)
    {
        //return UnityEngine.Random.Range(1, max);
        System.Random random = new System.Random();
        return random.Next(1,max);
    }

    public void GenerateFromButton(int id)
    {
        if (!IsInputFieldTyped(id))
        {
            ContinueGenerate(id, false);
        }        
    }

    public void GenerateFromInput(int id)
    {
        StartCoroutine(CheckInput(id));
        CancelSelect();
    }

    private void CancelSelect()
    {
        var eventSystem = EventSystem.current;
        if (!eventSystem.alreadySelecting) eventSystem.SetSelectedGameObject(null);
    }

    private void ContinueGenerate(int id, bool fromInput)
    {
        CancelSelect();
        buttons[id].SetActive(false);
        //inputs[id].interactable = false;
        inputs[id].textComponent.enableWordWrapping = true;
        StartCoroutine(DisableInput(inputs[id]));
        switch (id)
        {
            case 0:
                    generatedFateB = fromInput ? int.Parse(inputs[id].text) : GenerateValue(10);
                    inputs[0].text = $"Ваши очки судьбы равны {homeworld.IsBonusFate(generatedFateB)}";
                break;
            case 1:
                    generatedWound = fromInput ? int.Parse(inputs[id].text) : GenerateValue(5);
                    inputs[1].text = $"Ваше здоровье равно {homeworld.Wound + generatedWound}";
                break;
            case 2:
                generatedage = fromInput ? PoleChudes(age, int.Parse(inputs[id].text)) : PoleChudes(age);
                inputs[2].text = $"В вашем возрасте вас называют как {generatedage}";
                break;
            case 3:
                generatedHair = fromInput ? PoleChudes(hair, int.Parse(inputs[id].text)) : PoleChudes(hair);
                inputs[3].text = $"Ваши волосы {generatedHair}";
                break;
            case 4:
                generatedEye = fromInput ? PoleChudes(eyes, int.Parse(inputs[id].text)) : PoleChudes(eyes);
                inputs[4].text = $"Ваши глаза {generatedEye}";
                break;
            case 5:
                generatedSkeen = fromInput ? PoleChudes(skeens, int.Parse(inputs[id].text)) : PoleChudes(skeens);
                inputs[5].text = $"Ваша кожа {generatedSkeen}";
                break;
            case 6:
                generatedRememberThing = fromInput ? PoleChudes(rememberThing, int.Parse(inputs[id].text)) : PoleChudes(rememberThing);
                inputs[6].text = $"С вашего родного мира вы забрали с собой {generatedRememberThing}";
                break;
            case 7:
                generatedBody = fromInput ? PoleChudes(body, int.Parse(inputs[id].text)) : PoleChudes(body);
                inputs[7].text = $"По вашему телосложению вас называют {generatedBody}";
                break;
            case 8:                
                generatedTraditions = fromInput ? PoleChudes(traditions, int.Parse(inputs[id].text)) : PoleChudes(traditions);
                inputs[8].text = $"Вы придерживаетесь традиции: {generatedTraditions}";
                textTrad.text = inputs[8].text;
                poleTriggera.SetActive(true);
                break;
            case 9:
                generatedPhys = fromInput ? PoleChudes(phys, int.Parse(inputs[id].text)) : PoleChudes(phys);
                inputs[9].text = $"Ваша физическая особенность: {generatedPhys}";
                break;

        }
        CancelSelect();
    }

    IEnumerator DisableInput(TMP_InputField input)
    {
        yield return new WaitForEndOfFrame();
        input.interactable = false;
    }

    IEnumerator CheckInput(int id)
    {
        yield return new WaitForEndOfFrame();
        if (IsInputFieldTyped(id))
        {
            if (int.TryParse(inputs[id].text, out int number))
            {
                if (number <= 100 && number > 0)
                {
                    ContinueGenerate(id, true);
                }
                else
                {
                    inputs[id].text = "";
                }
            }
        }
        else
        {
            inputs[id].text = "";
        }
    }

    private void Sbros(int id)
    {
        buttons[id].SetActive(true);
        inputs[id].interactable = true;
        inputs[id].text = "";
    }

    private bool IsInputFieldTyped(int id)
    {
        if (inputs[id].text != "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private string PoleChudes(List<string> baraban, int naBarabane = 0)
    {
        int variants = 100 / baraban.Count;
        if(naBarabane == 0)
        {
            naBarabane = GenerateValue(100);
        }
        int id = (int)(naBarabane/variants);
        return baraban[id];
    }

    

    
}
