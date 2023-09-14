using UnityEngine;

public class ExitButton : MenuButton
{
    protected override void ClickOnButton()
    {
        Application.Quit();
    }
}
