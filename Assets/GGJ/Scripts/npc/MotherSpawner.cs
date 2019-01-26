using System.Collections.Generic;
using UniRx.Async.Triggers;
using UnityEngine;
using Zenject;

public class MotherSpawner : MonoBehaviour
{
    [Inject] IList<MotherSpawnPoint> spawnPoints;
    [Inject] MotherFactory motherFactory;
    [Inject] Level level;
    
    void Start()
    {
        for (var i = 0; i < Mathf.Pow(level.Value, 1.5f); ++i)
        {
            var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
            var mother = motherFactory.Create();
            mother.Initialize(point, i);
        }
        
    }
}