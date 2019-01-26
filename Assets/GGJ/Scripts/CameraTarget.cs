using UnityEngine;
using Zenject;

public class CameraTarget : MonoBehaviour, ICameraTarget
{
    Vector3 ICameraTarget.Position => transform.position;
    [Inject] CameraPresenter cameraPresenter;

    void OnEnable()
    {
        cameraPresenter.Add(this);
    }
    
    void OnDisable()
    {
        cameraPresenter.Remove(this);
    }
}