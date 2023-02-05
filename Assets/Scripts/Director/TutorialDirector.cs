using PersonalFramework;

public sealed class TutorialDirector : LocalDirector
{
    public void Awake()
    {
        m_stateController.PushState(new TutorialState());
    }
}