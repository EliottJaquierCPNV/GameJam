
using UnityEngine;
namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : Interactable
    {
        protected override void OnPlayerInteract(PlayerController player)
        {
            GameController.Victory();
        }
    }
}