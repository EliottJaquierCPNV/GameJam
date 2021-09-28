using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerPlayer : MonoBehaviour
{
    public UnityEvent ev; 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ev.Invoke();
        }
    }
}
