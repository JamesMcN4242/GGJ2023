using PersonalFramework;
using UnityEngine;

public class GameOverUI : UIStateBase
{
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;

    public void SetScoreText(string text)
    {
        scoreText.text = text;
    }
}