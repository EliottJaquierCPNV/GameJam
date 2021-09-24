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
    #region Interact
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Interact" && Input.GetButtonDown("Interact"))
        {
            collision.GetComponent<Interactable>().Interact();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            GameCanvasManager.InteractShow(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            GameCanvasManager.InteractShow(false);
        }
    }
    #endregion

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(x, y);
        transform.Translate(direction * Time.fixedDeltaTime * speed);
    }
}
