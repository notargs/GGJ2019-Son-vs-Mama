using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Inject] SceneInstallerSetting setting;
    [InjectOptional] Level level;
    
    public override void InstallBindings()
    {
        Container.Bind<Anger>().AsSingle();
        Container.Bind<Fun>().AsSingle();
        Container.BindFactory<Mother, MotherFactory>().FromComponentInNewPrefab(setting.MotherPrefab);

        if (level == null)
        {
            Container.Bind<Level>().AsSingle().WithArguments(1);
        }
    }
}