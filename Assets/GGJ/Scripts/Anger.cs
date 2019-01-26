using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Anger
{
    readonly ZenjectSceneLoader sceneLoader;
    readonly TimeManager timeManager;
    readonly Level level;

    float value;

    public float GetValue() => value;

    public Anger(TimeManager timeManager, ZenjectSceneLoader sceneLoader, Level level)
    {
        this.sceneLoader = sceneLoader;
        this.timeManager = timeManager;
        this.level = level;
    }

    float GetScale()
    {
        //ある時間帯によって怒りゲージが増えやすくなる
        var hour = timeManager.GetOneDayHour();
        if (hour <= 5) return 2;
        return 1;
    }

    public void IncreanceAnger()
    {
        var speed = 0.6f;
        value += GetScale() * Time.deltaTime * speed;
        if (value > 1)
        {
            sceneLoader.LoadScene("GameOver", LoadSceneMode.Single, container => container.Bind<Level>().AsSingle().WithArguments(level.Value));
        }
    }
}
