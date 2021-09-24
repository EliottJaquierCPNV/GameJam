using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    #region private attributes



    #endregion private attributes
    #region public methods

    public void loadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    #endregion public methods
}
