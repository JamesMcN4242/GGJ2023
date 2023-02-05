using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : FlowStateBase
{
    protected override bool AquireUIFromScene()
    {
        m_ui = Object.FindObjectOfType<MainMenuUI>();
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        (m_ui as MainMenuUI).SetAudioText($"Turn Audio {(AudioMasterControl.AudioMuted ? "On" : "Off")}!");
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
                (m_ui as MainMenuUI).SetAudioText($"Turn Audio {(AudioMasterControl.AudioMuted ? "On" : "Off")}!");
                break;
        }
    }
}