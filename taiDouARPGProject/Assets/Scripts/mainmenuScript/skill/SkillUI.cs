using UnityEngine;
using System.Collections;

public class SkillUI : MonoBehaviour 
{
    private UILabel skillNameLabel;
    private UILabel skillDesLabel;
    private UIButton closeButton;
    private UIButton upgradeButton;
    private UILabel upgradeButtonLabel;
	void Awake ()
	{
        skillNameLabel = transform.Find("Bg/SkillNameLabel").GetComponent<UILabel>();
        skillDesLabel = transform.Find("Bg/DesLabel").GetComponent<UILabel>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();
        upgradeButton = transform.Find("UpgradeButton").GetComponent<UIButton>();
        upgradeButtonLabel = transform.Find("UpgradeButton/Label").GetComponent<UILabel>();

        skillNameLabel.text = "";
        skillDesLabel.text = "";

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
}
