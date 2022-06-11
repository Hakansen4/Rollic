using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelData",menuName ="NewLevel",order =1)]
public class LevelData : ScriptableObject
{
    public List<PlatformData> Platforms;
}

[Serializable]
public class PlatformData
{
    public PlatformType Type;
    public Vector3 Position;
    public int ChallenceCount;
}
