using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public DoorType type;
    public UnityEvent actionWhenOpen;
    public string messageIfFail = "";
    public string secretKeyName = "";
    public void Open()
    {
        switch (type)
        {
            case DoorType.Unlocked:
                OpenDirectely();
                break;
            case DoorType.Key:
                Item it;
                if (ItemSlot.hasObject(secretKeyName,out it))
                {
                    ItemSlot.UseItem(it);
                    OpenDirectely();
                }
                else
                {
                    GameCanvasManager.ShowInfo(messageIfFail);
                }
                break;
            case DoorType.KeyPad:
                GameCanvasManager.KeyPadSetup(this, secretKeyName);
                break;
            case DoorType.Locked:
                GameCanvasManager.ShowInfo(messageIfFail);
                break;
        }
        
    }
    public void OpenDirectely()
    {
        actionWhenOpen.Invoke();
    }
}
public enum DoorType
{
    Locked,
    Unlocked,
    Key,
    KeyPad
}