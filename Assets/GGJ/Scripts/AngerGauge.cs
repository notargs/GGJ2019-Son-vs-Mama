using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GGJ.Scripts
{
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
}
