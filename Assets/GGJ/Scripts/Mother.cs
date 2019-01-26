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
    
    void Start()
    {
        this.OnTriggerStayAsObservable()
            .Select(collider => collider.GetComponent<Player>())
            .Where(player => player != null)
            .Where(player => player.State.Value != PlayerState.Studying)
            .Subscribe(player => anger.IncreanceAnger());
    }

    public void Initialize(MotherSpawnPoint point, int index)
    {
        transform.position = point.Position;
        var agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = 30 + index;
    }
}