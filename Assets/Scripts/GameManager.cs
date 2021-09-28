using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeBeforeEnd = 600f;
    public float timeBeforeEndDef = 600f;
    private bool hasWarned = false;
    private bool hasExploded = false;
    public static GameManager instance;
    private float clock = 0;
    private void Start()
    {
        instance = this;
        timeBeforeEnd = timeBeforeEndDef;
    }

    private void Update()
    {
        timeBeforeEnd -= Time.deltaTime;
        if (timeBeforeEnd < 300 && !hasWarned)
        {
            CameraBehaviour.CamAnim("warning");
            hasWarned = true;
        }
        if (timeBeforeEnd < 10 && !hasExploded)
        {
            CameraBehaviour.CamAnim("explosion");
            hasExploded = true;
        }

        clock = clock + Time.deltaTime;
        if(clock > 1)
        {
            clock = 0;
            CheckSeconds();
        }
    }
    private void CheckSeconds()
    {
        if (timeBeforeEnd < 50)
        {
            if (timeBeforeEnd < 10)
            {
                CameraBehaviour.CamShake(1, (11 - timeBeforeEnd) / 10);
            }
            else
            {
                CameraBehaviour.CamShake(1, (50 - timeBeforeEnd) / 1000);
            }
        }
        if(timeBeforeEnd < 0)
        {
            LevelLoader.LoadOneScene("badend");
        }
    }
}
