using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Texts Reference")]
    public TextMeshProUGUI currentPlayer;
    public TextMeshProUGUI winner;

    [Header("Image Reference")]
    public Image gameOverBG;

    public Button startButton = null;

    private void Start()
    {
        winner.text = string.Empty;
    }

    private void Update()
    {
        UIUpdate();
    }
    public void UIUpdate()
    {

        if (GameManager.winner == 1)
        {
            SetBGImageColor("#25A364");
            winner.text = "You Won this Game!";
        }
        else if (GameManager.winner == 2)
        {
            SetBGImageColor("#A32525");
            winner.text = "Opponent Won this Game!";
        }

        if (GameManager._hasGameOver) return;

        currentPlayer.text = (GameManager._isXTurn) ? "Your move now.." : $"Opponent move now..";

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
