using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] Text text;
    [Inject] Level level;

    void Start()
    {
        text.text = $"Score: {level.Value} Level";
    }
}