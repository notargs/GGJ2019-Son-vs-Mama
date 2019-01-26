using UnityEngine;
using Zenject;
using Zenject.MemoryPoolMonitor;

[CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
public class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    [SerializeField] SceneInstallerSetting sceneInstallerSetting;
    public override void InstallBindings()
    {
        Container.BindInstances(sceneInstallerSetting);
    }
}