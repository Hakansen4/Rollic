using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCountEditer : MonoBehaviour
{
    public int SceneCount;
    private Saveobjects Saver;

    private void Awake()
    {
        SceneCount--;
        Saver = new Saveobjects();
        Saver.Level = SceneCount;
        SaveManager.Save(Saver);
    }
}
