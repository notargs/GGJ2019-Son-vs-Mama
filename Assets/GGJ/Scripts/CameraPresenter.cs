using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace GGJ.Scripts
{
    [RequireComponent(typeof(Camera))]
    public class CameraPresenter : MonoBehaviour
    {
        readonly IList<ICameraTarget> cameraTargets = new List<ICameraTarget>();

        public void Add(ICameraTarget cameraTarget) => cameraTargets.Add(cameraTarget);
        public void Remove(ICameraTarget cameraTarget) => cameraTargets.Remove(cameraTarget);
    
        void Start()
        {
            var camera = GetComponent<Camera>();
            var velocity = Vector3.zero;
        
            this.UpdateAsObservable().Subscribe(_ =>
            {
                var bounds = CalcCameraTargetBounds();
                var dist = 7 + bounds.size.magnitude;
                transform.position = Vector3.SmoothDamp(transform.position,  bounds.center + Vector3.back * dist, ref velocity, 0.1f);
            });
        }

        void OnDrawGizmos()
        {
            var bounds = CalcCameraTargetBounds();
        
            Gizmos.color = new Color(0, 0, 0, 0.5f);
            Gizmos.DrawCube(bounds.center, bounds.size);
        }

        Bounds CalcCameraTargetBounds()
        {
            var bounds = new Bounds();

            if (cameraTargets == null) return bounds;
            if (cameraTargets.Count == 0) return bounds;

            bounds.center = cameraTargets[0].Position;

            for (var i = 1; i < cameraTargets.Count; ++i)
            {
                bounds.Encapsulate(cameraTargets[i].Position);
            }

            return bounds;
        }
    }
}