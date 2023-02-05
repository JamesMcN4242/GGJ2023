using UnityEngine;

public static class BackingMusicCreator
{
    [RuntimeInitializeOnLoadMethod]
    private static void CreateMusicObj()
    {
        var audioObj = new GameObject("BackingMusic");
        var source = audioObj.AddComponent<AudioSource>();
        source.clip = Resources.Load<AudioClip>("Audio/Music");
        source.volume = 0.8f;
        source.loop = true;
        source.Play();
        
        GameObject.DontDestroyOnLoad(audioObj);
        AudioMasterControl.SetMuteStatus();
    }
}
