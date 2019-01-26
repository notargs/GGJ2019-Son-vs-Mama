using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using UniRx.Triggers;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Mother : MonoBehaviour
{
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
        agent.Warp(point.Position);
        agent.avoidancePriority = 30 + index;
    }
}