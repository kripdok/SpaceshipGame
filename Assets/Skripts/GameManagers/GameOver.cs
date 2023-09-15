using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private DeadWindow _deadWindow;

    public void FinalizeAllProcesses(int playerPoint)
    {
        OpenLoseWindow(playerPoint);
    }

    private void OpenLoseWindow(int playerPoint)
    {
        _deadWindow.gameObject.SetActive(true);
        _deadWindow.SetScore(playerPoint);
    }
}
