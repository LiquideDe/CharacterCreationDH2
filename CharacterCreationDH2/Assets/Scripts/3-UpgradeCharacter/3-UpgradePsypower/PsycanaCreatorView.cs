using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class PsycanaCreatorView : MonoBehaviour
{
    
    [SerializeField] PsyPanel _psyPanelPrefab;
    [SerializeField] GameObject[] lvls;
    [SerializeField] GameObject connectionsContainer, straightLine, panelDescription;
    [SerializeField] HorizontalLayoutGroup layoutGroupFirst, layoutGroupSecond, layoutGroupThird;
    [SerializeField] UpgradePsycanaView _view;
    private List<GameObject> lines = new List<GameObject>();
    private List<PsyPanel> psyPanels = new List<PsyPanel>();

    public void Initialize(List<PsyPower> psyPowers, List<PsyPower> characterPsyPowers, List<Connection> connections, JSONSizeSpacing sizeSpacing)
    {
        StartCoroutine(CreatePsyPanels(psyPowers, characterPsyPowers, connections, sizeSpacing));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
        }
    }

    IEnumerator CreatePsyPanels(List<PsyPower> psyPowers, List<PsyPower> characterPsyPowers, List<Connection> connections, JSONSizeSpacing sizeSpacing)
    {
        if(psyPanels.Count > 0)
        {
            Coroutine clear = StartCoroutine(ClearLists());
            yield return clear;
        }

        layoutGroupFirst.spacing = sizeSpacing.firstSpacing;
        layoutGroupSecond.spacing = sizeSpacing.secondSpacing;
        layoutGroupThird.spacing = sizeSpacing.thirdSpacing;

        foreach (PsyPower psyPower in psyPowers)
        {
            bool isActive = false;
            psyPanels.Add(Instantiate(_psyPanelPrefab, lvls[psyPower.Lvl].transform));

            foreach(PsyPower psyPowerInCharacter in characterPsyPowers)
            {
                if(string.Compare(psyPowerInCharacter.Name, psyPower.Name) == 0)
                {
                    isActive = true;
                    break;
                }
            }

            psyPanels[^1].SetPsyPanel(psyPower.Name, psyPower.ShortDescription, psyPower.Id, isActive);
            psyPanels[^1].gameObject.SetActive(true);
        }

        int i = 0;
        yield return new WaitForSeconds(0.2f);
        foreach (Connection connection in connections)
        {
            CreateConnections(connection.ParentPsyPower.Id, connection.ChildPsyPower.Id);
            i++;
        }
        _view.Initialize(psyPanels);
    }

    private void CreateConnections(int idFirstPoint, int idSecondPoint)
    {
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
        float koefH = 16f/9f;
        lines.Add(Instantiate(straightLine, connectionsContainer.transform));
        lines[^1].SetActive(true);
        lines[^1].name = name;
        //float height = Vector2.Distance(secondPoint, firstPoint)/ koefH;
        float height = Vector2.Distance(secondPoint, firstPoint)* 108;
        float width = 1 * koefH;
        lines[^1].GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        float newposX = secondPoint.x + (firstPoint.x - secondPoint.x) / 2;
        float newposY = secondPoint.y + (firstPoint.y - secondPoint.y) / 2;
        lines[^1].transform.position = new Vector3(newposX, newposY, 0);
        lines[^1].transform.Rotate(0, 0, angle);
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

    IEnumerator ClearLists()
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
        
        yield return new WaitForEndOfFrame();
    }
}
