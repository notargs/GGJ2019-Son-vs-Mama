using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CatchTarget : MonoBehaviour
{
    [Inject] ZenjectSceneLoader sceneLoader;
    public GameObject target;
    public float catchDistance;
    
    void Update()
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) < this.catchDistance)
        {
            sceneLoader.LoadScene("GameOver");
        }
    }
}
