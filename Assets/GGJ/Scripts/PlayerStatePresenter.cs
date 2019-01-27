using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace GGJ.Scripts
{
    public class PlayerStatePresenter : UIBehaviour
    {
        [Inject] Player player;
        [Inject] Camera camera;
        [SerializeField] Transform playIconTransform;
        [SerializeField] Transform studyIconTransform;
        [SerializeField] Image playIcon;
        [SerializeField] Image studyIcon;
        
        void Start()
        {
            var rectTransform = GetComponent<RectTransform>();
            
            this.UpdateAsObservable().Subscribe(_ =>
                {
                    rectTransform.position = camera.WorldToScreenPoint(player.transform.position + Vector3.up * 1.5f) + new Vector3(-16, -32);
                });

            player.State.Subscribe(state =>
            {
                switch (state)
                {
                    case PlayerState.Playing:
                        playIconTransform.gameObject.SetActive(true);
                        studyIconTransform.gameObject.SetActive(false);
                        break;
                    case PlayerState.Studying:
                        playIconTransform.gameObject.SetActive(false);
                        studyIconTransform.gameObject.SetActive(true);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(state), state, null);
                }
            });
        }
    }
}