using System.Collections;
using TMPro;
using Unity.Multiplayer.PlayMode;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _rows = 3, _cloumns = 3;
    [SerializeField] private int[,] _grid;
    [SerializeField] private int _winner;

    [SerializeField] private bool _isXTurn = true;
    [SerializeField] private bool _hasGameStarted = false;
    [SerializeField] private bool _hasGameOver = false;

    public GameObject cellPrefab;
    public Transform cellsHolder;
    public float cellSize = 1f;
    public Button startButton = null;

    [Header("Main Panels")]
    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;

    [Header("Sub Panels")]
    public GameObject exitPopUpPanel;
    public GameObject optionsPanel;
    public GameObject gameUIPanel;

    [Header("Texts Reference")]
    public TextMeshProUGUI currentPlayer;
    public TextMeshProUGUI winner;

    [Header("Image Reference")]
    public Image gameOverBG;

    private void Awake()
    {
        _grid = new int[_rows, _cloumns];
    }

    private void Start()
    {
        menuPanel.SetActive(true);

        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameUIPanel.SetActive(false);
        exitPopUpPanel.SetActive(false);
        optionsPanel.SetActive(false);
        winner.text = string.Empty;

        DrawGrids();
        _winner = 0;
    }

    private void Update()
    { 
        
        UIUpdate();

    }

    public void UIUpdate()
    {
        
        if(_winner == 1)
        {
            SetBGImageColor("#25A364");
            winner.text = "You Won this Game!";
        }
        else if(_winner == 2)
        {
            SetBGImageColor("#A32525");
            winner.text = "Opponent Won this Game!";
        }
        
        if (_hasGameOver) return;
        currentPlayer.text = (_isXTurn) ? "Your move now.." : $"Opponent move now..";

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

                GameObject cell = Instantiate(cellPrefab, worldPos, Quaternion.identity, cellsHolder);
                
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

            _winner = (value == 1) ? 1 : 2;
            currentPlayer.text = string.Empty;

            _hasGameStarted = false;
            _hasGameOver = true;

            StartCoroutine(ShowGameOver());
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

    public void OnStartClick()
    {
        _hasGameStarted = true;
        //startButton.gameObject.SetActive(false);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameUIPanel.SetActive(true);

    }

    public void OnLeaveClick()
    {
        exitPopUpPanel.SetActive(true);
    }

    public void OnYesClickOnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void OnNoClickOnExit()
    {
        exitPopUpPanel.SetActive(false);
    }

    public void OnOptionsClick()
    {
        optionsPanel.SetActive(true);
    }

    public void OnCloseClickOnOptions()
    {
        optionsPanel.SetActive(false);
    }

    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(2f);

        gameOverPanel.SetActive(true);  
    }

    public void Menu()
    {
        gameOverPanel.SetActive(false);
        gamePanel.SetActive(false );

        menuPanel.SetActive(true);
    }

    public void Restart()
    {
        gameOverPanel.SetActive(false);
        menuPanel.SetActive(false);

        gamePanel.SetActive(true);
        _winner = 0;
        winner.text = string.Empty;
        
    }

    public void SetBGImageColor(string hexColor)
    {
        Color newColor;
        // TryParseHtmlString handles both 6-digit (RGB) and 8-digit (RGBA) hex strings, 
        // with or without a '#' prefix.
        if (ColorUtility.TryParseHtmlString(hexColor, out newColor))
        {
            // Assign the successfully parsed color to the Image component
            gameOverBG.color = newColor;
        }
        else
        {
            Debug.LogError("Invalid hex color string provided: " + hexColor);
        }
    }
}
