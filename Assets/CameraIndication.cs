using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIndication : MonoBehaviour
{
    public bool gotToThisPositionAtStart = false;
    public float orthoSize;
    void Start()
    {
        if (gotToThisPositionAtStart)
        {
            Teleport();
        }
    }
    public void Teleport()
    {
        CameraBehaviour.CamTeleport(transform.position);
        CameraBehaviour.CamInfos(orthoSize);
    }
}
