using UnityEngine;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    public event UnityAction ClosingPanel;
    public event UnityAction OpeningPanel;

    public void ClosePanel(Panel panel)
    {
        panel.gameObject.SetActive(false);
        ClosingPanel?.Invoke();
    }

    public void OpenPanel(Panel panel)
    {
        panel.gameObject.SetActive(true);
        OpeningPanel?.Invoke();
    }
}