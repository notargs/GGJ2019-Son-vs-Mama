using System;
using GGJ.Scripts.npc;
using Zenject;

namespace GGJ.Scripts.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [Inject] SceneInstallerSetting setting;
        [InjectOptional] Level level;
    
        public override void InstallBindings()
        {
            Container.Bind<Anger>().AsSingle();
            Container.Bind<Fun>().AsSingle();
            Container.BindFactory<Mother, MotherFactory>().FromComponentInNewPrefab(setting.MotherPrefab);
            Container.Bind<IDisposable>().To<GameSceneTranslator>().AsSingle().NonLazy();

            if (level == null)
            {
                Container.Bind<Level>().AsSingle().WithArguments(1);
            }
        }
    }
}