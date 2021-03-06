﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour 
{
    public static InventoryUI _instance;        //声明为单例模式，便于PlayerInfo中DressOn()方法的调用

    public List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();      //所有的物品格子

    private UIButton clearupButton;
    private UILabel inventoryLabel;

    private int count;          //表示目前有多少个格子是有物品的

    void Awake()
    {
        _instance = this;
        InventoryManager._instance.OnInventoryChange += this.OnInventoryChange;

        clearupButton = transform.Find("ButtonClearup").GetComponent<UIButton>();
        inventoryLabel=transform.Find("InventoryLabel").GetComponent<UILabel>();

        EventDelegate ed = new EventDelegate(this, "OnClearup");
        clearupButton.onClick.Add(ed);
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
        int temp = 0;
        for(int i=0;i<InventoryManager._instance.inventoryItemList.Count;i++)
        {
            InventoryItem it = InventoryManager._instance.inventoryItemList[i];

            if (it.IsDressed == false)      //当装备没有穿上时才执行代码块
            {
                itemUIList[temp].SetInventoryItem(it);     //SetInventoryItem方法实现将it设置进itemUIList[i]中,此方法在InventoryItemUI中声明
                temp++;
            }
            
        }
        count = temp;
        for (int i = temp; i < itemUIList.Count; i++)
        {
            itemUIList[i].Clear();     
        }
        inventoryLabel.text = count + "/32";
    }

    public void UpdateCount()
    {
        count = 0;
        foreach (InventoryItemUI itUI in itemUIList)
        {
            if (itUI.it != null)
            {
                count++;
            }
        }
        inventoryLabel.text = count + "/32";
    }

    public void AddInventoryItem(InventoryItem it)          //添加已有类型的装备时，将装备上的这类型Equip卸下返回添加到物品栏中
    {
        foreach (InventoryItemUI itUI in itemUIList)
        {
            if (itUI.it == null)
            {
                itUI.SetInventoryItem(it);
                count++;
                break;
            }
        }
        inventoryLabel.text = count + "/32";
    }

    //整理
    void OnClearup()
    {
        UpdateShow();
    }

}


