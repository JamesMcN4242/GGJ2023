using PersonalFramework;
using UnityEngine;

public class PauseUI : UIStateBase
{
    [SerializeField] private TMPro.TextMeshProUGUI audioText;
    
    public void SetAudioText(string newText)
    {
        audioText.text = newText;
    }
}