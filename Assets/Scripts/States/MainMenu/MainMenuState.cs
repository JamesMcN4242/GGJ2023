using PersonalFramework;
using UnityEngine;

public class MainMenuState : FlowStateBase
{
    protected override bool AquireUIFromScene()
    {
        m_ui = Object.FindObjectOfType<MainMenuUI>();
        return m_ui != null;
    }

    protected override void HandleMessage(object message)
    {
        if (message is string str && str == "Play")
        {
            // Start a new scene.
            Debug.Log("The play button was pressed");
        }
    }
}