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
<<<<<<< HEAD
        [SerializeField] Button exit = default;
=======
>>>>>>> 804296d7ed01f1992e2574e1bd1eab79f5cd32a3
    
        void Start()
        {
            button.OnClickAsObservable()
                .Subscribe(_ => sceneLoader.LoadScene("MainScene"));
<<<<<<< HEAD
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

=======
>>>>>>> 804296d7ed01f1992e2574e1bd1eab79f5cd32a3
        }
    }
}