using UnityEngine;

public class TimeControlSystem : MonoBehaviour
{
    [SerializeField] private PlayerDeathSystem _deathSystem;
    [SerializeField] private PointCounter _pointCounter;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private Menu _menu;
   
     private Pause _pause;

    private void Awake()
    {
        _pause = new Pause();
    }

    private void OnEnable()
    {
        _deathSystem.IsDead += FinishTheGame;
        _menu.ClosingPanel += DisablePause;
        _menu.OpeningPanel += EnablePause;
    }

    private void OnDisable()
    {
        _deathSystem.IsDead -= FinishTheGame;
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