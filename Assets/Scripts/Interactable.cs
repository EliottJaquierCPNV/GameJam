using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interact;
    /// <summary>
    /// Quand le joueur intéragit avec l'object sur lequel ce script est créé
    /// </summary>
    public void Interact()
    {
        interact.Invoke();//Invoke les évènements
    }
}
