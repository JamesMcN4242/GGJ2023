using PersonalFramework;
using UnityEngine;

public class GameState : FlowStateBase
{
    private InputSystem inputSystem;
    private GroundSystem groundSystem;
    private HealthState health = new HealthState();

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
        groundSystem = new GroundSystem();
    }

    protected override void UpdateActiveState()
    {
        float dt = Time.deltaTime;
        
        inputSystem.UpdateTouch(dt);
        groundSystem.UpdateMovement(dt);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Remove health here");
            health.updateHealth();
        }
        if (health.lives <= 0)
        {
            //navigate to Game Over screen
        }
    }
}