using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float elapsedSecond;

    public float Seconds() => elapsedSecond;
    public float Minites() => elapsedSecond / 60;
    public float GetHour() => Minites() / 60;
    public float GetOneDayHour() => GetHour() % 24;
    public float GetOneHourMinutes() => Minites() % 60;

    void Update()
    {
        elapsedSecond += Time.deltaTime * 60 * 60 * 2;
    }
}
