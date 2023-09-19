using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private LevelUpWindow _window;
    [SerializeField] private PlayerSkills _playerSkills;
    [SerializeField] private PointCounter _pointCounter;
    [SerializeField] private Button _menuActivateButton;

    private int _point;

    private void Awake()
    {
        _point = 0;
    }

    private void OnEnable()
    {
        _pointCounter.MilestoneReached += ActivateButton;
        _playerSkills.PointHasBeenChanged += AddPoints;
        _menuActivateButton.onClick.AddListener(UpdateCountPointInWindow);
    }

    private void OnDisable()
    {
        _pointCounter.MilestoneReached -= ActivateButton;
        _playerSkills.PointHasBeenChanged -= AddPoints;
        _menuActivateButton.onClick.RemoveListener(UpdateCountPointInWindow);
    }

    private void ActivateButton()
    {
        _menuActivateButton.gameObject.SetActive(true);
    }

    private void AddPoints(int number)
    {
        _point = number;
        UpdateCountPointInWindow();
        TryEnableButton();
    }

    private void UpdateCountPointInWindow()
    {
        _window.DisplayPointsOnWindow(_point);
        _window.TryTurnOffAllAbilityIcon(_point);
    } 

    private void TryEnableButton()
    {
        if(_point == 0)
        {
            _menuActivateButton.gameObject.SetActive(false);
        }
    }
}