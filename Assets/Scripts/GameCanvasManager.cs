using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    private static GameCanvasManager instance;
    [SerializeField]
    private GameObject interact;
    [SerializeField]
    private keypad kpad;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    /// <summary>
    /// Show interaction indication
    /// </summary>
    /// <param name="showing">Active or disable ?</param>
    public static void InteractShow(bool showing)
    {
        instance.interact.SetActive(showing);
    }

    public static void KeyPadSetup(Door reference,string code)
    {
        instance.kpad.Setup(code, reference);
    }
}
