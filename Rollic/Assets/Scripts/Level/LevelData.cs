using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallsType
{
    Straight,
    ArrowHead
}

[CreateAssetMenu(fileName ="LevelData",menuName ="NewLevel",order =1)]
public class LevelData : ScriptableObject
{
    public List<PlatformData> Platforms;
    public List<BallsData> Balls;
}

[Serializable]
public class PlatformData
{
    public PlatformType Type;
    public Vector3 Position;
    public int ChallenceCount;
}

[Serializable]
public class BallsData
{
    public BallsType Type;
    public Vector3 Position;
}