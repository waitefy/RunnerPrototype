using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int _score;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.SetText("Score: {0}", _score);
        }
    }

    public void CheckNewHighScore()
    {
        var highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        if (_score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _score);
            highScoreText.SetText("NEW BEST: {0}", _score);
        }
        else
        {
            highScoreText.SetText("BEST: {0}", highScore);
        }
    }
}
