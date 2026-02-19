using UnityEngine;
using TMPro;
public class Cell : MonoBehaviour
{
    public int row;
    public int column;

    [SerializeField] private TextMeshPro _cellText;
    [Header("Scripts Reference")]
    private GridManager gridManager;

    private void Start()
    {
        gridManager = FindFirstObjectByType<GridManager>();
        _cellText = GetComponentInChildren<TextMeshPro>(); ;
    }
    
    public void SetValue(string value)
    {
        _cellText.color = value == "O" ? Color.blue : Color.red;
        _cellText.text = value;
    }

    void OnMouseDown()
    {
        if (gridManager.IsCellEmpty(row, column))
        {
            gridManager.OnCellCliked(this);
            //gridManager.SetCell(row, column, 1);
            //Debug.Log($"Clicked {row},{column}");
        }
        
    }
}
