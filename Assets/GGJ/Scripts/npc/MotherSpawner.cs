using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GGJ.Scripts.npc
{
    public class MotherSpawner : MonoBehaviour
    {
        [Inject] IList<MotherSpawnPoint> spawnPoints;
        [Inject] MotherFactory motherFactory;
        [Inject] Level level;
    
        void Start()
        {
            var count = 1;
            if (level.Value != 1)
            {
                count = Mathf.RoundToInt(Mathf.Pow(level.Value * 0.5f, 0.3f) * 8.0f);
            }
            for (var i = 0; i < count; ++i)
            {
                var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
                var mother = motherFactory.Create();
                mother.Initialize(point, i);
            }
        
        }
    }
}