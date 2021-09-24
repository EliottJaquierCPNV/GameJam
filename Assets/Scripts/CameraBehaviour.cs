using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
     Vector3 outOffset;
    void Start()
    {
        outOffset = offset;
    }
    
    void Update()
    {
        CheckIfOnBorder();
    }

    void CheckIfOnBorder()
    {
        if(playerTransform.position.x <= outOffset.x - 20)
        {
            CamTeleport(new Vector3(-10, 0, 0));
            outOffset.x -= 10;
        }
        if (playerTransform.position.x >= outOffset.x)
        {
            CamTeleport(new Vector3(+10, 0, 0));
            outOffset.x += 10;
        }
        if (playerTransform.position.y <= outOffset.y - 20)
        {
            CamTeleport(new Vector3(0, -10, 0));
            outOffset.y -= 10;
        }
        if (playerTransform.position.y >= outOffset.y)
        {
            CamTeleport(new Vector3(0, 10, 0));
            outOffset.y += 10;
        }
    }

    void CamTeleport(Vector3 destination)
    {
        transform.position += destination;
    }
}
