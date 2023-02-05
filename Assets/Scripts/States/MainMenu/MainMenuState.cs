﻿using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : FlowStateBase
{
    protected override bool AquireUIFromScene()
    {
        m_ui = Object.FindObjectOfType<MainMenuUI>();
        return m_ui != null;
    }

    protected override void HandleMessage(object message)
    {
        if (message is string str && str == "Play")
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (message is string str2 && str2 == "Tutorial")
        {
            SceneManager.LoadScene("TutorialScene");
        }
    }
}