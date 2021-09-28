using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerWhenTime : MonoBehaviour
{
    public float time;
    public UnityEvent ev;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        ev.Invoke();
    }
}
