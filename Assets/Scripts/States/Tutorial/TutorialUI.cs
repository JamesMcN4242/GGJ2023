using PersonalFramework;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : UIStateBase
{
    [SerializeField] private Image tutorialImage;
    [SerializeField] private TMPro.TextMeshProUGUI tutorialText;

    public void SetImage(Sprite image)
    {
        tutorialImage.sprite = image;
    }

    public void SetText(string text)
    {
        tutorialText.text = text;
    }
}
