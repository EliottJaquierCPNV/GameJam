using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static LevelLoader instance;
    private static string currentGameScene;
    private static bool isSwitchingLevel = false;
    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("LevelLoader").Length > 1)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    #region public methods

    public static void LoadOneScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void LaunchGameCoreWithScene(string sceneName)
    {
        if (!isSwitchingLevel)
            instance.StartCoroutine(instance.IELaunchGameCoreWithScene(sceneName));
    }
    IEnumerator IELaunchGameCoreWithScene(string sceneName)
    {
        isSwitchingLevel = true;
        AsyncOperation coreOperation = SceneManager.LoadSceneAsync("core");
        coreOperation.allowSceneActivation = true;


        Debug.Log("LOADING");

        while (!coreOperation.isDone) {
            Debug.Log("Loading core... "+coreOperation.progress);
            yield return new WaitForEndOfFrame();
        }

        currentGameScene = sceneName;
        AsyncOperation levelOperation = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
        levelOperation.allowSceneActivation = true;

        while (!levelOperation.isDone)
        {
            Debug.Log("Loading level... " + levelOperation.progress);
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("DONE");
        GameCanvasManager.Fade(false);
        isSwitchingLevel = false;
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
    public static void ChangeSceneGame(string newSceneName)
    {
        if(!isSwitchingLevel)
        instance.StartCoroutine(instance.IEChangeSceneGame(newSceneName));
    }
    IEnumerator IEChangeSceneGame(string newSceneName)
    {
        isSwitchingLevel = true;
        GameCanvasManager.Fade(true);
        yield return new WaitForSeconds(1);
        AsyncOperation lastLevelOperation = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(currentGameScene));
        while (!lastLevelOperation.isDone)
        {
            Debug.Log("Unloading level... " + lastLevelOperation.progress);
            yield return new WaitForEndOfFrame();
        }

        currentGameScene = newSceneName;
        AsyncOperation levelOperation = SceneManager.LoadSceneAsync(currentGameScene, LoadSceneMode.Additive);
        levelOperation.allowSceneActivation = true;

        while (!levelOperation.isDone)
        {
            Debug.Log("Loading level... " + levelOperation.progress);
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("DONE");
        GameCanvasManager.Fade(false);
        isSwitchingLevel = false;
    }

    #endregion public methods
}
