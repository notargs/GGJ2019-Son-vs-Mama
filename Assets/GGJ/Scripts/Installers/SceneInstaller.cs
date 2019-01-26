using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Inject] SceneInstallerSetting setting;
    
    public override void InstallBindings()
    {
        Container.Bind<Anger>().AsSingle();
        Container.Bind<Fun>().AsSingle();
        Container.Bind<Level>().AsSingle().WithArguments(5);
        Container.BindFactory<Mother, MotherFactory>().FromComponentInNewPrefab(setting.MotherPrefab);
    }
}