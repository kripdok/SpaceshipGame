using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private DeadWindow _deadWindow;
    [SerializeField] private BackgroundMusic _music;

    public void FinalizeAllProcesses(int playerPoint)
    {
        OpenLoseWindow(playerPoint);
        _music.PlayTheStopMusicClip();
    }

    private void OpenLoseWindow(int playerPoint)
    {
        _deadWindow.gameObject.SetActive(true);
        _deadWindow.SetScore(playerPoint);
    }
}
