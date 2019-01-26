using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Anger>().AsSingle();
        Container.Bind<Boredom>().AsSingle();
    }
}
