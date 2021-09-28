using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Item item;
    public Image itImg;
    public void Setup(Item it)
    {
        item = it;
        itImg.sprite = item.image;
        if (it.used)
        {
            itImg.color = Color.black;
        }
        else
        {
            itImg.color = Color.white;
        }
        gameObject.SetActive(true);
    }
}
