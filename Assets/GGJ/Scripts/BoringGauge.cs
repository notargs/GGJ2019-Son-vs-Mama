using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(RectTransform))]
public class BoringGauge : MonoBehaviour
{
    [Inject] Boring boring;
    [SerializeField] RectTransform bar;

    void Start()
    {
        var rectTransform = GetComponent<RectTransform>();

        this.UpdateAsObservable().Subscribe(_ =>
        {
            Debug.Log($"Hello {boring.Value}, {rectTransform.sizeDelta.x}");
            bar.sizeDelta = new Vector2(boring.Value * rectTransform.sizeDelta.x, 0);
        });
    }
}