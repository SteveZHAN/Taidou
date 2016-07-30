using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour 
{
    public List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();

    void Awake()
    {
        InventoryManager._instance.OnInventoryChange += this.OnInventoryChange;
    }

    void Destroy()
    {
        InventoryManager._instance.OnInventoryChange -= this.OnInventoryChange;
    }

    void OnInventoryChange()
    {
        UpdateShow();
    }

    void UpdateShow()
    {
        for(int i=0;i<InventoryManager._instance.inventoryItemList.Count;i++)
        {
            InventoryItem it = InventoryManager._instance.inventoryItemList[i];
            Debug.Log(i);
            itemUIList[i].SetInventoryItem(it);     //SetInventoryItem方法实现将it设置进itemUIList[i]中,此方法在InventoryItemUI中声明
        }
        for(int i=InventoryManager._instance.inventoryItemList.Count;i<itemUIList.Count;i++)
        {
            itemUIList[i].Clear();     
        }
    }  
}
