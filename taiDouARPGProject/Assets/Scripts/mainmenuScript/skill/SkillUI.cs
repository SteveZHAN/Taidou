using UnityEngine;
using System.Collections;

public class SkillUI : MonoBehaviour 
{
    private UILabel skillNameLabel;
    private UILabel skillDesLabel;
    private UIButton closeButton;
    private UIButton upgradeButton;
    private UILabel upgradeButtonLabel;

    private Skill skill;
	void Awake ()
	{
        skillNameLabel = transform.Find("Bg/SkillNameLabel").GetComponent<UILabel>();
        skillDesLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        upgradeButton = transform.Find("UpgradeButton").GetComponent<UIButton>();
        upgradeButtonLabel = transform.Find("UpgradeButton/Label").GetComponent<UILabel>();

        skillNameLabel.text = "";
        skillDesLabel.text = "";

        EventDelegate ed = new EventDelegate(this, "OnUpgrade");
        upgradeButton.onClick.Add(ed);

        DisableUpgradeButton("选择技能");       //默认升级按钮是禁用的，上面的文字是“选择技能”
    }
	void DisableUpgradeButton(string label="")         //将升级按钮状态设置为不能使用，并且传入字符串修改按钮上的文字
	{
        upgradeButton.SetState(UIButton.State.Disabled,true);        //将升级按钮的状态立即(true代表立即)设置为Disabled，不能使用
        upgradeButton.GetComponent<Collider>().enabled = false;     //将升级按钮的Collder碰撞体状态设置为false
        if (label != "")
        {
            upgradeButtonLabel.text = label;        //如果传入的参数label不为空，就将upgradeButtonLabel上的文字设为参数label
        }
	}

    void EnableUpgradeButton(string label = "")             //启用升级按钮
    {
        upgradeButton.SetState(UIButton.State.Normal, true);        //将升级按钮的状态立即(true代表立即)设置为Normal，常态使用
        upgradeButton.GetComponent<Collider>().enabled = true;     //将升级按钮的Collder碰撞体状态设置为false
        if (label != "")
        {
            upgradeButtonLabel.text = label;        //如果传入的参数label不为空，就将upgradeButtonLabel上的文字设为参数label
        }
    }
    void OnSkillClick(Skill skill)          //点击技能调用的函数，此处由SkillItemUI脚本中的OnClick函数进行检测发送消息调用此函数
    {
        this.skill = skill;
        PlayerInfo info=PlayerInfo._instance;
        if (500*(skill.Level+1) <= info.Coin){
            if (skill.Level < info.Level) {
                EnableUpgradeButton("升级");          //金币足够情况下点击技能后启用升级按钮 && 技能等级不能超过角色的等级
            }
            else{
                DisableUpgradeButton("已最大等级");
            }
        }
        else{
            DisableUpgradeButton("金币不足");
        }

        skillNameLabel.text = skill.Name + " Lv." + skill.Level;
        skillDesLabel.text = "当前技能的攻击力为：" + (skill.Damage * skill.Level) + "下一级技能的攻击力为：" + (skill.Damage * (skill.Level + 1))
                            + "升级所需要的金币数量：" + (500 * (skill.Level + 1));
 

    }

    void OnUpgrade()            //点击升级按钮调用的函数
    {
        PlayerInfo info = PlayerInfo._instance;
        if (skill.Level < info.Level)
        {
            int coinNeed = 500 * (skill.Level + 1);
            bool isSuccess = info.GetCoin(coinNeed);
            if (isSuccess)
            {
                skill.Upgrade();        //调用Skill脚本中的Upgrade方法进行升级
                OnSkillClick(skill);
            }
            else
            {
                DisableUpgradeButton("金币不足");
            }
        }
        else
        {
            DisableUpgradeButton("已最大等级");
        }
        
    }
}
