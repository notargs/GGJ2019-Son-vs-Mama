using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using UniRx.Triggers;
using GGJ.Scripts;

public class MotherSearch : MonoBehaviour
{
    [Inject] Anger anger;

    void Start()
    {
        this.OnTriggerStayAsObservable()
            .Where(collider => collider.GetComponent<IPlayer>() != null)
            .Subscribe(collider => {
                anger.IncreanceAnger();
                Debug.Log("Enter");
                });
    }
}

internal interface IPlayer
{
}