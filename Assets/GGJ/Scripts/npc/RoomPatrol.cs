    // Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;

    public class RoomPatrol : MonoBehaviour {

        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;


        void Start () {
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = true;

            GotoNextPoint();
        }


        void GotoNextPoint() {
            if (points.Length == 0)
                return;

            destPoint = (destPoint + 1) % points.Length;
            agent.destination = points[destPoint].position;
        }


        void Update () {
            if (!agent.pathPending && agent.remainingDistance < 0.02f)
                GotoNextPoint();
        }
    }