using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : FlowStateBase
{
    private int scoreReached;

    public GameOverState(int score)
    {
        scoreReached = score;
    }
    
    protected override bool AquireUIFromScene()
    {
        m_ui = Object.FindObjectOfType<GameOverUI>();
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        int highScore = PlayerPrefs.GetInt("HIGH_SCORE", 0);
        if (scoreReached > highScore)
        {
            PlayerPrefs.SetInt("HIGH_SCORE", scoreReached);
            PlayerPrefs.Save();
            
            (m_ui as GameOverUI).SetScoreText($"New High Score: {scoreReached}");
        }
        else if (scoreReached == highScore)
        {
            (m_ui as GameOverUI).SetScoreText($"Matched Previous High Score: {scoreReached}");
        }
        else
        {
            (m_ui as GameOverUI).SetScoreText($"Score: {scoreReached}. \nHigh Score: {highScore}");
        }
    }

    protected override void HandleMessage(object message)
    {
        switch (message)
        {
            case "Replay": 
                SceneManager.LoadScene("GameScene");
                break;
            
            case "Quit":
                SceneManager.LoadScene("MainMenuScene");
                break;
        }
    }
}