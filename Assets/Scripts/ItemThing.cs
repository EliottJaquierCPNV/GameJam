using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemThing : MonoBehaviour
{
    [SerializeField]
    public Item item;
    public bool destroyAfterPickup = true;
    void Awake()
    {
        if (ItemSlot.hasObject(item.name,out Item it) && destroyAfterPickup)
        {
            gameObject.SetActive(false);
        }
    }
    public void AddItem()
    {
        GameCanvasManager.ShowInfo("Vous avez récupéré "+item.commonName);
        ItemSlot.AddItem(item);
        if (destroyAfterPickup)
        {
            gameObject.SetActive(false);
        }
    }
}
