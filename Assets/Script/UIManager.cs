using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
        _scoreSO.OnLaunchEvent += UpdateScore;
    }
    void OnDisable()
    {
        _gameOver.OnLaunchEvent -= GameOver;
        _scoreSO.OnLaunchEvent -= UpdateScore;
    }
    private void Awake()
    {
        _gameOverUI.SetActive(false);
        _scoreSO._score = 0;
        UpdateScore();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        _gameOverUI.SetActive(true);
    }
    void UpdateScore()
    {
        _score.text = _scoreSO._score.ToString() + " points";
    }
}
