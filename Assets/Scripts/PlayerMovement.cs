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
    Collider2D colliderInteraction = null;
    #endregion
    #region public variables
    public Animator anim;
    #endregion

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("horizontalSpeed", x);
        anim.SetFloat("verticalSpeed", y);

        if (colliderInteraction != null && Input.GetButtonDown("Interact"))
        {
            colliderInteraction.GetComponent<Interactable>().Interact();
        }
    }
    #region Interact
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            colliderInteraction = collision;
            GameCanvasManager.InteractShow(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            colliderInteraction = null;
            GameCanvasManager.InteractShow(false);
        }
    }
    #endregion

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(x, y);
        transform.Translate(direction * Time.fixedDeltaTime * speed);
    }
    /// <summary>
    /// Téléporte le joueur aux coordonnées données.
    /// </summary>
    /// <param name="x">Position X ou l'on veut téléporter le personnage.</param>
    /// <param name="y">Position Y ou l'on veut téléporter le personnage.</param>
    public void Teleport(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }
}
