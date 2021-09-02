using Core;
using UnityEngine;
using UnityEngine.UI;
using Animations;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _taskFindText;
    [SerializeField] private Image _background;
    [SerializeField] private RestartScene _restartSceneButton;
    
    [SerializeField] private CardSpawner _cardSpawner;
    [SerializeField] private LevelSwitch _levelSwitch;
    [SerializeField] private Field _field;
    private readonly string _findText = "find ";

    private void Awake()
    {
        _cardSpawner.OnIdToFindChanged += UpdateTextFind;
        _levelSwitch.OnMaxLevelReached += EndGame;
    }

    private void UpdateTextFind(string text)
    {
        _taskFindText.text = _findText + text;
        _taskFindText.PlayFide(0f,0f);
        _taskFindText.PlayFide(1f,1f);
    }

    private void EndGame()
    {
        _field.gameObject.SetActive(false);
        _restartSceneButton.gameObject.SetActive(true);
        _background.gameObject.SetActive(true);
        _background.PlayFide(0.6f, 1f);
    }
    
}