using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : FlowStateBase
{
    private MainMenuUI mainMenuUI;
    
    protected override bool AquireUIFromScene()
    {
        m_ui = mainMenuUI = Object.FindObjectOfType<MainMenuUI>();
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        mainMenuUI.SetAudioText($"Turn Audio {(AudioMasterControl.AudioMuted ? "On" : "Off")}!");
    }

    protected override void HandleMessage(object message)
    {
        string str = message as string;
        switch (str)
        {
            case "Play":
                SceneManager.LoadScene("GameScene");
                break;
            case "Tutorial":
                SceneManager.LoadScene("TutorialScene");
                break;
            case "ToggleAudio":
                AudioMasterControl.ToggleMute();
                mainMenuUI.SetAudioText($"Turn Audio {(AudioMasterControl.AudioMuted ? "On" : "Off")}!");
                break;
        }
    }
}