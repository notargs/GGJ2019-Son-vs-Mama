// Patrol.cs

using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using Zenject;

public class RoomPatrol : MonoBehaviour
{
    [Inject] IList<MotherPatrolPoint> points;
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
        if (points.Count == 0) return;

        var destPoint = Random.Range(0, points.Count);
        agent.destination = points[destPoint].Position;
    }


    void Update()
    {
        if (agent.remainingDistance < 1.0f) GotoNextPoint();
    }
}