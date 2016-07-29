using UnityEngine;
using System.Collections;

public class KnapsackRole : MonoBehaviour 
{
    private UISprite helmSprite;
    private UISprite clothSprite;
    private UISprite weaponSprite;
    private UISprite shoesSprite;
    private UISprite necklecaSprite;
    private UISprite braceletSprite;
    private UISprite ringSprite;
    private UISprite wingSprite;

    private UILabel hpLabel;
    private UILabel damageLabel;
    private UILabel expLabel;
    private UISlider expSlider;
	void Awake ()
	{
        helmSprite = transform.Find("HelmSprite").GetComponent<UISprite>();
        clothSprite = transform.Find("ClothSprite").GetComponent<UISprite>();
        weaponSprite = transform.Find("WeaponSprite").GetComponent<UISprite>();
        shoesSprite = transform.Find("ShoesSprite").GetComponent<UISprite>();
        necklecaSprite = transform.Find("NecklecaSprite").GetComponent<UISprite>();
        braceletSprite = transform.Find("BraceletSprite").GetComponent<UISprite>();
        ringSprite = transform.Find("RingSprite").GetComponent<UISprite>();
        wingSprite = transform.Find("WingSprite").GetComponent<UISprite>();

        hpLabel = transform.Find("HpBg/Label").GetComponent<UILabel>();
        damageLabel = transform.Find("DamageBg/Label").GetComponent<UILabel>();
        expLabel = transform.Find("ExpSlider/Label").GetComponent<UILabel>();
        expSlider = transform.Find("ExpSlider").GetComponent<UISlider>();
	}
}
