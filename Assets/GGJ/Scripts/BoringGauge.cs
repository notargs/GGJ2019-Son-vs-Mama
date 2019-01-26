using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(RectTransform))]
public class BoringGauge : MonoBehaviour
{
    [Inject] Boredom boredom;
    [SerializeField] RectTransform bar;

    void Start()
    {
        var rectTransform = GetComponent<RectTransform>();

        this.UpdateAsObservable().Subscribe(_ =>
        {
            bar.sizeDelta = new Vector2(boredom.Value * rectTransform.sizeDelta.x, 0);
        });
    }
}