using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Player : MonoBehaviour, IPlayer
{
    [Inject(Id = "PlayIcon")] Image playIcon;
    [Inject(Id = "StudyIcon")] Image studyIcon;
    [Inject] Boring boring;
    
    readonly Color enableColor = Color.white;
    readonly Color disableColor = Color.white * 0.5f;

    readonly ReactiveProperty<PlayerState> playerState= new ReactiveProperty<PlayerState>();

    public IReadOnlyReactiveProperty<PlayerState> State => playerState;
    
    void Start()
    {
        playerState.Subscribe(state =>
        {
            switch (state)
            {
                case PlayerState.Playing:
                    playIcon.color = enableColor;
                    studyIcon.color = disableColor;
                    return;
                case PlayerState.Studying:
                    playIcon.color = disableColor;
                    studyIcon.color = enableColor;
                    return;
                case PlayerState.Waiting:
                    playIcon.color = disableColor;
                    studyIcon.color = disableColor;
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        });

        this.UpdateAsObservable().Subscribe(_ =>
        {
            var boringValue = boring.Value;
            var speed = 0.1f;
            switch (playerState.Value)
            {
                case PlayerState.Playing:
                    boringValue -= Time.deltaTime * speed;
                    break;
                case PlayerState.Studying:
                    boringValue += Time.deltaTime * speed;
                    break;
                case PlayerState.Waiting:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            boring.SetValue(boringValue);
        });
        
        this.UpdateAsObservable().Where(_ => Input.GetButtonDown("Fire1")).Subscribe(_ =>
        {
            switch (playerState.Value)
            {
                case PlayerState.Waiting:
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