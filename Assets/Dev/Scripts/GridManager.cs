using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField]private int _rows = 3, _cloumns = 3;
    [SerializeField] private int[,] _grid;
    [SerializeField] private bool _isXTurn = true;
    [SerializeField] private bool _hasGameStarted = false;

    public GameObject cellPrefab;
    public float cellSize = 1f;
    public Button startButton = null;


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
        if (!_hasGameStarted) return;

        int r = cell.row;
        int c = cell.column;

        if (_grid[r, c] != 0) return;

        int value = _isXTurn ? 1 : 2;
        SetCell(r, c, value);
        cell.SetValue(value == 1 ? "X" : "O");

        if(CheckWin(value))
        {
            Debug.Log((value == 1 ? "X" : "O") + " Wins!");
            _hasGameStarted = false;
        }
       
        _isXTurn = !_isXTurn;
    }

    public bool CheckWin(int value)
    {
        //row check
        for(int r = 0; r<_rows; r++)
        {
            bool win = true;
            for(int c=0; c<_cloumns; c++)
            {
                if (_grid[r,c] != value)
                {
                    win =false; break;
                }
            }

            if (win) return true; ;
        }


        //column check
        for (int c = 0; c < _cloumns; c++)
        {
            bool win = true;
            for (int r = 0; r < _rows; r++)
            {
                if (_grid[r, c] != value)
                {
                    win = false; break;
                }
            }

            if (win) return true; ;
        }

        int size = _rows == _cloumns ? _rows : 0;

        //Left to Right Diagnal check
        bool diag1 = true;
        for (int i = 0; i<size; i++)
        {
           
            if (_grid[i,i]!= value)
            {
                diag1 = false; break;
            }
        }
        if(diag1) return true;


        //Right to Left Diagnal check
        bool diag2 = true;
        for (int i = 0; i < size; i++)
        {

            if (_grid[i, size-1-i] != value)
            {
                diag2 = false; break;
            }
        }
        if (diag2) return true;

        return false;

    }

    public void OnStart()
    {
        _hasGameStarted = true;
        startButton.gameObject.SetActive(false);
    }

}
