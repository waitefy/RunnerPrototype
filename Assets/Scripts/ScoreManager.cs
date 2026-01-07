using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    
    private void Update()
    {
        scoreText.text = GetScore().ToString();
    }

    public void CheckNewHighScore()
    {
        var score = GetScore();
        var highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = $"NEW BEST: {score}";
        }
        else
        {
            highScoreText.text = $"BEST: {highScore}";
        }
    }
    
    private int GetScore()
    {
        return (int)player.transform.position.z;
    }   
}
