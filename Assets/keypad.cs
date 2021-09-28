using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keypad : MonoBehaviour
{
    #region local variables
    [SerializeField]
    string displayCode;
    string validCode;
    public Text displayText;
    private Door reference;
    public FMODUnity.StudioEventEmitter tr;
    public FMODUnity.StudioEventEmitter fl;
    #endregion
    public void Setup(string code, Door doorRef)
    {
        reference = doorRef;
        displayCode = "";
        displayText.text = "";
        gameObject.SetActive(true);
        validCode = code;
    }
    public void Close()
    {
        gameObject.SetActive(false);
        reference = null;
    }
    /// <summary>
    /// Ajouter le nouveau contenu sur la zone de texte du keypad
    /// </summary>
    /// <param name="addToText"></param>
    public void AddToDisplay(string addToText)
    {
        displayCode = displayCode + addToText;
        displayText.text = displayCode;
    }

    public void ValidateCode()
    {
        if(displayCode == validCode)
        {
            reference.OpenDirectely();
            Close();
            tr.Play();
        }
        else
        {
            displayCode = "";
            displayText.text = "";
            fl.Play();
        }
    }
}
