using System;
using GGJ.Scripts.npc;
using Zenject;

namespace GGJ.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<HighScore>().AsSingle();
        }
    }
}