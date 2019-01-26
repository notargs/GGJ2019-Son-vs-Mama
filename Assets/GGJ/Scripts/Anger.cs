using UnityEngine;
using Zenject;

public class Anger
{
    ZenjectSceneLoader sceneLoader;
    TimeManager timeManager;

    float value;

    public float GetValue() => value;

    public Anger(TimeManager timeManager, ZenjectSceneLoader sceneLoader)
    {
        this.sceneLoader = sceneLoader;
        this.timeManager = timeManager;
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
        var speed = 1.0f;
        value += GetScale() * Time.deltaTime * speed;
        if (value > 1)
        {
            sceneLoader.LoadScene("GameOver");
        }
    }
}
