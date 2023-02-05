using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : FlowStateBase
{
    private PauseUI pauseUI;
    
    protected override bool AquireUIFromScene()
    {
        m_ui = pauseUI = Object.FindObjectOfType<PauseUI>();
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        pauseUI.SetAudioText($"Turn Audio {(AudioMasterControl.AudioMuted ? "On" : "Off")}!");
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
            
            case "ToggleAudio":
                AudioMasterControl.ToggleMute();
                pauseUI.SetAudioText($"Turn Audio {(AudioMasterControl.AudioMuted ? "On" : "Off")}!");
                break;
        }
    }
}