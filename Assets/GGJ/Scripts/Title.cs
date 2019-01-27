using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GGJ.Scripts
{
    public class Title : MonoBehaviour
    {
        [Inject] ZenjectSceneLoader sceneLoader;
    
        [SerializeField] Button button = default;
        [SerializeField] Button exit = default;
    
        void Start()
        {
            button.OnClickAsObservable()
                .Subscribe(_ => sceneLoader.LoadScene("MainScene"));
            exit.OnClickAsObservable()
                .Subscribe(_ => GameEnd());
        }

       public void GameEnd()
        {
#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;
#else
		 exit.OnClickAsObservable()
                .Subscribe(_=>Application.Quit());
#endif

        }
    }
}