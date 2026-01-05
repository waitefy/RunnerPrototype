using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float xRange = 5.0f;

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        
        var direction = new Vector3(x, 0, z);
        var step = speed * Time.deltaTime;
        
        transform.Translate(direction * step);
        
        var rawPos = transform.position;
        rawPos.x = Mathf.Clamp(rawPos.x, -xRange, xRange);
        transform.position = rawPos;
    }
}
