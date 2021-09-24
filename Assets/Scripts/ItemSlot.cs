using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public static Item[] items;
    public Image[] itemsS;
    public Sprite[] sType;
    public Image[] selectItems;
    public Color[] cType;
    private static int lastPut = 0;
    private static ItemSlot instance;
    // Start is called before the first frame update
    void Start()
    {
        items = new Item[3];
    }
    /// <summary>
    /// Add an item to the list
    /// </summary>
    /// <param name="item"></param>
    public static void AddItem(Item item)
    {
        items[lastPut] = item;
        lastPut++;
        if(lastPut > 2)
        {
            lastPut = 0;
        }
        instance.Display();
        instance.UpdateSelected();
    }
    public void Display()
    {
        int i = 0;
        foreach (var item in items)
        {
            itemsS[i].sprite = sType[(int)item.type];
            itemsS[i].color = cType[(int)item.type];
            i++;
        }
    }
    public void UpdateSelected()
    {
        foreach (var itemI in selectItems)
        {
            itemI.color = Color.white;
        }
        instance.selectItems[lastPut].color = Color.red;
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
}
[System.Serializable]
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