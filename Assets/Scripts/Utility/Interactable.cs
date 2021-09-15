using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This abstract class is used for object who can be interacted with a player
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    /// <summary>
    /// Can interact only one time ? (else multiple time)
    /// </summary>
    [SerializeField]
    protected bool canInteractOnlyOneTime = false;

    /// <summary>
    /// Is based on Colliders who have 'isTrigger' activated ? (or every collider with collision)
    /// </summary>
    [SerializeField]
    protected bool isTriggerSystem = true;

    /// <summary>
    /// Has player already interacted one time with the object
    /// </summary>
    protected bool hasAlreadyInteractedOneTime = false;

    /// <summary>
    /// This method detect if the player is in the actual object
    /// </summary>
    /// <param name="other">The other collider</param>
    protected void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null && isTriggerSystem) OnPlayerEnter(player);
    }

    /// <summary>
    /// This method detect if the player is colliding in actual object
    /// </summary>
    /// <param name="collision">The other collision</param>
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null && !isTriggerSystem) OnPlayerEnter(player);
    }

    /// <summary>
    /// This method manage the collectible constraint and call OnPlayerInteract
    /// </summary>
    /// <param name="player">The Player (interact with object)</param>
    protected void OnPlayerEnter(PlayerController player)
    {
        if (hasAlreadyInteractedOneTime && canInteractOnlyOneTime) return;
        hasAlreadyInteractedOneTime = true;
        OnPlayerInteract(player);
    }

    /// <summary>
    /// This method is trigger when a player collect / enter in this object
    /// </summary>
    /// <param name="player">The player reference</param>
    protected abstract void OnPlayerInteract(PlayerController player);
}