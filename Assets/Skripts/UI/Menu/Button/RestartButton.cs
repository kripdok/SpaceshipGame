using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MenuButton
{
    protected override void ClickOnButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}