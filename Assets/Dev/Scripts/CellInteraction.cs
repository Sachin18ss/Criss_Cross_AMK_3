using UnityEngine;

public class CellInteraction : MonoBehaviour
{
    [SerializeField] private SFXController sfxController;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private CellInteraction instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    public void OnCellCliked(Cell cell)
    {
        if (!GameManager._hasGameStarted) return;

        int r = cell.row;
        int c = cell.column;

        if (GridManager._grid[r, c] != 0) return;

        int value = GameManager._isXTurn ? 1 : 2;
        cell.SetCell(r, c, value);
        cell.SetValue(value == 1 ? "X" : "O");

        //OnSettingValue?.Invoke(value == 1 ? "X" : "O");
        sfxController.PlayPlaceSFX();

        if (gameManager.CheckWin(value))
        {
            Debug.Log((value == 1 ? "X" : "O") + " Wins!");

            GameManager.winner = (value == 1) ? 1 : 2;
            gameUI.currentPlayer.text = string.Empty;

            GameManager._hasGameStarted = false;
            GameManager._hasGameOver = true;

            StartCoroutine(gameManager.ShowGameOver());
        }

        GameManager._isXTurn = !GameManager._isXTurn;
    }

}
