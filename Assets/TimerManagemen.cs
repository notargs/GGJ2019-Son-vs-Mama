using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManagemen : MonoBehaviour
{

    public float timeElapsed ;
    public int minute;
    public static int twiceAnger;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0.0f;
        minute = 8;

        twiceAnger = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        //時間の進むスピードを調整
        Time.timeScale = 20.0f;

        //60分経ったら1時間増える
        if(timeElapsed >= 59.0f)
        {
            minute++;
            timeElapsed = 0.0f;
        }

        //24時になったらリセット
        if (minute >= 24)
        {
            minute = 0;
        }

        //ある時間帯によって怒りゲージが増えやすくなる
        if (minute >= 24 || minute <= 5)
        {
            twiceAnger = 2;
        }
        GetComponent<Text>().text = minute+":"+ timeElapsed.ToString("00");

    }
}
