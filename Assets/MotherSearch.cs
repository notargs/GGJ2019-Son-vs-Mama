using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotherSearch : MonoBehaviour
{
    public Slider slider;
    int BeFoundPoint=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //母親の索敵範囲に入ったらゲージが増える
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name=="Player")
        {
            slider.value += BeFoundPoint*TimerManagemen.twiceAnger;
            Debug.Log("hit");
        }
    }
}
