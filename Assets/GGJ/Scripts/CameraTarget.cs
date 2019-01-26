using UnityEngine;

public class CameraTarget : MonoBehaviour, ICameraTarget
{
    Vector3 ICameraTarget.Position => transform.position;
}