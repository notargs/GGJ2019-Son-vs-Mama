using UnityEngine;

namespace GGJ.Scripts
{
    public class HowToPresenter : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject, 60 + 12);
        }
    }
}