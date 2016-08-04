using UnityEngine;
using System.Collections;

public class InventoryPopup : MonoBehaviour 
{
    private UILabel nameLabel;
    private UISprite inventorySprite;
    private UILabel desLabel;
    private UILabel btnLabel;

    private InventoryItem it;

    void Awake()
    {
        nameLabel = transform.Find("Bg/NameLabel").GetComponent<UILabel>();
        inventorySprite = transform.Find("Bg/Sprite/Sprite").GetComponent<UISprite>();
        desLabel = transform.Find("Bg/Label").GetComponent<UILabel>();
        btnLabel = transform.Find("Bg/ButtonUseBatching/Label").GetComponent<UILabel>();
    }

    public void Show(InventoryItem it)
    {
        this.gameObject.SetActive(true);

        this.it = it;
        nameLabel.text = it.Inventory.Name;
        inventorySprite.spriteName = it.Inventory.ICON;
        desLabel.text = it.Inventory.Des;
        btnLabel.text = "批量使用(" + it.Count + ")";
    }
}
