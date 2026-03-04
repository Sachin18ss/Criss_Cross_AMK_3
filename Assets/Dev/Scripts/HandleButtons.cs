using UnityEngine;

public class HandleButtons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ResetGameLogic resetGameLogic;
    [SerializeField] private GameUI gameUI;
    public void OnStartClick()
    {
        GameManager._hasGameStarted = true;
        //startButton.gameObject.SetActive(false);
        gameManager.menuPanel.SetActive(false);
        gameManager.gamePanel.SetActive(true);
        gameManager.gameUIPanel.SetActive(true);

    }

    public void OnLeaveClick()
    {
        gameManager.exitPopUpPanel.SetActive(true);
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
        gameManager.exitPopUpPanel.SetActive(false);
    }

    public void OnOptionsClick()
    {
        gameManager.optionsPanel.SetActive(true);
    }

    public void OnCloseClickOnOptions()
    {
        gameManager.optionsPanel.SetActive(false);
    }

    public void OnMenuClick()
    {
        gameManager.gameOverPanel.SetActive(false);
        gameManager.gamePanel.SetActive(false);
        gameManager.gameUIPanel.SetActive(false);



        resetGameLogic.ResetGame();

        gameManager.menuPanel.SetActive(true);
    }

    public void OnRestartClick()
    {
        gameManager.gameOverPanel.SetActive(false);
        gameManager.menuPanel.SetActive(false);

        gameManager.gamePanel.SetActive(true);
        gameManager.gameUIPanel.SetActive(true);
        GameManager.winner = 0;
        gameUI.winner.text = string.Empty;

        GameManager._hasGameStarted = true;
        GameManager._hasGameOver = false;
        GameManager._isXTurn = true;

        resetGameLogic.ResetGame();

    }
}
