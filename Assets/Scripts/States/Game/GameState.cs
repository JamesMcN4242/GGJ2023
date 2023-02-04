using PersonalFramework;
using UnityEngine;

public class GameState : FlowStateBase
{
    private GameUI gameUI;
    private InputSystem inputSystem;
    private GroundSystem groundSystem;
    private HealthState health = new ();
    private ScoreSystem score = new();
    private CollectionCollider[] colliders;

    protected override bool AquireUIFromScene()
    {
        m_ui = gameUI = Object.FindObjectOfType<GameUI>();
        return m_ui != null;
    }

    protected override void HandleMessage(object message)
    {
        if (message is string and "Pause")
        {
            ControllingStateStack.PushState(new PauseState());
        }
    }

    protected override void StartPresentingState()
    {
        inputSystem = new InputSystem(gameUI);
        groundSystem = new GroundSystem();
        colliders = Object.FindObjectsOfType<CollectionCollider>();
    }

    protected override void UpdateActiveState()
    {
        float dt = Time.deltaTime;
        
        inputSystem.UpdateTouch(dt);
        groundSystem.UpdateMovement(dt);
        
        if (health.Lives <= 0)
        {
            ControllingStateStack.PushState(new GameOverState());
        }
    }

    protected override void FixedUpdateActiveState()
    {
        foreach (var collectionCollider in colliders)
        {
            var hit = collectionCollider.ConsumeObjs();
            score.UpdateScore(hit.correct);
            health.UpdateHealth(hit.wrong);
        }
        
        gameUI.SetScore(score.Score);
    }
}