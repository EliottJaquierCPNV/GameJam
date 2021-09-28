using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public static CameraBehaviour instance;
    public Animator anim;
    private Vector3 anchorPosition;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    public static void CamTeleport(Vector2 destination)
    {
        if(instance != null)
        {
            instance.anchorPosition = new Vector3(destination.x, destination.y, -10);
            instance.transform.position = instance.anchorPosition;
        } 
    }
    public static void CamInfos(float orthoSize)
    {
        if (instance != null)
            instance.GetComponent<Camera>().orthographicSize = orthoSize;
    }
    public static void CamShake(float duration, float magnitude)
    {
        if (instance != null)
            instance.StartCoroutine(instance.Shake(duration, magnitude));
    }
    public static void CamAnim(string trigger)
    {
        if (instance != null)
            instance.anim.SetTrigger(trigger);
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = instance.anchorPosition+new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}