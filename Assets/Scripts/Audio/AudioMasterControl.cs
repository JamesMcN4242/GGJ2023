using UnityEngine;

public static class AudioMasterControl
{
    private static AudioClip wooshClip;
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

    public static void PlayWoosh()
    {
        wooshClip ??= Resources.Load<AudioClip>("Audio/swoosh");

        var source = new GameObject("WooshSource");
        var audioSource = source.AddComponent<AudioSource>();
        audioSource.clip = wooshClip;
        audioSource.time = Random.Range(0, 2) == 1 ? 6.4f : 11.8f;
        audioSource.pitch = Random.Range(0.7f, 1.9f);
        audioSource.Play();
        
        GameObject.Destroy(source, 2f);
    }
}
