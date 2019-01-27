using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ.Scripts
{
    public class HowToButton : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] Transform parentTranform;
        [SerializeField] HowToPresenter prefab;
        
        void Start()
        {
            button.OnClickAsObservable().Subscribe(_ => { Instantiate(prefab, parentTranform); });
        }
    }
}