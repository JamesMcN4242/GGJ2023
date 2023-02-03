using PersonalFramework;
using UnityEngine;

public class GameState : FlowStateBase
{
    protected override bool AquireUIFromScene()
    {
        m_ui = Object.FindObjectOfType<GameUI>();
        return m_ui != null;
    }

    protected override void HandleMessage(object message)
    {
        if (message is string str && str == "Pause")
        {
            ControllingStateStack.PushState(new PauseState());
        }
    }
}