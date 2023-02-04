using PersonalFramework;
using UnityEngine;

public class GameState : FlowStateBase
{
    private InputSystem inputSystem;
    
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

    protected override void StartPresentingState()
    {
        inputSystem = new InputSystem();
    }

    protected override void UpdateActiveState()
    {
        float dt = Time.deltaTime;
        
        inputSystem.UpdateTouch(dt);
    }
}