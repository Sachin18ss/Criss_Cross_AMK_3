using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
public class GameManager : MonoBehaviour
{
    [Header("Main Panels")]
    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;

    [Header("Sub Panels")]
    public GameObject exitPopUpPanel;
    public GameObject optionsPanel;
    public GameObject gameUIPanel;

    public static bool _isXTurn = true;
    public static bool _hasGameStarted = false;
    public static bool _hasGameOver = false;

    public static int winner;

    public GridManager gridManager;
    private void Start()
    {
        menuPanel.SetActive(true);

        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameUIPanel.SetActive(false);
        exitPopUpPanel.SetActive(false);
        optionsPanel.SetActive(false);

        winner = 0;
    }

    public bool CheckWin(int value)
    {
        //row check
        for (int r = 0; r < gridManager._rows; r++)
        {
            bool win = true;
            for (int c = 0; c < gridManager._cloumns; c++)
            {
                if (GridManager._grid[r, c] != value)
                {
                    win = false; break;
                }
            }

            if (win) return true; ;
        }


        //column check
        for (int c = 0; c < gridManager._cloumns; c++)
        {
            bool win = true;
            for (int r = 0; r < gridManager._rows; r++)
            {
                if (GridManager._grid[r, c] != value)
                {
                    win = false; break;
                }
            }

            if (win) return true; ;
        }

        int size = gridManager._rows == gridManager._cloumns ? gridManager._rows : 0;

        //Left to Right Diagnal check
        bool diag1 = true;
        for (int i = 0; i < size; i++)
        {

            if (GridManager._grid[i, i] != value)
            {
                diag1 = false; break;
            }
        }
        if (diag1) return true;


        //Right to Left Diagnal check
        bool diag2 = true;
        for (int i = 0; i < size; i++)
        {

            if (GridManager._grid[i, size - 1 - i] != value)
            {
                diag2 = false; break;
            }
        }
        if (diag2) return true;

        return false;

    }

    public IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(2f);

        gameOverPanel.SetActive(true);
    }
}
