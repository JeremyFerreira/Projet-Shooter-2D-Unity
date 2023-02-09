using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] EventSO _gameOver;
    [SerializeField] GameObject _gameOverUI;
    [SerializeField] TextMeshProUGUI _score;
    [SerializeField] Score _scoreSO;
    // Start is called before the first frame update
    void OnEnable()
    {
        _gameOver.OnLaunchEvent += GameOver;
        _scoreSO.OnValueChangedEvent += UpdateScore;
    }
    void OnDisable()
    {
        _gameOver.OnLaunchEvent -= GameOver;
        _scoreSO.OnValueChangedEvent -= UpdateScore;
    }
    private void Awake()
    {
        _gameOverUI.SetActive(false);
        _scoreSO._score = 0;
        UpdateScore(0);
    }
    void GameOver()
    {
        Time.timeScale = 0f;
        _gameOverUI.SetActive(true);
    }
    void UpdateScore(int value)
    {
        _score.text = value + " points";
    }
    public void Reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
