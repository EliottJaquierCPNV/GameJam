using UnityEngine;
using Platformer.Mechanics;

public class PlatformerJumpPad : Interactable
{
    public float verticalVelocity;

    protected override void OnPlayerInteract(PlayerController player)
    {
       if(player.GetComponent<Rigidbody2D>() != null)
            AddVelocity(player);
    }

    void AddVelocity(PlayerController player)
    {
        player.velocity.y = verticalVelocity;
    }
}
