using UnityEngine;

public class ResetGameLogic : MonoBehaviour
{
    [Header("Scripts Reference")]
    public GridManager gridManager;
    public GameManager gameManager;


    public void ResetGame()
    {
        for (int r = 0; r < gridManager._rows; r++)
        {
            for (int c = 0; c < gridManager._cloumns; c++)
            {
                gridManager._cells[r, c].SetCell(r, c, 0);
                gridManager._cells[r, c].SetValue("");
            }
        }
    }
}
