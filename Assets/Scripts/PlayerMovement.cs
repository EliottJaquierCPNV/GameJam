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
    FMOD.Studio.EventInstance audFoot;
    static PlayerMovement instance;
    #endregion
    #region public variables
    public Animator anim;
    [FMODUnity.EventRef]
    public string audFootSteps = "";
    #endregion
    private void OnEnable()
    {
        instance = this;
        audFoot = FMODUnity.RuntimeManager.CreateInstance(audFootSteps);
        audFoot.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
        audFoot.start();
    }
    private void OnDisable()
    {
        instance = null;
        audFoot.release();
    }
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = 0;
        if (x == 0)
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
        if(direction.x != 0 || direction.y != 0)
        {
            audFoot.setParameterByName("active", 1);
        }
        else
        {
            audFoot.setParameterByName("active", 0);
        }
    }
    /// <summary>
    /// T?l?porte le joueur aux coordonn?es donn?es.
    /// </summary>
    /// <param name="x">Position X ou l'on veut t?l?porter le personnage.</param>
    /// <param name="y">Position Y ou l'on veut t?l?porter le personnage.</param>
    public static void Teleport(Vector2 position)
    {
        instance.transform.position = position;
    }
}
