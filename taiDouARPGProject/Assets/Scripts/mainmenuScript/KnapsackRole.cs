using UnityEngine;
using System.Collections;

public class KnapsackRole : MonoBehaviour 
{
    private KnapsackRoleEquip helmEquip;
    private KnapsackRoleEquip clothEquip;
    private KnapsackRoleEquip weaponEquip;
    private KnapsackRoleEquip shoesEquip;
    private KnapsackRoleEquip necklecaEquip;
    private KnapsackRoleEquip braceletEquip;
    private KnapsackRoleEquip ringEquip;
    private KnapsackRoleEquip wingEquip;

    private UILabel hpLabel;
    private UILabel damageLabel;
    private UILabel expLabel;
    private UISlider expSlider;
	void Awake ()
	{
        helmEquip = transform.Find("HelmSprite").GetComponent<KnapsackRoleEquip>();
        clothEquip = transform.Find("ClothSprite").GetComponent<KnapsackRoleEquip>();
        weaponEquip = transform.Find("WeaponSprite").GetComponent<KnapsackRoleEquip>();
        shoesEquip = transform.Find("ShoesSprite").GetComponent<KnapsackRoleEquip>();
        necklecaEquip = transform.Find("NecklaceSprite").GetComponent<KnapsackRoleEquip>();
        braceletEquip = transform.Find("BraceletSprite").GetComponent<KnapsackRoleEquip>();
        ringEquip = transform.Find("RingSprite").GetComponent<KnapsackRoleEquip>();
        wingEquip = transform.Find("WingSprite").GetComponent<KnapsackRoleEquip>();

        hpLabel = transform.Find("HpBg/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("DamageBg/Label").GetComponent<UILabel>();
        expLabel = transform.Find("ExpSlider/Label").GetComponent<UILabel>();
        expSlider = transform.Find("ExpSlider").GetComponent<UISlider>();

        PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
	}

    void Destroy()
    {
        PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(InfoType type)
    {
        if (type == InfoType.All || type == InfoType.HP || type == InfoType.Damage || type == InfoType.Exp)
            UpdateShow();
    }

    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo._instance;

        //helmEquip.setId(info.HelmID);
        //clothEquip.setId(info.ClothID);
        //weaponEquip.setId(info.WeaponID);
        //shoesEquip.setId(info.ShoesID);
        //necklecaEquip.setId(info.NecklaceID);
        //braceletEquip.setId(info.BraceletID);
        //ringEquip.setId(info.RingID);
        //wingEquip.setId(info.WingID);

        hpLabel.text = info.HP.ToString();
        damageLabel.text = info.Damage.ToString();
        expSlider.value = (float)info.Exp / GameController.GetRequireExpByLevel(info.Level + 1);
        expLabel.text = info.Exp + "/" + GameController.GetRequireExpByLevel(info.Level + 1);
    }
}
