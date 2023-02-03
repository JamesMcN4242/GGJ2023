using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : FlowStateBase
{
    protected override bool AquireUIFromScene()
    {
        m_ui = Object.FindObjectOfType<PauseUI>();
        return m_ui != null;
    }

    protected override void HandleMessage(object message)
    {
        switch (message)
        {
            case "Play": 
                ControllingStateStack.PopState();
                break;
            
            case "Quit":
                SceneManager.LoadScene("MainMenuScene");
                break;
        }
    }
}