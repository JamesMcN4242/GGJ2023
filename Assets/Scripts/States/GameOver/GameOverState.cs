using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : FlowStateBase
{
    protected override bool AquireUIFromScene()
    {
        m_ui = Object.FindObjectOfType<GameOverUI>();
        return m_ui != null;
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