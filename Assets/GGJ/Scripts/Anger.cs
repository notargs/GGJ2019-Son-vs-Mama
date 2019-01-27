using System;
using UniRx;
using UnityEngine;

namespace GGJ.Scripts
{
    public class Anger
    {
        readonly TimeManager timeManager;

        readonly ReactiveProperty<float> value = new ReactiveProperty<float>();

        public float GetValue() => value.Value;

        public IObservable<float> OnValueChanged => value;

        public Anger(TimeManager timeManager)
        {
            this.timeManager = timeManager;
        }

        float GetScale()
        {
            //ある時間帯によって怒りゲージが増えやすくなる
            var hour = timeManager.GetOneDayHour();
            if (hour <= 5) return 2;
            return 1;
        }

        public void IncreanceAnger()
        {
            var speed = 0.6f;
            value.Value += GetScale() * Time.deltaTime * speed;
        }
    }
}