using UnityEngine;

public class ResetGameLogic : MonoBehaviour
{
    [Header("Scripts Reference")]
    public GridManager gridManager;


    public void ResetGame()
    {
        for (int r = 0; r < gridManager._rows; r++)
        {
            for (int c = 0; c < gridManager._cloumns; c++)
            {
                gridManager.SetCell(r, c, 0);
                gridManager._cells[r, c].SetValue("");
            }
        }
    }
}
