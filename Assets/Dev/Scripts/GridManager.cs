using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 3, cloumns = 3;
    private int[,] grid;

    public GameObject cellPrefab;
    public float cellSize = 1f;

    private void Awake()
    {
        grid = new int[rows, cloumns];
    }

    private void Start()
    {
        DrawGrids();
    }

    public bool IsCellEmpty(int r, int c)
    {
        return grid[r, c] == 0;
    }

    public void SetValue(int r, int c, int value)
    {
        grid[r, c] = value;
    }

    public void DrawGrids()
    {
        for(int r = 0; r<rows; r++)
        {
            for (int c = 0; c < cloumns; c++)
            {
                Vector2 worldPos = new Vector2(r * cellSize, c * cellSize);

                GameObject cell = Instantiate(cellPrefab, worldPos, Quaternion.identity);
                cell.name = $"cell_{r}_{c}";
            }
        }
    }
}
