using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool teleportAtStart = true;
    private void Start()
    {
        if (teleportAtStart)
            Teleport();
    }
    public void Teleport()
    {
        PlayerMovement.Teleport(transform.position);
    }
}
