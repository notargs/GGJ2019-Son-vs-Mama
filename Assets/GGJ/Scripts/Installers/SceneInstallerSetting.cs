using System;
using UnityEngine;

[Serializable]
public class SceneInstallerSetting
{
    [SerializeField] Mother motherPrefab;

    public Mother MotherPrefab => motherPrefab;
}