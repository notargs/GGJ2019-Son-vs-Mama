using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GGJ.Scripts
{
    public class HighScorePresenter : MonoBehaviour
    {
        [SerializeField] Text text;
        [Inject] HighScore highScore;

        void Start()
        {
            text.text = $"Highest level reached:   {highScore.Value}";
        }
    }
}