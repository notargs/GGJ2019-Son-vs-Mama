using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class AngerGauge : MonoBehaviour
{
    [SerializeField] Slider slider;
    [Inject] Anger anger;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(_ =>
        {
            slider.value = anger.GetValue();
        });
    }
}
