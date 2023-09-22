using UnityEngine.SceneManagement;

public class StartButton : MenuButton
{
    private int GameScene = 1;

    protected override void ClickOnButton()
    {
        SceneManager.LoadScene(GameScene);
    }
}