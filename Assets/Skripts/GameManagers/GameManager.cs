using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour // Ответственности у него чето много. Может разделить его на несколько managerov?
{
    [Header("Player")]
    [SerializeField] private Player _player;
    [SerializeField] private PlayerHealthSystem _playerHealthSystem;
    [Space(5)]
    [Header("UI")]
    [SerializeField] private PointCounterUI _pointCounterUI;
    [SerializeField] private TimerUI _timerUI;
    [SerializeField] private PlayerHealthCounterUI _playerHealthCounterUI;
    [SerializeField] private Menu _menu;
    [SerializeField] private DeadWindow _deadWindow;
    [SerializeField] private Button _levelUpButton;
    [Space(5)]
    [Header("Target")]
    [Tooltip("Time is measured in seconds")]
    [SerializeField] private float _timeTarget;
    [SerializeField] private int _pointsTarget;

    private Timer _timer;
    private PointCounter _pointCounter;

    public event UnityAction GameIsOver;
    public event UnityAction ReinforceEnemies;

    private void Awake()
    {
        _timer = new Timer(_timerUI, _timeTarget);
        _pointCounter = new PointCounter(_pointCounterUI, _pointsTarget);
        _levelUpButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Enemy.PassPoint += AddPoints;
        _playerHealthSystem.Died += FinishTheGame;
        _playerHealthSystem.ChangeValue += ChangePleyarHealtUI;
        _pointCounter.MilestoneReached += ActivateLevelUpButton;
        _timer.MilestoneReached += RequestImproveEnemies;
        _menu.ClosingPanel += DisablePause;
        _menu.OpeningPanel += EnablePause;
    }

    private void Update()
    {
        _timer.Update();
    }

    private void OnDisable()
    {
        Enemy.PassPoint -= AddPoints;
        _playerHealthSystem.Died -= FinishTheGame;
        _playerHealthSystem.ChangeValue -= ChangePleyarHealtUI;
        _pointCounter.MilestoneReached -= ActivateLevelUpButton;
        _timer.MilestoneReached -= RequestImproveEnemies;
        _menu.ClosingPanel -= DisablePause;
        _menu.OpeningPanel -= EnablePause;
    }

    private void ActivateLevelUpButton()
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
        Time.timeScale = 0;
    }

    private void DisablePause()
    {
        Time.timeScale = 1f;
    }

    private void AddPoints(int point)
    {
        _pointCounter.AddPoints(point);
    }

    private void ChangePleyarHealtUI(int number)
    {
        _playerHealthCounterUI.ChangeValue(number);
    }

    private void FinishTheGame()
    {
        StartCoroutine(Waiting());
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2f);

        EnablePause();
        GameIsOver?.Invoke();
        _deadWindow.gameObject.SetActive(true);
        _deadWindow.SetScore(_pointCounter.CorrectPoint);
    }
}