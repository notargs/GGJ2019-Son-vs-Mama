using GGJ.Scripts.npc;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace GGJ.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mother : MonoBehaviour
    {
        [Inject] Level level;
        [Inject] Anger anger;
        [SerializeField] Collider trigger;
    
        void Start()
        {
            trigger.OnTriggerStayAsObservable()
                .Select(collider => collider.GetComponent<Player>())
                .Where(player => player != null)
                .Where(player => player.State.Value != PlayerState.Studying)
                .Subscribe(player => anger.IncreanceAnger());
        }

        public void Initialize(MotherSpawnPoint point, int index)
        {
            var agent = GetComponent<NavMeshAgent>();
            agent.speed = Random.Range(5, 10);
            agent.Warp(point.Position);
            agent.avoidancePriority = 30 + index;
            if (level.Value > 3 && Random.Range(0, 100.0f) < 5)
            {
                agent.speed *= 100;
                agent.angularSpeed *= 100;
            }
        }
    }
}