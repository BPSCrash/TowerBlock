using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private int _playerScore;
    private int _highScore;

    [Header("Player Score")]
    [SerializeField] int _scoreToAdd = 100;
    [SerializeField] int _perfectScoreBonus = 250;

    [Header("UI Inputs")]
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private GameObject gameOverScreen;

    bool _isGameFailable = false;
    bool _isGameOver = false;


    private class PrefKeys
    {
        public const string HIGHSCORE_KEY = "HighScore";
    }
    void Start()
    {
        if (PlayerPrefs.GetInt(PrefKeys.HIGHSCORE_KEY) != 0)
        {
            _highScore = PlayerPrefs.GetInt(PrefKeys.HIGHSCORE_KEY);
            _highScoreText.text = _highScore.ToString();
        }
        else
        {
            _highScore = PlayerPrefs.GetInt(PrefKeys.HIGHSCORE_KEY);
            _highScoreText.text = _highScore.ToString();
        }
    }

    public void SetGameFailable()
    {
        _isGameFailable = true;
    }

    public bool GetGameFailable()
    {
        return _isGameFailable;
    }

    public void AddScore(bool isPerfect)
    {
        int scoreToAdd = isPerfect ? _perfectScoreBonus : _scoreToAdd;

        if (!_isGameOver)
        {
            _playerScore = _playerScore + scoreToAdd;
            _scoreText.text = _playerScore.ToString();
        }
    }

    public void RestartGame()
    {
        _isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        if (_isGameFailable)
        {
            if (_playerScore > _highScore)
            {
                _highScore = _playerScore;
                PlayerPrefs.SetInt(PrefKeys.HIGHSCORE_KEY, _highScore);
            }
            _isGameOver = true;
            gameOverScreen.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    //CONTEXTMENU TEST FUNCITONS
    [ContextMenu("Increase Score")]
    private void AddScore()
    {
        AddScore(false);
    }

    [ContextMenu("Increase Score For Perfect")]
    private void AddScorePerfect()
    {
        AddScore(true);
    }

}
