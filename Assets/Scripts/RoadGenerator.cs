using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private Transform player;
    
    [SerializeField] private int initialCount = 10;
    [SerializeField] private float roadLength = 20f;
    
    private readonly List<GameObject> _segments = new List<GameObject>();

    private void Start()
    {
        for (var i = 0; i < initialCount; ++i)
        {
            var newRoad = Instantiate(roadPrefab);
            newRoad.transform.position = new Vector3(0, 0, i * roadLength);
            _segments.Add(newRoad);
        }
    }

    private void Update()
    {
        if (player.position.z > _segments[0].transform.position.z + roadLength)
        {
            MoveSegment();
        }
    }

    private void MoveSegment()
    {
        var movingSegment = _segments[0];
        
        var lastPosition = _segments[^1].transform.position;
        movingSegment.transform.position = lastPosition + Vector3.forward * roadLength;
        
        _segments.RemoveAt(0);
        _segments.Add(movingSegment);
    }
}