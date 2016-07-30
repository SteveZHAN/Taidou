using UnityEngine;
using System.Collections;

public class KnapsackRoleEquip : MonoBehaviour 
{
    private InventoryItem it;

    private UISprite _sprite;
    private UISprite Sprite
    {
        get
        {
            if (_sprite == null)
                _sprite = this.GetComponent<UISprite>();
            return _sprite;
        }
    }

    public void setId(int id)
    {
        Inventory inventory = null;
        bool isExit = InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);
        if(isExit)
        {
            Sprite.spriteName = inventory.ICON;
        }
    }

    public void SetInventoryItem(InventoryItem it)
    {
        this.it = it;
        Sprite.spriteName = it.Inventory.ICON;
    }

    public void OnPress(bool isPress)
    {
        if(isPress)
        {
            object[] objectArray=new object[2];
            objectArray[0]=it;
            objectArray[1]=false;
            transform.parent.parent.SendMessage("OnInventoryClick", objectArray);
        }
    }
}
