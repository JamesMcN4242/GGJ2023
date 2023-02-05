using UnityEngine;

public static class AudioMasterControl
{
    public static bool AudioMuted => PlayerPrefs.GetInt("MUTE_AUDIO", 0) == 1;
    
    public static void SetMuteStatus()
    {
        AudioListener.volume = AudioMuted ? 0f : 1f;
    }
    
    public static void ToggleMute()
    {
        bool isMuted = AudioMuted;
        PlayerPrefs.SetInt("MUTE_AUDIO", isMuted ? 0 : 1);
        PlayerPrefs.Save();
        SetMuteStatus();
    }
}
