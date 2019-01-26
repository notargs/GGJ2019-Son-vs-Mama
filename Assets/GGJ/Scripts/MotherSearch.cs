using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using UniRx.Triggers;

public class MotherSearch : MonoBehaviour
{
    [SerializeField] Slider slider;
    [Inject] Anger anger;

    void Start()
    {
        this.OnTriggerEnterAsObservable()
            .Where(collider => collider.GetComponent<IPlayer>() != null)
            .Subscribe(collider => anger.IncreanceAnger());
    }
}
