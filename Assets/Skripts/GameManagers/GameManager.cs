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
    [SerializeField] private PointCounter _pointCounter;
    [Header("UI")]
    [SerializeField] private TimerUI _timerUI;
    [SerializeField] private PlayerHealthCounterUI _playerHealthCounterUI;
    [SerializeField] private Menu _menu;
    [SerializeField] private DeadWindow _deadWindow;
    [SerializeField] private Button _levelUpButton;
    [Space(5)]
    [Header("Target")]
    [Tooltip("Time is measured in seconds")]
    [SerializeField] private float _timeTarget;

    private Timer _timer;
    

    public event UnityAction GameIsOver;
    public event UnityAction ReinforceEnemies;

    private void Awake()
    {
        _timer = new Timer(_timerUI, _timeTarget);
        _levelUpButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
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

    private void OnDisable() // все Системы могут напрямую обращаться к своим UI. GameManager является лишней прослойкой.
    {
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

    private void EnablePause() // сделать отдельный класс который отвечает за остановку время
    {
        Time.timeScale = 0;
    }

    private void DisablePause()//
    {
        Time.timeScale = 1f;
    }


    private void ChangePleyarHealtUI(int number)
    {
        _playerHealthCounterUI.ChangeValue(number);
    }


    // Надо сделать отдельный крипт, который отвечает за отключение всех систем, при смерте персонажа. И тот скрипт вызывает финальное окно
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