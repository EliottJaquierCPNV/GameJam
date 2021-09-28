using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    private static GameCanvasManager instance;
    [SerializeField]
    private GameObject interact;
    [SerializeField]
    private keypad kpad;
    [SerializeField]
    private Animator fade;
    [SerializeField]
    private Animator infoUI;
    [SerializeField]
    private Text infoUIT;
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

    public static void ShowInfo(string info)
    {
        instance.infoUI.SetTrigger("info");
        instance.infoUIT.text = info;
    }

    public static void KeyPadSetup(Door reference,string code)
    {
        instance.kpad.Setup(code, reference);
    }
    public static void Fade(bool toBlack)
    {
        if (toBlack)
        {
            instance.fade.SetTrigger("fade");
        }
        else
        {
            instance.fade.SetTrigger("restore");
        }
    }
}
