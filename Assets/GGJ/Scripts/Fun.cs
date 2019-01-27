using System;
using UniRx;
using UnityEngine;

namespace GGJ.Scripts
{
    public class Fun
    {
        readonly ReactiveProperty<float> value = new ReactiveProperty<float>(0.2f);
        public float Value => value.Value;
        public IObservable<float> OnValueChanged => value;
    
        public void SetValue(float v) => value.Value = Mathf.Clamp01(v);
    }
}