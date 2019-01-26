using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class TimePresenter : MonoBehaviour
{
    [Inject] TimeManager timeManager;
    [SerializeField] Text text;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(_ =>
        {
            var hour = Mathf.FloorToInt(timeManager.GetOneDayHour()).ToString("00");
            var min = Mathf.FloorToInt(timeManager.GetOneHourMinutes()).ToString("00");
            text.text = $"{hour}:{min}";
        });
    }
}