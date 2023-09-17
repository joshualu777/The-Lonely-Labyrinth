using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static Dictionary<string, int> levels = new Dictionary<string, int>()
    { { "LV1", 0 }, { "LV2", 1 },{ "LV3" , 2 }  };

    string scene;
    public string getScene()
    {
        return scene;
    }
    public void setScene(string sceneName)
    {
        scene = sceneName;
    }
}
