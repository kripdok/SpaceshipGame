using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    [SerializeField] private DeadWindow _deadWindow;
    [SerializeField] private BackgroundMusic _music;

    public event UnityAction GameFinished;

    public void FinalizeAllProcesses(int playerPoint)
    {
        OpenLoseWindow(playerPoint);
        _music.PlayTheStopMusicClip();
        GameFinished?.Invoke();
    }

    private void OpenLoseWindow(int playerPoint)
    {
        _deadWindow.gameObject.SetActive(true);
        _deadWindow.SetScore(playerPoint);
    }
}
