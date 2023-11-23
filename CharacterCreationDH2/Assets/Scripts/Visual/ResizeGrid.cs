using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeGrid : MonoBehaviour
{
    [SerializeField] GridLayoutGroup layoutGroup;
    Vector2 baseSize = new Vector2(1366, 768); // Base size of the screen
    Vector2 baseCellSize; // In editor Cell Size for GridLayoutComponent
    Vector2 baseCellSpacing;
    private void Start()
    {
        layoutGroup = GetComponent<GridLayoutGroup>();
        baseCellSize = layoutGroup.cellSize;
        baseCellSpacing = layoutGroup.spacing;

        Vector2 screenSize = new Vector2(Screen.width, Screen.height); // Current screen size
        layoutGroup.cellSize = (screenSize / baseSize) * baseCellSize;
        layoutGroup.spacing = (screenSize / baseSize) * baseCellSpacing;
    }
}
