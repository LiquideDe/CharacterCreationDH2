using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class PsyCanvas : MonoBehaviour
{
    public delegate bool PsyPowerCanBeTaken(int school, int id);
    public delegate PsyPower GetPsyPower(int school, int id);
    public delegate void NextSchool(int school, PsyCanvas psyCanvas);
    public delegate void PrevSchool(int school, PsyCanvas psyCanvas);
    public delegate void NewPsyLvl(PsyCanvas psyCanvas);
    NextSchool nextSchool;
    PrevSchool prevSchool;
    GetPsyPower getPsyPower;
    PsyPowerCanBeTaken psyPowerCanBeTaken;
    NewPsyLvl newPsyLvl;
    private List<PsyPanel> psyPanels = new List<PsyPanel>();
    [SerializeField] PsyPanel examplePsyPanel;
    [SerializeField] GameObject[] lvls;
    [SerializeField] GameObject connectionsContainer, straightLine, panelDescription;
    [SerializeField] HorizontalLayoutGroup layoutGroupFirst, layoutGroupSecond, layoutGroupThird;
    [SerializeField] Sprite spriteDone, spriteRegular;
    [SerializeField] Image imageNextButton;
    private int chosenSchool;
    [SerializeField] private TextMeshProUGUI textExp, textName, textCost, textDescription, textAction, textCostPsyRate, textPsyRate, textNameSchool;
    private List<GameObject> lines = new List<GameObject>();
    private int chosenId, experience;
    bool isEdit;

    public void CreatePsyPanels(List<PsyPower> psyPowers, List<Connection> connections, int school, int exp, int psyRate, string nameSchool, JSONSizeSpacing sizeSpacing,bool isFinalSchool, bool isEdit = false)
    {
        experience = exp;
        this.isEdit = isEdit;
        if (isFinalSchool)
        {
            imageNextButton.sprite = spriteDone;
        }
        else
        {
            imageNextButton.sprite = spriteRegular;
        }

        UpdateText(exp);
        chosenSchool = school;
        layoutGroupFirst.spacing = sizeSpacing.firstSpacing;
        layoutGroupSecond.spacing = sizeSpacing.secondSpacing;
        layoutGroupThird.spacing = sizeSpacing.thirdSpacing;
        foreach (PsyPower psyPower in psyPowers)
        {
            psyPanels.Add(Instantiate(examplePsyPanel, lvls[psyPower.Lvl].transform));
            psyPanels[^1].SetPsyPanel(psyPower.NamePower, psyPower.ShortDescription,psyPower.Cost, psyPower.Id, psyPower.IsActive);
            psyPanels[^1].RegDelegate(OpenPanel);
            psyPanels[^1].gameObject.SetActive(true);
            
        }
        foreach(Connection connection in connections)
        {
            StartCoroutine(PauseForConnection(connection));
        }
        UpdateTextPsyRate(psyRate);
        textNameSchool.text = $"{nameSchool}";

    }

    public void UpdateText(int exp)
    {
        if (isEdit)
        {
            textExp.text = $"Бесконечно";
        }
        else
        {
            textExp.text = $"ОО {exp}";
        }
        
    }

    public void UpdateTextPsyRate(int psyRate)
    {
        textPsyRate.text = $"Ваш Пси Рейтинг равен {psyRate}";
        textCostPsyRate.text = $"Для улучшения Пси Рейтинга нужно {200 * (psyRate + 1)} очков опыта.";
    }
    IEnumerator PauseForConnection(Connection connection)
    {
        yield return new WaitForSeconds(0.2f);
        CreateConnections(connection.ParentPsyPower.Id, connection.ChildPsyPower.Id);
    }

    private void CreateConnections(int idFirstPoint, int idSecondPoint)
    {
        //DrawConnection(circles[idFirstPoint].anchoredPosition, circles[idSecondPoint].anchoredPosition);
        //DrawConnection(GetPsyPanelById(idFirstPoint).transform.position, GetPsyPanelById(idSecondPoint).transform.position);
        DrawStraightLine(GetPsyPanelById(idFirstPoint).transform.position, GetPsyPanelById(idSecondPoint).transform.position, $"{idFirstPoint}-{idSecondPoint}");
    }

    private void DrawStraightLine(Vector3 firstPoint, Vector3 secondPoint, string name)
    {        
        var middle = (firstPoint.y + secondPoint.y) / 2.0f;
        
        Vector3[] vectors = new Vector3[4];
        vectors[0] = new Vector3(firstPoint.x, firstPoint.y, 0);
        vectors[1] = new Vector3(firstPoint.x, middle,0);
        vectors[2] = new Vector3(secondPoint.x, middle, 0);
        vectors[3] = new Vector3(secondPoint.x, secondPoint.y, 0);
        SetPosition(vectors[0], vectors[1], 0, name);
        SetPosition(vectors[1], vectors[2], 90, name);
        SetPosition(vectors[2], vectors[3], 0, name);

    }

    private void SetPosition(Vector3 firstPoint, Vector3 secondPoint, int angle, string name)
    {
        float koefH = Screen.height / 1080f;
        lines.Add(Instantiate(straightLine, connectionsContainer.transform));
        lines[^1].SetActive(true);
        lines[^1].name = name;
        float height = Vector2.Distance(secondPoint, firstPoint)/ koefH;
        float width = 1 * koefH;
        lines[^1].GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        float newposX = secondPoint.x + (firstPoint.x - secondPoint.x) / 2;
        float newposY = secondPoint.y + (firstPoint.y - secondPoint.y) / 2;
        lines[^1].transform.position = new Vector3(newposX, newposY, 0);
        lines[^1].transform.Rotate(0, 0, angle);
    }

    public void RegDelegate(PsyPowerCanBeTaken psyPowerCanBeTaken, GetPsyPower getPsyPower, NewPsyLvl newPsyLvl)
    {
        this.psyPowerCanBeTaken = psyPowerCanBeTaken;
        this.getPsyPower = getPsyPower;
        this.newPsyLvl = newPsyLvl;
    }

    public void RegDelegateNextPrev(NextSchool nextSchool, PrevSchool prevSchool)
    {
        this.nextSchool = nextSchool;
        this.prevSchool = prevSchool;
    }
    private bool CheckPsyPowerForTeach(int id)
    {
        return ((bool)(psyPowerCanBeTaken?.Invoke(chosenSchool, id)));
    }

    private PsyPanel GetPsyPanelById(int id)
    {
        foreach(PsyPanel psyPanel in psyPanels)
        {
            if(psyPanel.Id == id)
            {
                return psyPanel;
            }
        }

        Debug.Log($"!!!!! Не смогли найти PsyPanel под номером {id}");
        return null;
    }

    private void OpenPanel(int id)
    {
        chosenId = id;
        panelDescription.SetActive(true);
        PsyPower psyPower = getPsyPower?.Invoke(chosenSchool, id);
        textName.text = psyPower.NamePower;
        textAction.text = psyPower.Action;
        textCost.text = psyPower.TextCost;
        textDescription.text = psyPower.Description;
    }

    public void ClosePanel()
    {
        panelDescription.SetActive(false);
    }

    public void BuyPower()
    {
        if (CheckPsyPowerForTeach(chosenId))
        {
            PsyPanel psyPanel = GetPsyPanelById(chosenId);
            psyPanel.BuyPower();
            experience -= psyPanel.Cost;
            UpdateText(experience);
        }
        ClosePanel();
    }

    public void ButtonNextSchool()
    {
        ClearLists();
        nextSchool?.Invoke(chosenSchool, this);
    }

    public void ButtonPrevSchool()
    {
        ClearLists();
        prevSchool?.Invoke(chosenSchool, this);
    }

    public void SetNewPsyLvl()
    {
        newPsyLvl?.Invoke(this);
    }

    private void ClearLists()
    {
        foreach (PsyPanel psyPanel in psyPanels)
        {
            Destroy(psyPanel.gameObject);
        }
        psyPanels.Clear();
        foreach(GameObject connection in lines)
        {
            Destroy(connection);
        }
        lines.Clear();
    }
}
