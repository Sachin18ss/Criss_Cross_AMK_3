using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int _rows = 3, _cloumns = 3;
    private int[,] _grid;
    private bool _isXTurn = true;

    public GameObject cellPrefab;
    public float cellSize = 1f;


    private void Awake()
    {
        _grid = new int[_rows, _cloumns];
    }

    private void Start()
    {
        DrawGrids();
    }

    public bool IsCellEmpty(int r, int c)
    {
        return _grid[r, c] == 0;
    }

    public void SetCell(int r, int c, int value)
    {
        _grid[r, c] = value;
    }

    public void DrawGrids()
    {
        for(int r = 0; r<_rows; r++)
        {
            for (int c = 0; c < _cloumns; c++)
            {
                Vector2 worldPos = new Vector2(r * cellSize, c * cellSize);

                GameObject cell = Instantiate(cellPrefab, worldPos, Quaternion.identity);
                cell.name = $"Cell_{r}_{c}";
                Cell cellScript = cell.GetComponent<Cell>();
                cellScript.row = r;
                cellScript.column = c;
            }
        }
    }

    public void OnCellCliked(Cell cell)
    {
        int r = cell.row;
        int c = cell.column;

        if (_grid[r, c] != 0) return;

        if(_isXTurn)
        {
            SetCell(r, c, 1);
            cell.SetValue("X");
        }
        else
        {
            SetCell(r, c, 2);
            cell.SetValue("O");
        }

        _isXTurn = !_isXTurn;
    }

}
