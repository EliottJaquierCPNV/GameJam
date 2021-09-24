using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keypad : MonoBehaviour
{
    #region local variables
    [SerializeField]
    string displayCode;
    public Text displayText;
    public Canvas keyPad;
    #endregion
    
    /// <summary>
    /// Ajouter le nouveau contenu sur la zone de texte du keypad
    /// </summary>
    /// <param name="addToText"></param>
    public void AddToDisplay(string addToText)
    {
        displayCode = displayCode + addToText;
        displayText.text = displayCode;
    }

    public void ValidateCode(string validCode)
    {
        if(displayCode == validCode)
        {
            Debug.Log("Code Valide");
        }
        else
        {
            Debug.Log("Code Invalide");
        }
    }

    
    public void OpenCloseKeypad(bool open)
    {
        keyPad.GetComponent<Canvas>().enabled = open;
    }
}
