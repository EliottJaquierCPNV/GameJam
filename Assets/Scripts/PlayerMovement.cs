using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region local variables
    [SerializeField]
    float speed = 5f;
    float x;
    float y;
    #endregion
    
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(x, y);
        transform.Translate(direction * Time.fixedDeltaTime * speed);
    }
    /// <summary>
    /// T�l�porte le joueur aux coordonn�es donn�es.
    /// </summary>
    /// <param name="x">Position X ou l'on veut t�l�porter le personnage.</param>
    /// <param name="y">Position Y ou l'on veut t�l�porter le personnage.</param>
    public void Teleport(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }
}
