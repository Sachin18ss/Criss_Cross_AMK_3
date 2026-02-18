using UnityEngine;

public class Cell : MonoBehaviour
{
    public int row;
    public int column;

    [Header("Scripts Reference")]
    private GridManager gridManager;

    private void Start()
    {
        gridManager = FindFirstObjectByType<GridManager>();   
    }
    

    void OnMouseDown()
    {
        //Debug.Log("Cell clicked");
        if (gridManager.IsCellEmpty(row, column))
        {
            gridManager.SetCell(row, column, 1);
            Debug.Log($"Clicked {row},{column}");
        }
        
    }
}
