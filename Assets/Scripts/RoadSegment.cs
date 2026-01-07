using System.Collections.Generic;
using UnityEngine;

public class RoadSegment : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;

    public void RandomizeObstacles(float chance)
    {
        foreach (var obstacle in obstacles)
        {
            obstacle.SetActive(false);
        }

        var activeObstacleCount = 0;
        foreach (var obstacle in obstacles)
        {
            if (activeObstacleCount < 2 && Random.value < chance)
            {
                obstacle.SetActive(true);
                
                var randomRotation = Random.Range(-45f, 45f);
                obstacle.transform.rotation = Quaternion.Euler(0, randomRotation, 0);
                
                var randomScale = Random.Range(0.9f, 1.1f);
                obstacle.transform.localScale = new Vector3(3, 1, 1) * randomScale; 
                
                ++activeObstacleCount;
            }
        }
    }
}
