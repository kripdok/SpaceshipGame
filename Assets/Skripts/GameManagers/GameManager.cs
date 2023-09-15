using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour // Ответственности у него чето много. Может разделить его на несколько managerov?
{
    [Header("Player")]
    [SerializeField] private Player _player;
    [Space(5)]
    
    [SerializeField] private PointCounter _pointCounter;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameOver _gameOver;
    [Header("UI")]
    [SerializeField] private Menu _menu;
    
    [SerializeField] private Button _levelUpButton;    

     private Pause _pause;

    public event UnityAction ReinforceEnemies;

    private void Awake()
    {
        _pause = new Pause();
        _levelUpButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _player.IsDead += FinishTheGame;
        _pointCounter.MilestoneReached += ActivateLevelUpButton;
        _timer.MilestoneReached += RequestImproveEnemies;
        _menu.ClosingPanel += DisablePause;
        _menu.OpeningPanel += EnablePause;
    }

    private void OnDisable()
    {
        _player.IsDead -= FinishTheGame;
        _pointCounter.MilestoneReached -= ActivateLevelUpButton;
        _timer.MilestoneReached -= RequestImproveEnemies;
        _menu.ClosingPanel -= DisablePause;
        _menu.OpeningPanel -= EnablePause;
    }

    private void ActivateLevelUpButton() // выделить отдельную систему?
    {
        _player.GetComponent<PlayerSkills>().AddSkillPoint();
        _levelUpButton.gameObject.SetActive(true);
    }

    private void RequestImproveEnemies()
    {
        ReinforceEnemies.Invoke();
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