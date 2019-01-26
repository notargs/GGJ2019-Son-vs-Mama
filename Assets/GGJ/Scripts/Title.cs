using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Title : MonoBehaviour
{
    [Inject] ZenjectSceneLoader sceneLoader;
    
    [SerializeField] Button button = default;
    
    void Start()
    {
        button.OnClickAsObservable()
            .Subscribe(_ => sceneLoader.LoadScene("MainScene"));
    }
}