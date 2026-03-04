using System;
using System.Collections;
using TMPro;
using Unity.Multiplayer.PlayMode;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEngine.Rendering.DebugUI;
//using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    public int _rows = 3, _cloumns = 3;
    public Cell[,] _cells;
    public static int[,] _grid;

   

    public GameObject cellPrefab;
    public Transform cellsHolder;
    public float cellSize = 1f;

    [Header("Scripts Reference")]
    [SerializeField] private ResetGameLogic resetGameLogic;
    [SerializeField] private GameManager gameManager;

    //public event Action<string> OnSettingValue;

    private void Awake()
    {
        _grid = new int[_rows, _cloumns];
        _cells = new Cell[_rows, _cloumns];
    }

    private void Start()
    {
        DrawGrids();
        ;
    }


    /*private void OnDisable()
    {
        Cell.OnCellCliked -= IsCellEmpty;
        Cell.OnCellEmpty = OnCellCliked;
    }*/
    
    public bool IsCellEmpty(int r, int c)
    {
        return _grid[r, c] == 0;
    }

    public void DrawGrids()
    {
        for(int r = 0; r<_rows; r++)
        {
            for (int c = 0; c < _cloumns; c++)
            {
                Vector2 worldPos = new Vector2(r * cellSize, c * cellSize);

                GameObject cell = Instantiate(cellPrefab, worldPos, Quaternion.identity, cellsHolder);
                
                cell.name = $"Cell_{r}_{c}";
                Cell cellScript = cell.GetComponent<Cell>();
                cellScript.row = r;
                cellScript.column = c;

                _cells[r,c] = cellScript;
            }
        }
    }

    
    /*private void SubscribeEvent()
    {
        _cells.OnCellCliked += IsCellEmpty;
        Cell.OnCellEmpty += OnCellCliked;
    }

    private void UnSubscribeEvent()
    {
        Cell.OnCellCliked += IsCellEmpty;
        Cell.OnCellEmpty += OnCellCliked;
    }*/
}
