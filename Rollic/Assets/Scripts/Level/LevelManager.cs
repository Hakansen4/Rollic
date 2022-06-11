using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData[] levels;

    public LevelData GetLevel(int index)
    {
        return levels[index];
    }
}