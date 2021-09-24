using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemThing : MonoBehaviour
{
    [SerializeField]
    public Item item;
    public void AddItem()
    {
        ItemSlot.AddItem(item);
    }
}
