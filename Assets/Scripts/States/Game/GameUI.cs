using PersonalFramework;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : UIStateBase
{
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;
    
    [SerializeField]
    private Image leftBumper;

    [SerializeField]
    private Image rightBumper;

    private Camera mainCamera;
    
    protected override void OnAwake()
    {
        mainCamera = Camera.main;
    }

    public void SetScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }
    
    public void SetBumperAlphaValues(Vector3 heldItemPosition)
    {
        const float minAlpha = 0.01f;
        const float maxAlpha = 0.3f;
        
        var viewportPos = mainCamera.WorldToViewportPoint(heldItemPosition);
        SetAlphaTransparency(leftBumper, Mathf.Lerp(minAlpha, maxAlpha, 1.0f - viewportPos.x));
        SetAlphaTransparency(rightBumper, Mathf.Lerp(minAlpha, maxAlpha, viewportPos.x / 1.0f));
    }

    public void ResetBumperAlphaValues()
    {
        SetAlphaTransparency(leftBumper, 0.0f);
        SetAlphaTransparency(rightBumper, 0.0f);
    }

    private static void SetAlphaTransparency(Image image, float alphaValue)
    {
        var colour = image.color;
        colour.a = alphaValue;
        image.color = colour;
    }
}
