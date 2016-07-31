﻿using UnityEngine;
using System.Collections;


public class InventoryItemUI : MonoBehaviour 
{
    private UISprite sprite;
    private UILabel label;
    public InventoryItem it;

    #region get method
    private UISprite Sprite
    {
        get
        {
            if (sprite == null)
                sprite = transform.Find("Sprite").GetComponent<UISprite>();
            return sprite;
        }
    }
    private UILabel Label
    {
        get
        {
            if (label == null)
                label = transform.Find("Label").GetComponent<UILabel>();
            return label;
        }
    }
    #endregion
    public void SetInventoryItem(InventoryItem it)
    {
        this.it = it;
        Sprite.spriteName = it.Inventory.ICON;
        
        if(it.Count<=1)
            Label.text = "";
        else
            Label.text = it.Count.ToString();
    }

    
    public void Clear()             //清空没有物品的多余的UI格子
    {
        it = null;
        Label.text = "";
        Sprite.spriteName = "bg_道具";
    }

    public void OnPress(bool isPress)
    {
        if (isPress && it!=null)
        {
            object[] objectArray = new object[3];
            objectArray[0] = it;
            objectArray[1] = true;
            objectArray[2] = this;
            transform.parent.parent.parent.SendMessage("OnInventoryClick", objectArray);
        }
    }
}