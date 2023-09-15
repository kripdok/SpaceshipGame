using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour // ��������������� � ���� ���� �����. ����� ��������� ��� �� ��������� managerov?
{
    [Header("Player")]
    [SerializeField] private Player _player;
    [SerializeField] private PlayerHealthSystem _playerHealthSystem;
    [Space(5)]
    [SerializeField] private PlayerHealthCounterUI _playerHealthCounterUI;
    [SerializeField] private PointCounter _pointCounter;
    [SerializeField] private Timer _timer;
    [SerializeField] private Pause _pause;
    [SerializeField] private GameOver _gameOver;
    [Header("UI")]
    [SerializeField] private Menu _menu;
    
    [SerializeField] private Button _levelUpButton;    

    public event UnityAction ReinforceEnemies;

    private void Awake()
    {
        _levelUpButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _player.DeadIsPlayed += FinishTheGame;
        _playerHealthSystem.ChangeValue += ChangePleyarHealtUI;
        _pointCounter.MilestoneReached += ActivateLevelUpButton;
        _timer.MilestoneReached += RequestImproveEnemies;
        _menu.ClosingPanel += DisablePause;
        _menu.OpeningPanel += EnablePause;
    }

    private void OnDisable() // ��� ������� ����� �������� ���������� � ����� UI. GameManager �������� ������ ����������.
    {
        _player.DeadIsPlayed -= FinishTheGame;
        _playerHealthSystem.ChangeValue -= ChangePleyarHealtUI;
        _pointCounter.MilestoneReached -= ActivateLevelUpButton;
        _timer.MilestoneReached -= RequestImproveEnemies;
        _menu.ClosingPanel -= DisablePause;
        _menu.OpeningPanel -= EnablePause;
    }

    private void ActivateLevelUpButton() // �������� ��������� �������?
    {
        _player.GetComponent<PlayerSkills>().AddSkillPoint();
        _levelUpButton.gameObject.SetActive(true);
    }

    private void RequestImproveEnemies()
    {
        ReinforceEnemies.Invoke();
    }

    private void ChangePleyarHealtUI(int number) // ��������� � ������� ������?
    {
        _playerHealthCounterUI.ChangeValue(number);
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