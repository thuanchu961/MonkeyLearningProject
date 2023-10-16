using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupSetting : PopupBase
{
    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
    public void CloseButton()
    {
        Hide();
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void ResumeButton()
    {
        Hide();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
