using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Boring>().AsSingle();
        Container.Bind<Anger>().AsSingle();
        Container.Bind<TimeManager>().AsSingle();
    }
}
