using UnityEngine;
using System.Collections;

public class PlayerBar : MonoBehaviour 
{
    //设置UI左上角的个人信息的相关组件的各个私有变量
    private UISprite headSprite;
    private UILabel nameLabel;
    private UILabel levelLabel;
    private UISlider energySlider;
    private UILabel energyLabel;
    private UISlider toughenSlider;
    private UILabel toughenLabel;
    private UIButton energyPlusButton;
    private UIButton toughenPlusButton;

    void Awake()
    {
        //利用Find查找给各个私有变量进行赋初值
        headSprite = transform.Find("HeadSprite").GetComponent<UISprite>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        levelLabel = transform.Find("LevelLabel").GetComponent<UILabel>();
        energySlider = transform.Find("EnergyProgressBar").GetComponent<UISlider>();
        toughenSlider = transform.Find("ToughenProgressBar").GetComponent<UISlider>();
        energyLabel = transform.Find("EnergyProgressBar/Label").GetComponent<UILabel>();
        toughenLabel = transform.Find("ToughenProgressBar/Label").GetComponent<UILabel>();
        energyPlusButton = transform.Find("EnerggyPlusButton").GetComponent<UIButton>();
        toughenPlusButton = transform.Find("ToughenPlusButton").GetComponent<UIButton>();
    }
}
