using UnityEngine;
using System.Collections;

public class ButtonBar : MonoBehaviour 
{
    private UIButton combatButton;
    private UIButton kanpsackButton;
    private UIButton taskButton;
    private UIButton skillButton;
    private UIButton shopButton;
    private UIButton systemButton;

    void Awake()
    {
        combatButton = transform.Find("Combat").GetComponent<UIButton>();
        kanpsackButton = transform.Find("Knapsack").GetComponent<UIButton>();
        taskButton = transform.Find("Task").GetComponent<UIButton>();
        skillButton = transform.Find("Skill").GetComponent<UIButton>();
        shopButton = transform.Find("Shop").GetComponent<UIButton>();
        systemButton = transform.Find("System").GetComponent<UIButton>();

        EventDelegate ed1 = new EventDelegate(this, "OnCombat");
        combatButton.onClick.Add(ed1);
        EventDelegate ed2 = new EventDelegate(this, "OnKanpsack");
        kanpsackButton.onClick.Add(ed2);
        EventDelegate ed3 = new EventDelegate(this, "OnTask");
        taskButton.onClick.Add(ed3);
        EventDelegate ed4 = new EventDelegate(this, "OnSkill");
        skillButton.onClick.Add(ed4);
        EventDelegate ed5 = new EventDelegate(this, "OnShop");
        shopButton.onClick.Add(ed5);
        EventDelegate ed6 = new EventDelegate(this, "OnSystem");
        systemButton.onClick.Add(ed6);
    }

    /*
    UIButton FindButton(string btnName)
    {
        return transform.Find(btnName).GetComponent<UIButton>();
    }
    */

    void OnCombat()         //点击底部的战斗按钮时调用的函数
    {

    }

    void OnKanpsack()       //点击底部的背包按钮时调用的函数
    {
        knapsack._instance.Show();
    }

    void OnTask()           //点击底部的任务按钮时调用的函数
    {
        TaskUI._instance.Show();
    }

    void OnSkill()          //点击底部的技能按钮时调用的函数
    {
        SkillUI._instance.Show();
    }

    void OnShop()           //点击底部的商店按钮时调用的函数
    {

    }

    void OnSystem()         //点击底部的系统按钮时调用的函数
    {

    }
}
