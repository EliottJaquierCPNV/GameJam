using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoaderCall : MonoBehaviour
{
    public void LoadOneScene(string sceneName)
    {
        LevelLoader.LoadOneScene(sceneName);
    }
    public void LaunchGameCoreWithScene(string sceneName)
    {
        LevelLoader.LaunchGameCoreWithScene(sceneName);
    }
    public void ChangeSceneGame(string newSceneName)
    {
        LevelLoader.ChangeSceneGame(newSceneName);
    }
}
