using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GGJ.Scripts
{
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
}