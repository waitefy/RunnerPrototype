using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private List<GameObject> roadPrefabs;
    [SerializeField] private Transform player;
    [SerializeField] private int initialCount = 10;
    [SerializeField] private float roadLength = 20f;
    
    private readonly List<GameObject> _segments = new List<GameObject>();

    private void Start()
    {
        for (var i = 0; i < 2; ++i)
        {
            SpawnSegment(i *  roadLength, 0, 0);
        }
        for (var i = 2; i < initialCount; ++i)
        {
            SpawnSegment(i * roadLength, -1); 
        }
    }
    
    private void Update()
    {
        if (player.position.z > _segments[0].transform.position.z + roadLength)
        {
            UpdateRoad();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void SpawnSegment(float zPosition, int prefabIndex = -1, float chance = 0.3f)
    {
        if (prefabIndex == -1)
        {
            prefabIndex = Random.Range(0, roadPrefabs.Count);
        }
        
        var newRoad = Instantiate(roadPrefabs[prefabIndex], transform);
        newRoad.transform.position = Vector3.forward * zPosition;
        
        var segmentScript = newRoad.GetComponent<RoadSegment>();
        if (segmentScript != null)
        {
            segmentScript.RandomizeObstacles(chance);
        }

        _segments.Add(newRoad);
    }

    private void UpdateRoad()
    {
        var oldSegment = _segments[0];
        _segments.RemoveAt(0);
        Destroy(oldSegment);
        
        var newZ = _segments[^1].transform.position.z + roadLength;
        SpawnSegment(newZ);
    }
}
