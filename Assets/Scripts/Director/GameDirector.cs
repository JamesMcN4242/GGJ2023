using PersonalFramework;

public sealed class GameDirector : LocalDirector
{
    public void Awake()
    {
        m_stateController.PushState(new GameState());
    }
}