using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float xRange = 5.0f;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private ScoreManager scoreManager;

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var direction = new Vector3(x, 0, 1);
        var step = speed * Time.deltaTime;
        
        transform.Translate(direction * step);
        
        var rawPos = transform.position;
        rawPos.x = Mathf.Clamp(rawPos.x, -xRange, xRange);
        transform.position = rawPos;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;

        scoreManager.CheckNewHighScore();
        
        gameOverPanel.SetActive(true);
        
        Time.timeScale = 0; 
        
        enabled = false;
    }
}
