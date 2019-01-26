using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(RectTransform))]
public class BoringGauge : MonoBehaviour
{
    [Inject] Fun fun;
    [SerializeField] Slider slider;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(_ => slider.value = fun.Value);
    }
}