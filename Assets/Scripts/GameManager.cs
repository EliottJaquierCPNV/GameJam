using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeToExplosion = 600f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        timeToExplosion -= Time.fixedDeltaTime;
    }
}
