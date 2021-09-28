using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    public string[] dialogText;
    private int dialogIteration = 0;
    public void interact()
    {
        //iterate everytime user interacts with object
        if(dialogIteration <= dialogText.Length-1)
        {
            GameCanvasManager.ShowInfo(dialogText[dialogIteration]);
        }
        else if(dialogIteration == dialogText.Length)
        {
            GameCanvasManager.ShowInfo("...");
        }
        dialogIteration++;
        if(dialogIteration > dialogText.Length)
        {
            dialogIteration = 0;
        }
    }
}
