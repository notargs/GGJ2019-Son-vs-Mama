using System;
using UniRx;
using UnityEngine.SceneManagement;
using Zenject;

namespace GGJ.Scripts
{
    public class GameSceneTranslator : IDisposable
    {
        readonly CompositeDisposable disposable = new CompositeDisposable();
        bool loadStarted;

        GameSceneTranslator(Fun fun, Anger anger, ZenjectSceneLoader sceneLoader, Level level)
        {
            fun.OnValueChanged.Where(value => value <= float.Epsilon).Where(_ => !loadStarted).Subscribe(_ =>
            {
                loadStarted = true;
                sceneLoader.LoadScene("BoredomGameOver", LoadSceneMode.Single, container => container.Bind<Level>().AsSingle().WithArguments(level.Value));
            }).AddTo(disposable);

            fun.OnValueChanged.Where(value => value >= 1 - float.Epsilon).Where(_ => !loadStarted).Subscribe(_ =>
            {
                loadStarted = true;
                sceneLoader.LoadScene("MainScene", LoadSceneMode.Single, container => container.Bind<Level>().AsSingle().WithArguments(level.Value + 1));
            }).AddTo(disposable);

            anger.OnValueChanged.Where(value => value >= 1 - float.Epsilon).Where(_ => !loadStarted).Subscribe(_ =>
            {
                loadStarted = true;
                sceneLoader.LoadScene("GameOver", LoadSceneMode.Single, container => container.Bind<Level>().AsSingle().WithArguments(level.Value));
            }).AddTo(disposable);
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}