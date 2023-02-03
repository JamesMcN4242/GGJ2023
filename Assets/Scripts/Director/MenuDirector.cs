using PersonalFramework;

namespace Director
{
    public sealed class MenuDirector : LocalDirector
    {
        public void Awake()
        {
            m_stateController.PushState(new MainMenuState());
        }
    }
}