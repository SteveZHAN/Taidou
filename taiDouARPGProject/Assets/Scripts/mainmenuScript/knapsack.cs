using UnityEngine;
using System.Collections;

public class knapsack : MonoBehaviour 
{
    private EquipPopup equipPopup;
    private InventoryPopup inventoryPopup;

    void Awake()
    {
        equipPopup = transform.Find("EquipPopup").GetComponent<EquipPopup>();
        inventoryPopup = transform.Find("InventoryPopup").GetComponent<InventoryPopup>();
    }
    public void OnInventoryClick(object[] objectArray)
    {
        InventoryItem it = objectArray[0] as InventoryItem;
        bool isLeft = (bool)objectArray[1];

        if (it.Inventory.InventoryTYPE == InventoryType.Equip)
        {
            InventoryItemUI itUI = null;
            KnapsackRoleEquip roleEquip = null;
            if (isLeft==true)
            {
                itUI = objectArray[2] as InventoryItemUI;
            }
            else
            {
                roleEquip = objectArray[2] as KnapsackRoleEquip;
            }
            equipPopup.Show(it, itUI, roleEquip, isLeft);
        }
        else
            inventoryPopup.Show(it);
    }
}
