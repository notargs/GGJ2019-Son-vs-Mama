using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GGJ.Scripts
{
    public class LevelPresenter : MonoBehaviour
    {
        [SerializeField] Text text;
        [Inject] Level level;

        void Start()
        {
            text.text = $"Level {level.Value}";
        }
    }
}