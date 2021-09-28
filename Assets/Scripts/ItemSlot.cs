using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public static List<Item> items;
    public List<ItemUI> itemsUI;
    public GameObject listUI;
    public GameObject instanceUI;
    public FMODUnity.StudioEventEmitter eventAud;
    private static ItemSlot instance;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>(0);
    }
    /// <summary>
    /// Add an item to the list
    /// </summary>
    /// <param name="item"></param>
    public static void AddItem(Item item)
    {
        instance.eventAud.Play();
        items.Add(item);
        instance.Display();
    }
    public static void UseItem(Item item)
    {
        int count = 0;
        foreach (Item itemTest in items)
        {
            if(itemTest.name == item.name)
            {
                Item it = items[count];
                it.used = true;
                items[count] = it;
                instance.Display();
                instance.eventAud.Play();
                break;
            }
            count++;
        }
    }
    public static bool hasObject(string name,out Item it)
    {
        foreach (Item itemS in items)
        {
            if (itemS.name == name)
            {
                it = itemS;
                return true;
            }
        }
        it = new Item();
        return false;
    }
    public void Display()
    {
        foreach (ItemUI itUI in itemsUI)
        {
            GameObject.Destroy(itUI.gameObject);
        }
        itemsUI.Clear();

        listUI.GetComponent<RectTransform>().sizeDelta = new Vector2(listUI.GetComponent<RectTransform>().sizeDelta.x, 30+(75*items.Count));

        int i = 0;
        foreach (var item in items)
        {
            GameObject inst = Instantiate(instanceUI, listUI.transform) as GameObject;
            inst.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,(-42)-(75*i));
            ItemUI itUI = inst.GetComponent<ItemUI>();
            itUI.Setup(item);
            itemsUI.Add(itUI);
            i++;
        }
    }
    /*public void UpdateSelected()
    {
        foreach (var itemI in selectItems)
        {
            itemI.color = Color.white;
        }
        instance.selectItems[lastPut].color = Color.red;
    }*/
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
    public Sprite image;
    public bool used;
    public string commonName;
}