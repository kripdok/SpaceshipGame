using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButton : MenuButton
{ 
    protected override void ClickOnButton()
    {
        SceneManager.LoadScene(1); // волшеное число
    }
}
