using UniRx;
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
        
        boring.Value.Subscribe(value => { bar.sizeDelta = new Vector2(value * rectTransform.sizeDelta.x, 0); });
    }
}