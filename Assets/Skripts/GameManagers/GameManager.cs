using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour // Ответственности у него чето много. Может разделить его на несколько managerov?
{
    [Header("Player")]
    [SerializeField] private Player _player;
    [Space(5)]
    
    [SerializeField] private PointCounter _pointCounter;
    [SerializeField] private GameOver _gameOver;
    [Header("UI")]
    [SerializeField] private Menu _menu;
   

     private Pause _pause;

    private void Awake()
    {
        _pause = new Pause();
    }

    private void OnEnable()
    {
        _player.IsDead += FinishTheGame;
        _menu.ClosingPanel += DisablePause;
        _menu.OpeningPanel += EnablePause;
    }

    private void OnDisable()
    {
        _player.IsDead -= FinishTheGame;
        _menu.ClosingPanel -= DisablePause;
        _menu.OpeningPanel -= EnablePause;
    }

    private void EnablePause()
    {
        _pause.StopGameTime();
    }

    private void DisablePause()
    {
        _pause.StartGameTime();
    }

    private void FinishTheGame()
    {
        EnablePause();
        _gameOver.FinalizeAllProcesses(_pointCounter.CorrectPoint);
    }
}