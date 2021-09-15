using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer.Interfaces
{
    public interface ICharacter
    {
        /// <summary>
        /// Make the character die
        /// </summary>
        public abstract void Die();
    }

}