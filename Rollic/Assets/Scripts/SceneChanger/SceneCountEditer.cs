using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCountEditer : MonoBehaviour
{
    public int SceneCount;
    private Saveobjects Saver;
    
    /*!!! You have to set false this gameobject after you changed it. Because if you dont set false this gameobject it will 
    set your value every time. After change set false this gameobject in editor !!!
     */
    private void Awake()
    {
        SceneCount--;
        Saver = new Saveobjects();
        Saver.Level = SceneCount;
        SaveManager.Save(Saver);
    }
}
