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
    [SerializeField] private PointCounter _pointCounter;
    [SerializeField] private Timer _timer;
    [Header("UI")]
    [SerializeField] private PlayerHealthCounterUI _playerHealthCounterUI;
    [SerializeField] private Menu _menu;
    [SerializeField] private DeadWindow _deadWindow;
    [SerializeField] private Button _levelUpButton;    

    public event UnityAction GameIsOver;
    public event UnityAction ReinforceEnemies;

    private void Awake()
    {
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

    private void OnDisable() // ��� ������� ����� �������� ���������� � ����� UI. GameManager �������� ������ ����������.
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

    private void EnablePause() // ������� ��������� ����� ������� �������� �� ��������� �����
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


    // ���� ������� ��������� �����, ������� �������� �� ���������� ���� ������, ��� ������ ���������. � ��� ������ �������� ��������� ����
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