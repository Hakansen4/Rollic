using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData[] levels;
    private int LevelCount = 2;
    public LevelData GetLevel(int index)
    {
        return levels[index % LevelCount];
    }
}