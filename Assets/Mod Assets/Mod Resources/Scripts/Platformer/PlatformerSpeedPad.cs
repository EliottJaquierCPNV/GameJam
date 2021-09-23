using System.Collections;
using UnityEngine;
using Platformer.Mechanics;

public class PlatformerSpeedPad : Interactable
{
    public float maxSpeed;

    [Range (0, 5)]
    public float duration = 1f;

    private bool isActivated = false;

    protected override void OnPlayerInteract(PlayerController player)
    {
        if(player.GetComponent<Rigidbody2D>() != null && !isActivated)
        player.StartCoroutine(PlayerModifier(player, duration));
    }
    IEnumerator PlayerModifier(PlayerController player, float lifetime){
        var initialSpeed = player.maxSpeed;
        isActivated = true;
        player.maxSpeed = maxSpeed;
        yield return new WaitForSeconds(lifetime);
        player.maxSpeed = initialSpeed;
        isActivated = false;
    }
}