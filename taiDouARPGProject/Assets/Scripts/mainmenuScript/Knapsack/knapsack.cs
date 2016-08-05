using UnityEngine;
using System.Collections;

public class knapsack : MonoBehaviour
{
    private EquipPopup equipPopup;
    private InventoryPopup inventoryPopup;

    private UIButton saleButton;
    private UILabel priceLabel;

    private InventoryItemUI itUI;
    void Awake()
    {
        equipPopup = transform.Find("EquipPopup").GetComponent<EquipPopup>();
        inventoryPopup = transform.Find("InventoryPopup").GetComponent<InventoryPopup>();

        saleButton = transform.Find("Inventory/ButtonSale").GetComponent<UIButton>();
        priceLabel = transform.Find("Inventory/PriceBg/Label").GetComponent<UILabel>();

        DisableButton();
        
        EventDelegate ed = new EventDelegate(this, "OnSale");
        saleButton.onClick.Add(ed);
    }
    public void OnInventoryClick(object[] objectArray)
    {
        InventoryItem it = objectArray[0] as InventoryItem;
        bool isLeft = (bool)objectArray[1];

        if (it.Inventory.InventoryTYPE == InventoryType.Equip)
        {
            InventoryItemUI itUI = null;
            KnapsackRoleEquip roleEquip = null;
            if (isLeft == true)
            {
                itUI = objectArray[2] as InventoryItemUI;
            }
            else
            {
                roleEquip = objectArray[2] as KnapsackRoleEquip;
            }
            inventoryPopup.Close();         //为了显示装备弹框，此时先将物品弹框关闭，避免两个弹框一起出现，对出售产生干扰
            equipPopup.Show(it, itUI, roleEquip, isLeft);
        }
        else
        {
            InventoryItemUI itUI = objectArray[2] as InventoryItemUI;
            equipPopup.Close();             //为了显示物品弹框，此时先将装备弹框关闭，避免两个弹框一起出现，对出售产生干扰
            inventoryPopup.Show(it, itUI);
        }

        if ((it.Inventory.InventoryTYPE == InventoryType.Equip && isLeft==true)||it.Inventory.InventoryTYPE!=InventoryType.Equip)   //非人物穿的装备或非装备
        {
            this.itUI = objectArray[2] as InventoryItemUI;
            EnableButton();
            priceLabel.text = (this.itUI.it.Inventory.Price * itUI.it.Count).ToString();

        }
    }

    void DisableButton()
    {
        priceLabel.text = "";

        saleButton.SetState(UIButtonColor.State.Disabled, true);        //SetState是设置Button的状态，此代码中将颜色状态立即Disable掉
        saleButton.GetComponent<Collider>().enabled = false;            //禁用Button的点击碰撞
    }

    void EnableButton()
    {
        saleButton.SetState(UIButtonColor.State.Normal, true);
        saleButton.GetComponent<Collider>().enabled = true;
    }

    void OnSale()
    {
        int price = int.Parse(priceLabel.text);
        PlayerInfo._instance.AddCoin(price);

        InventoryManager._instance.RemoveInventoryItem(itUI.it);
        itUI.Clear();

        equipPopup.Close();
        inventoryPopup.Close();

        DisableButton();
    }
}