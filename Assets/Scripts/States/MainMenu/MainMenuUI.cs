using PersonalFramework;
using UnityEngine;

public class MainMenuUI : UIStateBase
{
    [SerializeField] private TMPro.TextMeshProUGUI audioText;
    
    public void SetAudioText(string newText)
    {
        audioText.text = newText;
    }
}