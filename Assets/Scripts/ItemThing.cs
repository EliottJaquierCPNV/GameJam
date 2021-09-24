using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemThing : MonoBehaviour
{
    [SerializeField]
    public Item item;
    public bool destroyAfterPickup = true;
    public void AddItem()
    {
        ItemSlot.AddItem(item);
        if (destroyAfterPickup)
        {
            DestroyImmediate(gameObject);
        }
    }
}
