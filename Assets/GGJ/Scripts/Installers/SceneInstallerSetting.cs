using System;
using UnityEngine;

namespace GGJ.Scripts.Installers
{
    [Serializable]
    public class SceneInstallerSetting
    {
        [SerializeField] Mother motherPrefab;

        public Mother MotherPrefab => motherPrefab;
    }
}