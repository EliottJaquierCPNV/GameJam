using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    public string[] dialogText;
    private int dialogIteration = 0;
    public TextMesh dialogTextBox;

    public void interact()
    {
        //iterate everytime user interacts with object
        if(dialogIteration <= dialogText.Length-1)
        {
            dialogTextBox.text = dialogText[dialogIteration];
        }
        else
        {
            dialogTextBox.text = "";
        }
        dialogIteration++;
    }
}
