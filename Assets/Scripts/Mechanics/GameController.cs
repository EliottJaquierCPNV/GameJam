
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        /// <summary>
        /// The virtual camera in the scene.
        /// </summary>
        public Cinemachine.CinemachineVirtualCamera virtualCamera;

        /// <summary>
        /// The main component which controls the player sprite, controlled 
        /// by the user.
        /// </summary>
        public PlayerController player;

        /// <summary>
        /// The spawn point in the scene.
        /// </summary>
        public Transform spawnPoint;

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        //public PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        #region Instanciation Static
        void OnEnable()
        {
            Instance = this;
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }
        #endregion
        #region GeneralManagement
        public static async void EnableInput(float waitTime)
        {
            await Task.Delay(TimeSpan.FromSeconds(waitTime));
            if (Instance != null)
                Instance.player.controlEnabled = true;
        }
        public static void Victory()
        {
            Instance.player.animator.SetTrigger("victory");
            Instance.player.controlEnabled = false;
        }
        #endregion
        #region PlayerManagement
        public static void PlayerDie(PlayerController player)
        {
            if (Instance.player.isAlive)
            {
                Instance.player.isAlive = false;
                Instance.virtualCamera.m_Follow = null;
                Instance.virtualCamera.m_LookAt = null;
                // player.collider.enabled = false;
                Instance.player.controlEnabled = false;

                if (Instance.player.audioSource && Instance.player.ouchAudio)
                    Instance.player.audioSource.PlayOneShot(Instance.player.ouchAudio);
                Instance.player.animator.SetTrigger("hurt");
                Instance.player.animator.SetBool("dead", true);
                PlayerSpawn(2f);
            }
        }
        public static async void PlayerSpawn(float waitTime) 
        {
            await Task.Delay(TimeSpan.FromSeconds(waitTime));
            Instance.player.collider2d.enabled = true;
            Instance.player.controlEnabled = false;
            if (Instance.player.audioSource && Instance.player.respawnAudio)
                Instance.player.audioSource.PlayOneShot(Instance.player.respawnAudio);
            Instance.player.isAlive = true;
            Instance.player.Teleport(Instance.spawnPoint.transform.position);
            Instance.player.jumpState = PlayerController.JumpState.Grounded;
            Instance.player.animator.SetBool("dead", false);
            Instance.virtualCamera.m_Follow = Instance.player.transform;
            Instance.virtualCamera.m_LookAt = Instance.player.transform;
            EnableInput(2f);
        }
        #endregion
    }
}