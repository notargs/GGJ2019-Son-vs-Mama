using UnityEngine;

namespace GGJ.Scripts.npc
{
    public class MotherPatrolPoint : MonoBehaviour
    {
        public Vector3 Position => transform.position;
    
        void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.5f);
            Gizmos.DrawSphere(transform.position, 1);
        }
    }
}