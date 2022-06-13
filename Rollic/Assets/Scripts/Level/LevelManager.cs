using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public LevelData[] levels;
    private int LevelCount = 3;

    private void Awake()
    {
        instance = this;
    }
    public LevelData GetLevel(int index)
    {
        return levels[index % LevelCount];
    }
}