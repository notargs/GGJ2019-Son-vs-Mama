using UnityEngine;

public class MotherSpawnPoint : MonoBehaviour
{
    public Vector3 Position => transform.position;

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, 1);
    }
}