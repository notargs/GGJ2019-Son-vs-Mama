using System;
using UniRx;

public class Boring
{
    readonly ReactiveProperty<float> value = new ReactiveProperty<float>(0.5f);
    public float Value => value.Value;
    public IObservable<float> OnValueChanged => value;
    
    public void SetValue(float v) => value.Value = v;
}