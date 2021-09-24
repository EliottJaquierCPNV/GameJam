using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Item[] items;
    public Sprite[] itemsS;
    // Start is called before the first frame update
    void Start()
    {
        items = new Item[3];
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (var item in items)
        {
            i++;
        }
    }
}
public struct Item
{
    public string name;
    public Type type;
    public int id;
}
public enum Type
{
    None,
    Key
}