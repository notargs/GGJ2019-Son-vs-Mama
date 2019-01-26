using UnityEngine;

public class Anger
{
    TimeManager timeManager;

    float value;

    public float GetValue() => value;

    public Anger(TimeManager timeManager)
    {
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
        var speed = 5.0f;
        value += GetScale() * Time.deltaTime * speed;
    }
}
