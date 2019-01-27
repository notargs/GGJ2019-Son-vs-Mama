using UnityEngine;
using Zenject;

namespace GGJ.Scripts.npc
{
    public class CatchTarget : MonoBehaviour
    {
        [Inject] ZenjectSceneLoader sceneLoader;
        [Inject] Player target;
        public float catchDistance;

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) < this.catchDistance &&
                target.State.Value.Equals(PlayerState.Playing))
            {
                sceneLoader.LoadScene("GameOver");
            }
        }
    }
}
