using UnityEngine;
using System.Collections;

public class PlayStatus : MonoBehaviour 
{
    private UISprite headSprite;
    private UILabel nameLabel;
    private UILabel levelLabel;
    private UILabel powerLabel;
    private UISlider expSlider;
    private UILabel expLabel;
    private UILabel diamondLabel;
    private UILabel coinLabel;
    private UILabel energyLabel;
    private UILabel energyRestorePartLabel;
    private UILabel energyRestoreAllLabel;
    private UILabel ToughenLabel;
    private UILabel ToughenRestorePartLabel;
    private UILabel ToughenRestoreAllLabel;

	void Awake ()
	{
        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();
        powerLabel = transform.Find("PowerLabel").GetComponent<UILabel>();
        expLabel = transform.Find("ExpProgressBar/Label").GetComponent<UILabel>();
        expSlider = transform.Find("ExpProgressBar").GetComponent<UISlider>();
        diamondLabel = transform.Find("DiamondLabel/Label").GetComponent<UILabel>();
        coinLabel = transform.Find("CoinLabel/Label").GetComponent<UILabel>();
        energyLabel = transform.Find("EnergyLabel/NumLabel").GetComponent<UILabel>();
        energyRestorePartLabel = transform.Find("EnergyLabel/RestorePartTime").GetComponent<UILabel>();
        energyRestoreAllLabel = transform.Find("EnergyLabel/RestoreAllTime").GetComponent<UILabel>();
        ToughenLabel = transform.Find("ToughenLabel/NumLabel").GetComponent<UILabel>();
        ToughenRestorePartLabel = transform.Find("ToughenLabel/RestorePartTime").GetComponent<UILabel>();
        ToughenRestoreAllLabel = transform.Find("ToughenLabel/RestoreAllTime").GetComponent<UILabel>();


	}
}
