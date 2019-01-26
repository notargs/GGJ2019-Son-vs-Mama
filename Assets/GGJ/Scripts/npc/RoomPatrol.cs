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