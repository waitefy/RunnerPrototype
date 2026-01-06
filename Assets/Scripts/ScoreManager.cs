using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject player;
    
    private void Update()
    {
        scoreText.text = ((int)player.transform.position.z).ToString();
    }
}
