using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour 
{
    public static InventoryUI _instance;        //声明为单例模式，便于PlayerInfo中DressOn()方法的调用

    public List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();      //所有的物品格子

    void Awake()
    {
        _instance = this;
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
            //Debug.Log(i);         //for test
            itemUIList[i].SetInventoryItem(it);     //SetInventoryItem方法实现将it设置进itemUIList[i]中,此方法在InventoryItemUI中声明
        }
        for(int i=InventoryManager._instance.inventoryItemList.Count;i<itemUIList.Count;i++)
        {
            itemUIList[i].Clear();     
        }
    }  

    //todo
    public void AddInventoryItem(InventoryItem it)          //添加已有类型的装备时，将装备上的这类型Equip卸下返回添加到物品栏中
    {
        foreach (InventoryItemUI itUI in itemUIList)
        {
            if (itUI.it == null)
            {
                itUI.SetInventoryItem(it);
                break;
            }
        }
    }
}


