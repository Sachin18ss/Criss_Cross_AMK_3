using System;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
public class Cell : MonoBehaviour
{
    public int row;
    public int column;

    [SerializeField] private TextMeshPro _cellText;

    //public event Func<int, int,bool> OnCellCliked;
    //public event Action<Cell> OnCellEmpty;


    [Header("Scripts Reference")]
    private GridManager gridManager;
    [SerializeField] private CellInteraction interaction;

    /*private void OnEnable()
    {
        gridManager = FindFirstObjectByType<GridManager>();
        gridManager.OnSettingValue += SetValue;
    }*/
    private void Start()
    {
        gridManager = FindFirstObjectByType<GridManager>();
        interaction= FindFirstObjectByType<CellInteraction>();
        _cellText = GetComponentInChildren<TextMeshPro>(); ;
    }
    private void OnDisable()
    {
        //gridManager.OnSettingValue -= SetValue;
    }

    public void SetValue(string value)
    {
        _cellText.color = value == "O" ? Color.blue : Color.red;
        _cellText.text = value;
    }

    public void SetCell(int r, int c, int value)
    {
        GridManager._grid[r, c] = value;
    }

    void OnMouseDown()
    {
        /*if(OnCellCliked?.Invoke(row, column) == true)
        {
            OnCellEmpty?.Invoke(this);
        }*/


        if (gridManager.IsCellEmpty(row, column))
        {
            interaction.OnCellCliked(this);
            //gridManager.SetCell(row, column, 1);
            //Debug.Log($"Clicked {row},{column}");
        }    
    }


}
