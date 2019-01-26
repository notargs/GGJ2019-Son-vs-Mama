// Patrol.cs

using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class RoomPatrol : MonoBehaviour
{
    public Transform[] points;
    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (points.Length == 0) return;

        var destPoint = Random.Range(0, points.Length);
        agent.destination = points[destPoint].position;
    }


    void Update()
    {
        if (agent.remainingDistance < 0.3f) GotoNextPoint();
    }
}