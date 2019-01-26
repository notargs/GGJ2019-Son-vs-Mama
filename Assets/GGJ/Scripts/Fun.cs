using System;
using UniRx;
using UnityEngine;

public class Fun
{
    readonly ReactiveProperty<float> value = new ReactiveProperty<float>(0.5f);
    public float Value => value.Value;
    public IObservable<float> OnValueChanged => value;
    
    public void SetValue(float v) => value.Value = Mathf.Clamp01(v);
}