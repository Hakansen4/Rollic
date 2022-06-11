using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformType
{
    Challenge,
    Straight,
    Final
}
public abstract class BasePlatform : MonoBehaviour
{
    public abstract PlatformType _PlatformType { get; }

}