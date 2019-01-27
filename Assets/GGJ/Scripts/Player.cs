using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Zenject;

namespace GGJ.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Player : MonoBehaviour
    {
        [Inject] Fun _fun;
        [Inject] ZenjectSceneLoader sceneLoader;
        [Inject] Level level;
        [Inject(Id = "GameTable")] Transform gameTable;
        [Inject(Id = "StudyTable")] Transform studyTable;
        [SerializeField] AudioSource seAudioSource;
    
        readonly Color enableColor = Color.white;
        readonly Color disableColor = Color.white * 0.5f;

        readonly ReactiveProperty<PlayerState> playerState= new ReactiveProperty<PlayerState>(PlayerState.Playing);

        public IReadOnlyReactiveProperty<PlayerState> State => playerState;
    
        void Start()
        {
            var agent = GetComponent<NavMeshAgent>();
            playerState.Subscribe(state =>
            {
                switch (state)
                {
                    case PlayerState.Playing:
                        agent.destination = gameTable.position;
                        return;
                    case PlayerState.Studying:
                        agent.destination = studyTable.position;
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            });

            this.UpdateAsObservable().Subscribe(_ =>
            {
                var boringValue = _fun.Value;
                switch (playerState.Value)
                {
                    case PlayerState.Playing:
                        boringValue += Time.deltaTime * 0.1f;
                        break;
                    case PlayerState.Studying:
                        boringValue -= Time.deltaTime * 0.05f;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _fun.SetValue(boringValue);
            });

            this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1")).Subscribe(_ =>
            {
                seAudioSource.PlayOneShot(seAudioSource.clip);
                switch (playerState.Value)
                {
                    case PlayerState.Playing:
                        playerState.Value = PlayerState.Studying;
                        return;
                    case PlayerState.Studying:
                        playerState.Value = PlayerState.Playing;
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

    }
}