using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialState : FlowStateBase
{
    private string[] tutorialTexts = new[]
    {
        "Ready, set, start gardening!\n\nHooray, there are many plants in your vegetable patch ready to be picked, but some weeds seem to have found their way in as well. Pick up the plants and sort them.",
        "Vegetables (carrots and beetroots) belong to the right, while daisies and dandelions must go to the left.",
        "You have 10 lives (displayed above), which are lost as you miss plants or sort them to the wrong side.\n\nGood luck!"
    };

    private Sprite[] tutorialImages;
    private TutorialUI tutorialUI;
    private int tutorialIndex;

    protected override bool AquireUIFromScene()
    {
        m_ui = tutorialUI = Object.FindObjectOfType<TutorialUI>();
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        tutorialImages = new[]
        {
            Resources.Load<Sprite>("Art/Tutorial/ImageOne"),
            Resources.Load<Sprite>("Art/Tutorial/ImageTwo"),
            Resources.Load<Sprite>("Art/Tutorial/ImageThree"),
        };
        
        tutorialUI.SetImage(tutorialImages[tutorialIndex]);
        tutorialUI.SetText(tutorialTexts[tutorialIndex]);
    }

    protected override void HandleMessage(object message)
    {
        string str = message as string;
        switch (str)
        {
            case "next":
            {
                ++tutorialIndex;
                if (tutorialIndex >= tutorialImages.Length)
                {
                    SceneManager.LoadScene("MainMenuScene");
                }
                else
                {
                    tutorialUI.SetImage(tutorialImages[tutorialIndex]);
                    tutorialUI.SetText(tutorialTexts[tutorialIndex]);
                }

                break;
            }
            case "back":  
                tutorialIndex = Mathf.Max(0, --tutorialIndex);
                tutorialUI.SetImage(tutorialImages[tutorialIndex]);
                tutorialUI.SetText(tutorialTexts[tutorialIndex]);
                break;
        }
    }
}
