using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GGJ.Scripts
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField] Text text;
        [Inject] Level level;

        void Start()
        {
            text.text = $"Score: {level.Value} Level";
        }
    }
}