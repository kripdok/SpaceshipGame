using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class MenuButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickOnButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickOnButton);
    }

    protected abstract void ClickOnButton();
}