using UnityEngine;

public class MoveController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 50.0f;
    [SerializeField] private float xRange = 5.0f;
    
    [Header("Juice")]
    [SerializeField] private float tiltAngle = 30.0f; // Максимальный угол наклона
    [SerializeField] private float tiltSpeed = 10.0f; // Скорость наклона
    
    [Header("References")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ParticleSystem explosionPrefab;

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var direction = new Vector3(x, 0, 1);
        var step = speed * Time.deltaTime;
        
        transform.Translate(direction * step, Space.World);
        
        var rawPos = transform.position;
        rawPos.x = Mathf.Clamp(rawPos.x, -xRange, xRange);
        transform.position = rawPos;
        
        var targetY = x * tiltAngle;
        var targetZ = -targetY;
        var targetRotation = Quaternion.Euler(0, targetY, targetZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;
        scoreManager.CheckNewHighScore();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GetComponent<MeshRenderer>().enabled = false;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        enabled = false;
    }
}
