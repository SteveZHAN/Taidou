﻿using UnityEngine;
using System.Collections;

public class TaskItemUI : MonoBehaviour
{
    private UISprite taskTypeSprite;
    private UISprite iconSprite;
    private UILabel nameLabel;
    private UILabel desLabel;
    private UISprite reward1Sprite;
    private UISprite reward2Sprite;
    private UILabel reward1Label;
    private UILabel reward2Label;
    private UIButton rewardButton;
    private UIButton combatButton;
    private UILabel combatButtonLabel;

    private Task task;
    void Awake()
    {
        taskTypeSprite = transform.Find("TaskTypeSprite").GetComponent<UISprite>();
        iconSprite = transform.Find("IconBg/Sprite").GetComponent<UISprite>();
        reward1Sprite = transform.Find("Reward1Sprite").GetComponent<UISprite>();
        reward2Sprite = transform.Find("Reward2Sprite").GetComponent<UISprite>();
        reward1Label = transform.Find("Reward1Label").GetComponent<UILabel>();
        reward2Label = transform.Find("Reward2Label").GetComponent<UILabel>();
        nameLabel = transform.Find("NameLabel").GetComponent<UILabel>();
        desLabel = transform.Find("DesLabel").GetComponent<UILabel>();
        rewardButton = transform.Find("RewardButton").GetComponent<UIButton>();
        combatButton = transform.Find("CombatButton").GetComponent<UIButton>();
        combatButtonLabel = transform.Find("CombatButton/Label").GetComponent<UILabel>();

        EventDelegate ed1 = new EventDelegate(this, "OnCombat");
        combatButton.onClick.Add(ed1);
        EventDelegate ed2 = new EventDelegate(this, "OnReward");
        rewardButton.onClick.Add(ed2);
    }

    public void SetTask(Task task)
    {
        this.task = task;
        task.OnTaskChange += this.OnTaskChange;
        UpdateShow();
    }

    void UpdateShow()           //根据任务信息更新UI显示
    {
        switch (task.TaskType)
        {
            case TaskType.Main:
                taskTypeSprite.spriteName = "pic_主线";
                break;
            case TaskType.Reward:
                taskTypeSprite.spriteName = "pic_奖赏";
                break;
            case TaskType.Daily:
                taskTypeSprite.spriteName = "pic_日常";
                break;
        }
        iconSprite.spriteName = task.Icon;
        nameLabel.text = task.Name;
        desLabel.text = task.Des;
        if (task.Coin > 0 && task.Diamond > 0)
        {
            reward1Sprite.spriteName = "金币";
            reward1Label.text = "x" + task.Coin;
            reward2Sprite.spriteName = "钻石";
            reward2Label.text = "x" + task.Diamond;
        }
        else if (task.Coin > 0)
        {
            reward1Sprite.spriteName = "金币";
            reward1Label.text = "x" + task.Coin;
            reward2Sprite.gameObject.SetActive(false);
            reward2Label.gameObject.SetActive(false);
        }
        else
        {
            reward1Sprite.spriteName = "钻石";
            reward1Label.text = "x" + task.Diamond;
            reward2Sprite.gameObject.SetActive(false);
            reward2Label.gameObject.SetActive(false);
        }
        switch (task.TaskProgress)
        {
            case TaskProgress.NoStart:
                rewardButton.gameObject.SetActive(false);
                combatButtonLabel.text = "下一步";
                break;
            case TaskProgress.Accept:
                rewardButton.gameObject.SetActive(false);
                combatButtonLabel.text = "战斗";
                break;
            case TaskProgress.Complete:
                combatButton.gameObject.SetActive(false);
                break;
        }
    }

    void OnCombat()         //点击“战斗”or“下一步”按钮执行的函数
    {
        TaskUI._instance.Hide();        //隐藏任务系统的面板
        TaskManager._instance.OnExcuteTask(task);
    }

    void OnReward()         //点击“奖励”按纽执行的函数
    {

    }

    void OnTaskChange()
    {
        UpdateShow();
    }
}
