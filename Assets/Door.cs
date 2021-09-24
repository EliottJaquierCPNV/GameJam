using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public DoorType type;
    public UnityEvent actionWhenOpen;
    public void Open()
    {
        switch (type)
        {
            case DoorType.Unlocked:
                actionWhenOpen.Invoke();
                break;
            case DoorType.Key:
                Item it;
                if (ItemSlot.hasKey(out it))
                {
                    ItemSlot.DeleteItem(it);
                    actionWhenOpen.Invoke();
                }
                break;
            case DoorType.KeyPad:
                actionWhenOpen.Invoke();
                break;
        }
        
    }
}
public enum DoorType
{
    Locked,
    Unlocked,
    Key,
    KeyPad
}