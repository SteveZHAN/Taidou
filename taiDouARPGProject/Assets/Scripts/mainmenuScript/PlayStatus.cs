using UnityEngine;
using System.Collections;


public class PlayStatus : MonoBehaviour 
{
    public static PlayStatus _instance;

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

    private TweenPosition tween;            //playStatus上的position移动动画

    private UIButton closeButton;           //人物状态信息的关闭按钮Button变量

	void Awake ()
	{
        _instance = this;

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

        PlayerInfo._instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;

        tween = this.GetComponent<TweenPosition>();
        closeButton = transform.Find("ButtonClose").GetComponent<UIButton>();

        EventDelegate ed = new EventDelegate(this, "OnButtonCloseClick");
        closeButton.onClick.Add(ed);
	}

    void Update()
    {
        UpdateEnergyAndToughenShow();       //更新体力和历练恢复时间的计时器
    }

    void OnDestroy()
    {
        PlayerInfo._instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }

    void OnPlayerInfoChanged(InfoType type)
    {
        UpdateShow();
    }

    void UpdateShow()
    {
        PlayerInfo info = PlayerInfo._instance;

        headSprite.spriteName = info.HeadPortrait;
        levelLabel.text = info.Level.ToString();
        nameLabel.text = info.Name.ToString();
        powerLabel.text = info.Power.ToString();
        int requireExp = GameController.GetRequireExpByLevel(info.Level + 1);
        expSlider.value = (float)info.Exp / requireExp;
        expLabel.text = info.Exp + "/" + requireExp;
        diamondLabel.text = info.Diamond.ToString();
        coinLabel.text = info.Coin.ToString();

        UpdateEnergyAndToughenShow();       //更新体力和历练的显示

    }

    //体力&历练、体力&历练恢复时间、体力&历练全部恢复的算法实现
    void UpdateEnergyAndToughenShow()
    {
        PlayerInfo info = PlayerInfo._instance;

        energyLabel.text = info.Energy + "/100";
        if(info.Energy>=100)
        {
            energyRestorePartLabel.text = "00:00:00";
            energyRestoreAllLabel.text = "00:00:00";
        }
        else
        {
            int remainTime = 60 - (int)info.energyTimer;
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            energyRestorePartLabel.text = "00:00:" + str;
            
            //首先总的体力为100 其中一个体力是在最后的00表示 
            int minutes = (99 - info.Energy);
            int hours = minutes / 60;
            minutes = minutes % 60;
            string hoursStr = hours <= 9 ? "0" + hours : hours.ToString();
            string minutesStr = minutes <= 9 ? "0" + minutes : minutes.ToString();
            energyRestoreAllLabel.text = hoursStr + ":" + minutesStr + ":" + str;
        }

        ToughenLabel.text = info.Toughen + "/50";
        if(info.Toughen>=50)
        {
            ToughenRestorePartLabel.text = "00:00:00";
            ToughenRestoreAllLabel.text = "00:00:00";
        }
        else
        {
            int remainTime = 60 - (int)info.toughenTimer;
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            ToughenRestorePartLabel.text = "00:00:" + str;

            //首先总的历练为50 最后的两个零使用了一个历练
            int minutes = (49 - info.Toughen);
            int hours = minutes / 60;
            minutes = minutes % 60;
            string hoursStr = hours <= 9 ? "0" + hours : hours.ToString();
            string minutesStr = minutes <= 9 ? "0" + minutes : minutes.ToString();
            ToughenRestoreAllLabel.text = hoursStr + ":" + minutesStr + ":" + str;
        }
    }

    public void Show()
    {
        tween.PlayForward();            //移进动画的播放
    }

    public void OnButtonCloseClick()
    {
        tween.PlayReverse();
    }
}
